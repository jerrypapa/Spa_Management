using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Models;
using Spa_Management.Operations;

namespace Spa_Management.Controllers
{
    public class SpaUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly UserManager<ApplicationUser> _userManager;

        public SpaUsersController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _dbOps = dbOps;
            _userManager = manager;
        }

        // GET: SpaUsers
        public async Task<IActionResult> Index()
        {
            ViewData["DocumentsVerified"] = true;
            ViewData["DirectorsVerified"] = true;
            ViewData["DirectorsRegistered"] = true;
            ViewData["DocumentsRegistered"] = true;

            if (User.IsInRole("Spa Admin"))
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
                var id = _context.SpaUsers.FirstOrDefault(j => j.spaUserGuid == me.spaUserGuid).spaGuid;
                var ApplicationDbContext = _context.SpaUsers.Where(k => k.spaGuid == id).Include(t => t.SpaDetails);
                List<ViewspaUsers_> _spaUsers = new List<ViewspaUsers_>(); 
                int i = 1;
                foreach (var a in ApplicationDbContext)
                {
                    ViewspaUsers_ user = new ViewspaUsers_()
                    {
                        id = i++,
                        spaUserGuid = a.spaUserGuid,
                        Name = string.Format("{0} {1} {2}", a.SirName, a.FirstName, a.LastName),
                        contact = a.contact,
                        Email = a.email,
                        idNumber = a.idNumber,
                        Role =!string.IsNullOrWhiteSpace(a.spaRolesId) ? await _dbOps.GetSpaUserRole(a.spaUserGuid, 1) : await _dbOps.GetUserRole(a.spaUserGuid, 4),
                        status = a.status
                    };
                    _spaUsers.Add(user);
                }
                ViewData["spaName"] = _context.SpaDetails.FirstOrDefault(k => k.spaGuid == id).spaName;
                ViewData["spaGuid"] = id;
                //return View(await ApplicationDbContext.ToListAsync());
                return View(_spaUsers);
            }
            return new ForbidResult();
            //var ApplicationDbContext = _context.SpaUsers.Include(s => s.SpaDetails);
            //return View(await ApplicationDbContext.ToListAsync());
        }
        public class ViewspaUsers_
        {
            public int id { get; set; }
            public Guid spaUserGuid { get; set; }

            public string Name { get; set; }

            [Display(Name = "Mobile Number")]
            public string contact { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "ID NO")]
            public string idNumber { get; set; }

            public string Role { get; set; }

            public int status { get; set; }
        }
        // GET: SpaUsers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaUsers = await _context.SpaUsers
                .Include(s => s.SpaDetails)
                .SingleOrDefaultAsync(m => m.spaUserGuid == id);
            if (spaUsers == null)
            {
                return NotFound();
            }

            return View(spaUsers);
        }

        // GET: SpaUsers/Create
        public async Task<IActionResult> Create(Guid? id)
        {
            Guid spaid = Guid.Empty;
            if (id == null)
            {
                return NotFound();
            }
            if(User.IsInRole("Spa Admin"))
            {
                var me2 = await _userManager.GetUserAsync(HttpContext.User);
                spaid = _context.SpaUsers.AsNoTracking().FirstOrDefault(j => j.spaUserGuid == me2.spaUserGuid).spaGuid;
            }
            var user = new SpaUsers() { spaGuid = id.Value };
            ViewData["spaName"] = _context.SpaDetails.FirstOrDefault(k => k.spaGuid == id).spaName;
            ViewData["designation"] = new SelectList(_context.TbDesignations, "designation", "designation");
            ViewData["spaRolesId"] = new SelectList(_context.SpaRoles.Where(c=>c.SpaDetailsId==spaid), "Id", "RoleName");
            return View(user);
            //ViewData["spaGuid"] = new SelectList(_context.SpaDetails, "spaGuid", "PinNo");
            //return View();
        }

        // POST: SpaUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("spaUserGuid,spaGuid,SirName,FirstName,MiddleName,LastName,contact,email,dob,idType,idNumber,status,regDate,pysicalLoc,spaRolesId")] SpaUsers spaUsers)
        {
            try
            {
                spaUsers.status = 0;
                spaUsers.regDate = DateTime.Now;
                var fon = phoneNumberNomalizer.phoneNum(spaUsers.contact);
                if (phoneNumberNomalizer.IsValidEmail(spaUsers.email))
                {
                    if (!object.ReferenceEquals(fon, null))
                    {
                        if (!await _dbOps.IsEmailUsed(spaUsers.email))
                        {
                            if (ModelState.IsValid)
                            {
                                spaUsers.contact = fon;
                                spaUsers.spaUserGuid = Guid.NewGuid();
                                spaUsers.spaRolesId = spaUsers.spaRolesId;
                                _context.Add(spaUsers);
                                await _context.SaveChangesAsync();
                                //Create new System User

                                var user = new ApplicationUser
                                {
                                    UserName = spaUsers.email,
                                    Email = spaUsers.email,
                                    spaUserGuid = spaUsers.spaUserGuid,
                                    PhoneNumber = spaUsers.contact
                                };

                                var pass = _dbOps.GenerateRandomPassword(); // + "aA1@";
                                var result = await _userManager.CreateAsync(user, pass);
                                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                                var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                                var text1 = $". To confirm your Spa Intl account,please click here: <a href='{callbackUrl}'>link</a>";
                                await _dbOps.LogAndSendMail(spaUsers.email, "Spa Intl Account Email Confirmation", text1);
                                if (User.IsInRole("MasterAdmin"))
                                {
                                    await _userManager.AddToRoleAsync(user, "Spa Admin");
                                }
                                if (User.IsInRole("Spa Admin")||User.IsInRole("SPAADMIN"))
                                {
                                    await _userManager.AddToRoleAsync(user, "SpaUser");
                                }
                                //string callbackUrl1 = "https://www.tradepawa.com";
                                //var text = $". Please go to tradepawa by clicking here: <a href='{callbackUrl1}'>link</a>";

                                await _dbOps.LogAndSendMail(spaUsers.email, "Spa Intl User Account", "Dear " + spaUsers.FirstName + " Your Account Password is " + pass + " and your login email is " + spaUsers.email );
                                await _dbOps.AuditOperation(User.Identity.Name, "SpaUsers/Create", "Added a new Spa User" + spaUsers.spaUserGuid.ToString(), "", "SpaUsers");
                                // return RedirectToAction("Index", "SpaUsers", new { id = spaUsers.spaUserGuid });
                                return RedirectToAction(nameof(Index));
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Email Already Used");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Mobile Number Provided");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email Address");
                }
            }
            catch (Exception ex)
            {
                await _dbOps.LogError("SpaUsers/Create", "Add new Spa User", "", ex.Message.ToString(), object.ReferenceEquals(ex.InnerException, null) ? "" : ex.InnerException.ToString());
            }
            ViewData["spaName"] = _context.SpaDetails.FirstOrDefault(k => k.spaGuid == spaUsers.spaGuid).spaName;
           // ViewData["designation"] = new SelectList(_context.TbDesignations, "designation", "designation", spaUsers.designation);
            return View(spaUsers);
            //if (ModelState.IsValid)
            //{
            //    spaUsers.spaUserGuid = Guid.NewGuid();
            //    _context.Add(spaUsers);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["spaGuid"] = new SelectList(_context.SpaDetails, "spaGuid", "PinNo", spaUsers.spaGuid);
            //return View(spaUsers);
        }

        // GET: SpaUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaUsers = await _context.SpaUsers.SingleOrDefaultAsync(m => m.spaUserGuid == id);
            if (spaUsers == null)
            {
                return NotFound();
            }
            ViewData["spaGuid"] = new SelectList(_context.SpaDetails, "spaGuid", "PinNo", spaUsers.spaGuid);
            return View(spaUsers);
        }

        // POST: SpaUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("spaUserGuid,spaGuid,SirName,FirstName,MiddleName,LastName,contact,email,dob,idType,idNumber,status,regDate,pysicalLoc")] SpaUsers spaUsers)
        {
            if (id != spaUsers.spaUserGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spaUsers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpaUsersExists(spaUsers.spaUserGuid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["spaGuid"] = new SelectList(_context.SpaDetails, "spaGuid", "PinNo", spaUsers.spaGuid);
            return View(spaUsers);
        }

        // GET: SpaUsers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaUsers = await _context.SpaUsers
                .Include(s => s.SpaDetails)
                .SingleOrDefaultAsync(m => m.spaUserGuid == id);
            if (spaUsers == null)
            {
                return NotFound();
            }

            return View(spaUsers);
        }

        // POST: SpaUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var spaUsers = await _context.SpaUsers.SingleOrDefaultAsync(m => m.spaUserGuid == id);
            _context.SpaUsers.Remove(spaUsers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpaUsersExists(Guid id)
        {
            return _context.SpaUsers.Any(e => e.spaUserGuid == id);
        }
    }
}
