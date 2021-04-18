using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Models;
using Microsoft.AspNetCore.Identity;
using Spa_Management.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using Spa_Management.Operations;

namespace Spa_Management.Controllers
{
    public class BeneficiariesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly UserManager<ApplicationUser> _userManager;
        public BeneficiariesController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> manager)
        {
            _dbOps = dbOps;
            _context = context;
            _userManager = manager;


        }

        // GET: Beneficiaries
        public async Task<IActionResult> Index()
        {
           var ApplicationDbContext = _context.TbBeneficiaries;
           return View(await ApplicationDbContext.ToListAsync()); 
            // return View(await _context.TbBeneficiaries.ToListAsync());
        }

        // GET: Beneficiaries/Details/5
        public async Task<IActionResult> Details(Guid? id, string f = null)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbbeneficiaries = await _context.TbBeneficiaries
                     .SingleOrDefaultAsync(m => m.institutionGuid == id);
                if (tbbeneficiaries == null)
                {
                    return NotFound();
                }

                //var tbcrb = await _context.TbCRBChecks
                //.SingleOrDefaultAsync(m => m.compGuid == id);
                //if (tbCompanies == null)
                //{
                //    return NotFound();
                //}


                var appliedby = await _dbOps.GetBeneficiaryRegistrarDetails(tbbeneficiaries);

                BeneficiaryDetails det = new BeneficiaryDetails
                {
                    appliedby = appliedby.sirname,
                    beneficiaries = tbbeneficiaries,
                    ApplicantAddress = appliedby.email,
                    Contact = appliedby.contact,
                   // crb = tbcrb

                };

                ViewData["Gui"] = det.beneficiaries.registeredBy;
                ViewData["benefGuid"] = det.beneficiaries.institutionGuid;
                ViewData["State0"] = det.beneficiaries.status;
                // ViewData["crbStatus"] = det.crb.status;
                if (!object.ReferenceEquals(f, null))
                {
                    ViewData["BeneficiaryDetails"] = f;
                }

                return View(det);
            }

            catch (Exception ex)
            {
                await _dbOps.LogError("Companies/Details", "CompanyDetails", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());

            }
            return NotFound();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var tbBeneficiaries = await _context.TbBeneficiaries
            //    .SingleOrDefaultAsync(m => m.institutionGuid == id);
            //if (tbBeneficiaries == null)
            //{
            //    return NotFound();
            //}

            //return View(tbBeneficiaries);
        }
        public async Task<IActionResult> Users(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //ViewData["BankGuid"] = id.Value;
            ViewData["institutionGuid"] = id.Value;
            var inst = _context.TbBeneficiaries.FirstOrDefault(k => k.institutionGuid == id);
            ViewData["InstitutionName"] = _context.TbBeneficiaries.FirstOrDefault(k => k.institutionGuid == id).InstitutionName;
           
            var users = await _context.TbBeneficiaryEmployees.Where(h => h.institutionGuid == id).ToListAsync();
            //.SingleOrDefaultAsync(m => m.SystemBanksGuid == id);
            if (users == null)
            {
                return NotFound();
            }
            List<ViewBeneficiaryEmployees> _BenefUsers = new List<ViewBeneficiaryEmployees>();
            int i = 1;
            foreach (var a in users)
            {
                ViewBeneficiaryEmployees user = new ViewBeneficiaryEmployees()
                {
                    id = i++,
                    userGuid = a.userGuid,
                    Name = string.Format("{0} {1} {2}", a.SirName, a.FirstName, a.LastName),
                    contact = a.contact,
                    Email = a.email,
                    idNumber = a.idNumber,
                    Role = await _dbOps.GetUserRole(a.userGuid, 3),
                    status = a.status
                };
                _BenefUsers.Add(user);
            }
            ViewData["InstitutionName"] = _context.TbBeneficiaries.FirstOrDefault(k => k.institutionGuid == id).InstitutionName;
            ViewData["institutionGuid"] = id;
            //return View(await ApplicationDbContext.ToListAsync());
            return View(_BenefUsers);
            //return View(users);
        }

        // GET: Beneficiaries/Create
        public IActionResult Create()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult verify()
        {
            return View();
        }
        // POST: Beneficiaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("institutionGuid,registeredBy,InstitutionName,email,pysicalLoc,postalAddress,contact,regDate,status")] tbBeneficiaries tbBeneficiaries)
        {
            if (ModelState.IsValid)
            {
                tbBeneficiaries.institutionGuid = Guid.NewGuid();
                _context.Add(tbBeneficiaries);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbBeneficiaries);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BeneficiarySignUp([Bind("institutionGuid,registeredBy,InstitutionName,email,pysicalLoc,postalAddress,contact,regDate,status")] tbBeneficiaries tbBeneficiaries, [Bind("userGuid,institutionGuid,RoleId,designation,SirName,FirstName,MiddleName,LastName,contact,email,NationCode,dob,idType,idNumber,status,regDate")] tbBeneficiaryEmployees tbBeneficiaryEmployees)
        {
            try
            {
                tbBeneficiaries benef = await _context.TbBeneficiaries.SingleOrDefaultAsync(m => m.InstitutionName == tbBeneficiaries.InstitutionName
                && m.contact == tbBeneficiaries.contact && m.email == tbBeneficiaries.email);
                tbBeneficiaries.status = 0;
                tbBeneficiaries.regDate = DateTime.Now;
                if (benef != null)
                {
                    ModelState.AddModelError(string.Empty, "This Institution already exists");
                    return View(tbBeneficiaries);
                }
                else
                {
                    tbBeneficiaries.institutionGuid = Guid.NewGuid();

                    var users = new tbBeneficiaryEmployees()
                    {
                        institutionGuid = tbBeneficiaries.institutionGuid,
                        userGuid = tbBeneficiaryEmployees.userGuid,
                        SirName = tbBeneficiaryEmployees.FirstName,
                        FirstName = tbBeneficiaryEmployees.FirstName,
                        LastName = tbBeneficiaryEmployees.LastName,
                        contact = phoneNumberNomalizer.phoneNum(tbBeneficiaryEmployees.contact),
                        email = tbBeneficiaryEmployees.email,
                        idNumber = tbBeneficiaryEmployees.idNumber,
                        status = 0
                    };
                    _context.TbBeneficiaryEmployees.Add(users);
                    tbBeneficiaries.registeredBy = users.userGuid.ToString();
                    _context.Add(tbBeneficiaries);
                    await _context.SaveChangesAsync();
                    //await _dbOps.LogandSendSMS(users.contact, "Dear " + users.SirName + " Thank you for registering your Institution with us. You will receive an email notification once your details have been verified", "", "", "");
                    //await _dbOps.LogAndSendMail(users.email, "Beneficiary Institution Registration", "Dear " + users.SirName + " Thank you for registering your Institution with us. You will receive an email notification once your details have been verified");
                    await _dbOps.AuditOperation(tbBeneficiaryEmployees.userGuid.ToString(), "Beneficiaries/Create", "Added a new Beneficiary " + tbBeneficiaries.institutionGuid.ToString(), "", "Beneficiaries");
                    return RedirectToAction(nameof(verify));
                }

            }
            catch (Exception ex)
            {
                await _dbOps.LogError("Companies/Create", "Add new company", "", ex.Message.ToString(), ex.InnerException is null ? "" : ex.InnerException.ToString());
                // return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            //ViewData["BankCode"] = new SelectList(_context.TbBanks, "BankCode", "bank", tbCompanies.BankCode);
            //ViewData["branchCode"] = new SelectList(_context.TbBranches, "branchCode", "branch", tbCompanies.branchCode);
            return View(tbBeneficiaries);
        }

        //1.Otp for Directors---10-10.30
        //2.Relink pages---12.30---1pm
        //3.Email configs----10.30-11
        //4.Make new application--Zoom it--11-11.20
        //5.Tc....launch i new url---11-1120
        //6.Edit application?--1120-11.40
        //7.Add beneficiaries given--
        //8.Admin to see apps sent to bank--11.40--1200
        //9.Incomplete user profile?--1200--1230



        // GET: Beneficiaries/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBeneficiaries = await _context.TbBeneficiaries.SingleOrDefaultAsync(m => m.institutionGuid == id);
            if (tbBeneficiaries == null)
            {
                return NotFound();
            }
            return View(tbBeneficiaries);
        }

        // POST: Beneficiaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("compGuid,registeredBy,InstitutionName,email,pysicalLoc,postalAddress,contact,regDate,status")] tbBeneficiaries tbBeneficiaries)
        {
            if (id != tbBeneficiaries.institutionGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbBeneficiaries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbBeneficiariesExists(tbBeneficiaries.institutionGuid))
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
            return View(tbBeneficiaries);
        }

        // GET: Beneficiaries/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBeneficiaries = await _context.TbBeneficiaries
                .SingleOrDefaultAsync(m => m.institutionGuid == id);
            if (tbBeneficiaries == null)
            {
                return NotFound();
            }

            return View(tbBeneficiaries);
        }

        // POST: Beneficiaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                var tbBeneficiaries = await _context.TbBeneficiaries.SingleOrDefaultAsync(m => m.institutionGuid == id);
                _context.TbBeneficiaries.Remove(tbBeneficiaries);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                await _dbOps.LogError("Beneficiaries/DeleteConfirmed", "Delete", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());

            }
            return NotFound();

        }

        private bool tbBeneficiariesExists(Guid id)
        {
            return _context.TbBeneficiaries.Any(e => e.institutionGuid == id);
        }
        [Authorize(Roles = ("MasterAdmin"))]
        public async Task<IActionResult> Verify(string btn, string benefID)
        {
            try
            {
                if (benefID == null)
                {
                    return NotFound();
                }
                Guid gui = Guid.Parse(benefID);

                var tbbenefs = await _context.TbBeneficiaries
                    .SingleOrDefaultAsync(m => m.institutionGuid == gui);

                if (tbbenefs == null)
                {
                    return NotFound();
                }

                var me = await _userManager.GetUserAsync(HttpContext.User);


                var user = _context.TbBeneficiaryEmployees.FirstOrDefault(g => g.institutionGuid == gui);
                if (!object.ReferenceEquals(user, null))
                {
                    // var profile = _context.Users.FirstOrDefault(j => j.Id == user.systemID);
                    if (btn == "Verify")
                    {
                        if (tbbenefs.status == 0)
                        {

                            tbbenefs.status = 1;
                            var Adduser = new ApplicationUser
                            {
                                UserName = user.email,
                                Email = user.email,
                                userGuid = user.userGuid,
                                PhoneNumber = phoneNumberNomalizer.phoneNum(user.contact),
                                EmailConfirmed = true
                            };
                            //Send Email

                            var pass = _dbOps.GenerateRandomPassword(); // + "aA1@";
                            var result = await _userManager.CreateAsync(Adduser, pass);
                            var code = await _userManager.GenerateEmailConfirmationTokenAsync(Adduser);
                            //var callbackUrl = Url.EmailConfirmationLink(Adduser.Id, code, Request.Scheme);
                            //_dbOps.LogAndSendMail(user.email, "Email Confirmation", callbackUrl);
                            await _userManager.AddToRoleAsync(Adduser, "BeneficiaryAdmin");
                            await _dbOps.LogandSendSMS(user.contact, "Dear " + user.SirName + " Your Institution has been Verified ," + " Your Account Password is " + pass + "  Kindly keep your password private", "", "", "");
                            await _dbOps.LogAndSendMail(user.email, "Password", "Dear " + user.SirName + " Your Account Password is " + pass + "  Kindly keep your password private");
                            _context.Update(tbbenefs);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }

                    }
                    if (btn == "Reject")
                    {
                        if (tbbenefs.status == 0)
                        {

                            tbbenefs.status = 2;

                            _context.Update(tbbenefs);
                            await _context.SaveChangesAsync();
                            await _dbOps.LogandSendSMS(user.contact, "Dear " + user.SirName + " Sorry we could not validate your Institution credentials, Please provide valid details", "", "", "");
                            await _dbOps.LogAndSendMail(user.email, "Password", "Dear " + user.SirName + " Sorry we could not verify your Institution credentials, Please provide valid details");

                            //Send Email                     
                            return RedirectToAction(nameof(Index));
                        }


                    }
                }

                else
                {
                    return (RedirectToAction("details", new { id = benefID, f = "Cannot find Master Admin for the company" }));
                    //_dbOps.LogNotification(profile.Id, 1, "Your Application has been Approved final Step, Proceed to Check out");
                }
                _context.Update(tbbenefs);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                throw ex;
                //_dbOps.logError("Companies/Verify", "Verify", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());

            }
            //return NotFound();
        }
        public class ViewBeneficiaryEmployees
        {
            public int id { get; set; }
            public Guid userGuid { get; set; }
            [Display(Name = "Surname")]
            public string SirName { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Middle Name")]
            public string MiddleName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            public string Name { get; set; }
            [Display(Name = "Mobile Number")]
            public string contact { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }
            //[Required]
            [Display(Name = "DOB")]
            public DateTime dob { get; set; }
            [Display(Name = "ID NO")]
            public string idNumber { get; set; }
            public string Role { get; set; }
            public int status { get; set; }
        }

        public class BeneficiaryDetails
        {
            [Display(Name = "Applicant Name")]
            public string appliedby { get; set; }

            [Display(Name = "Applicant Address")]
            public string ApplicantAddress { get; set; }

            [Display(Name = "Mobile Number")]
            public string Contact { get; set; }

            public tbBeneficiaries beneficiaries { get; set; }

           // public tbCRBChecks crb { get; set; }


        }
        public class applicationDetails
        {
            [Display(Name = "Applicant Name")]
            public string appliedby { get; set; }
            public tbApplications aplication { get; set; }
            public List<tbApplicationDocs> docs { get; set; }
            public tbCRBChecks crb { get; set; }

            [Display(Name = "Approved By")]
            public string approvedby { get; set; }

            [Display(Name = "Checked By")]
            public string checkedby { get; set; }

            [Display(Name = "Applicant Address")]
            public string ApplicantAddress { get; set; }

            [Display(Name = "Beneficiary Name")]
            public string BenefName { get; set; }

            [Display(Name = "Beneficiary Address")]
            public string BenefAddress { get; set; }
        }
    }
}
