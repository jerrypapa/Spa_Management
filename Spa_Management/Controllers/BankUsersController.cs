using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Models;
using Spa_Management.Operations;
using Microsoft.AspNetCore.Identity;
using Spa_Management.Services;
using System.ComponentModel.DataAnnotations;
using Spa_Management.Interfaces;

namespace Spa_Management.Controllers
{
    public class BankUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly UserManager<ApplicationUser> _userManager;

        public BankUsersController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _dbOps = dbOps;
            _userManager = manager;
        }

        // GET: BankUsers
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("MasterAdmin") || User.IsInRole("BankAdmin"))
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
                var id = _context.TbBankUsers.FirstOrDefault(k => k.bankUserGuid == me.bankUserGuid).SystemBanksGuid;

               // var id = _context.TbBankUsers.FirstOrDefault(k => k.addedBy.ToString() == me.bankUserGuid).SystemBanksGuid;
                ViewData["BankGuid"] = id;
                ViewData["BankName"] = _context.TbSystemBanks.FirstOrDefault(k => k.SystemBanksGuid == id).bankName;
                var ApplicationDbContext = await _context.TbBankUsers.Where(j => j.SystemBanksGuid == id).ToListAsync();
                List<ViewBankUsers> _CompUsers = new List<ViewBankUsers>();
                int i = 1;
                foreach (var a in ApplicationDbContext)
                {
                    ViewBankUsers user = new ViewBankUsers()
                    {
                        id = i++,
                        bankUserGuid = a.bankUserGuid,
                        Name = string.Format("{0} {1} {2}", a.SirName, a.FirstName, a.LastName),
                        contact = a.contact,
                        Email = a.email,
                        idNumber = a.idNumber,
                        Role = await _dbOps.GetUserRole(a.bankUserGuid, 2),
                        status = a.status
                    };
                    _CompUsers.Add(user);
                }
                return View(_CompUsers);
                //return View(await _context.TbBankUsers.Where(j => j.SystemBanksGuid == id).ToListAsync());
            }
            return new ForbidResult();
        }

        // GET: BankUsers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBankUsers = await _context.TbBankUsers
                .SingleOrDefaultAsync(m => m.bankUserGuid == id);
            if (tbBankUsers == null)
            {
                return NotFound();
            }

            return View(tbBankUsers);
        }

        // GET: BankUsers/Create
        public IActionResult Create(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = new tbBankUsers() { SystemBanksGuid = id.Value };
            ViewData["BankName"] = _context.TbSystemBanks.FirstOrDefault(k => k.SystemBanksGuid == id).bankName;
            return View(user);
        }

        // POST: BankUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SystemBanksGuid,bankUserGuid,SirName,FirstName,LastName,contact,email,gender,dob,idType,idNumber,status")] tbBankUsers tbBankUsers)
        {
            try
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
                tbBankUsers.status = 0;
                tbBankUsers.regDate = DateTime.Now;
                tbBankUsers.addedBy = Guid.Parse(me.Id);
                if (ModelState.IsValid)
                {
                    var fon = phoneNumberNomalizer.phoneNum(tbBankUsers.contact);
                    if (!object.ReferenceEquals(fon, null))
                    {
                        if (phoneNumberNomalizer.IsValidEmail(tbBankUsers.email))
                        {
                            if (!await _dbOps.IsEmailUsed(tbBankUsers.email))
                            {
                                if (User.IsInRole("MasterAdmin"))
                                {
                                    tbBankUsers.status = 0;
                                }
                                    tbBankUsers.contact = fon;
                                tbBankUsers.bankUserGuid = Guid.NewGuid();
                                _context.Add(tbBankUsers);
                                await _context.SaveChangesAsync();
                                //Create new System User
                                var _user = new ApplicationUser
                                {
                                    UserName = tbBankUsers.email,
                                    Email = tbBankUsers.email,
                                    bankUserGuid = tbBankUsers.bankUserGuid,
                                    PhoneNumber = tbBankUsers.contact
                                };
                                var pass = _dbOps.GenerateRandomPassword(); // + "aA1@";
                                var result = await _userManager.CreateAsync(_user, pass);
                                var code = await _userManager.GenerateEmailConfirmationTokenAsync(_user);
                                var callbackUrl = Url.EmailConfirmationLink(_user.Id, code, Request.Scheme);
                                await _dbOps.LogAndSendMail(tbBankUsers.email,"Email Confirmation", callbackUrl);
                                if (User.IsInRole("MasterAdmin"))
                                {
                                    await _userManager.AddToRoleAsync(_user, "BankAdmin");
                                }
                                if (User.IsInRole("BankAdmin"))
                                {
                                    await _userManager.AddToRoleAsync(_user, "BankUser");
                                }

                                await _dbOps.LogAndSendMail(tbBankUsers.email, "Password", "Dear " + tbBankUsers.FirstName + " Your Account Password is " + pass);
                                await _dbOps.LogandSendSMS(tbBankUsers.contact,"Dear " + tbBankUsers.FirstName + " Your Account Password is " + pass,"","","");
                                await _dbOps.AuditOperation(User.Identity.Name, "BankUsers/Create", "Create new user id = " + tbBankUsers.bankUserGuid.ToString(), "", "BankUsers/Create");
                                return RedirectToAction("Users", "SystemBanks", new { id = tbBankUsers.SystemBanksGuid });
                            }
                            else
                            {
                                ModelState.AddModelError("", "Email Already Used");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid Email Address");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Phone Number");
                    }
                }
            }
            catch (Exception ex)
            {
                await _dbOps.LogError("BankUsers/Create", "Creating a new Bank user " + tbBankUsers.bankUserGuid.ToString(), "", ex.Message, object.ReferenceEquals(ex.InnerException, null) ? "" : ex.InnerException.ToString());
            }
            ViewData["BankName"] = _context.TbSystemBanks.FirstOrDefault(k => k.SystemBanksGuid == tbBankUsers.SystemBanksGuid).bankName;
            return View(tbBankUsers);
        }

        // GET: BankUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBankUsers = await _context.TbBankUsers.SingleOrDefaultAsync(m => m.bankUserGuid == id);
            if (tbBankUsers == null)
            {
                return NotFound();
            }
            ViewData["Status"] = new List<SelectListItem>
                        {
                            new SelectListItem {Text = "Active", Value = "0"},
                            new SelectListItem {Text = "Discontinue", Value = "1"},
                            new SelectListItem {Text = "Authorize", Value = "2"}
                        };
            return View(tbBankUsers);
        }

        // POST: BankUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SystemBanksGuid,regDate,bankUserGuid,SirName,FirstName,LastName,contact,email,gender,dob,idType,idNumber,status,addedBy")] tbBankUsers tbBankUsers)
        {
            
            if (id != tbBankUsers.bankUserGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bool go = true;
                    var me = await _userManager.GetUserAsync(HttpContext.User);
                    if (tbBankUsers.status == 2)
                    {
                        //var b = me.Id;
                        if(tbBankUsers.addedBy != Guid.Parse(me.Id))
                        {
                            tbBankUsers.status = 0;
                            tbBankUsers.checkedBy = Guid.Parse(me.Id);
                            tbBankUsers.checkerDate = DateTime.Now;
                        }
                        else
                        {
                            go = false;
                            ModelState.AddModelError("", "Maker Cannot be Checker");
                        }
                    }
                    if (go)
                    {
                        var fon = phoneNumberNomalizer.phoneNum(tbBankUsers.contact);
                        if (!object.ReferenceEquals(fon, null))
                        {
                            if (phoneNumberNomalizer.IsValidEmail(tbBankUsers.email))
                            {
                                _context.Update(tbBankUsers);
                                await _context.SaveChangesAsync();
                                await _dbOps.AuditOperation(User.Identity.Name, "BankUsers/Edit", "Edited user id = " + tbBankUsers.bankUserGuid.ToString(), "", "BankUsers/Edit");
                                return RedirectToAction("Users", "SystemBanks", new { id = tbBankUsers.SystemBanksGuid });
                            }
                            else
                            {
                                ModelState.AddModelError("", "Invalid Email Address");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid Phone Number");
                        }
                    }
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbBankUsersExists(tbBankUsers.bankUserGuid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index), new { id = tbBankUsers.SystemBanksGuid });
            }
            ViewData["Status"] = new List<SelectListItem>
                        {
                            new SelectListItem {Text = "Active", Value = "0"},
                            new SelectListItem {Text = "Discontinue", Value = "1"},
                            new SelectListItem {Text = "Authorize", Value = "2"}
                        };
          return View(tbBankUsers);
        }

        // GET: BankUsers/Delete/5
        public  async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBankUsers = await _context.TbBankUsers
                .SingleOrDefaultAsync(m => m.bankUserGuid == id);
            if (tbBankUsers == null)
            {
                return NotFound();
            }

            return View(tbBankUsers);
        }

        // POST: BankUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tbBankUsers = await _context.TbBankUsers.SingleOrDefaultAsync(m => m.bankUserGuid == id);
            _context.TbBankUsers.Remove(tbBankUsers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbBankUsersExists(Guid id)
        {
            return _context.TbBankUsers.Any(e => e.bankUserGuid == id);
        }
    }
    public class ViewBankUsers
    {
        public int id { get; set; }
        public Guid bankUserGuid { get; set; }

        public string Name { get; set; }

        [Display(Name = "Mobile Number")]
        public string contact { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "ID NO")]
        public string idNumber { get; set; }

        public string Role { get; set; }


        /// <summary>
        /// 0 = Active/ Checked,
        /// 1 = Discontinued,
        /// 2 = Added,
        /// 3 = Checker Rejected
        /// </summary>
        public int status { get; set; }
    }
}
