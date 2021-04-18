using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Interfaces.Spa;
using Spa_Management.Models;
using Spa_Management.Operations;

namespace Spa_Management.Controllers
{
    public class SpaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly ISpaOperations _spaOperations;
        private readonly UserManager<ApplicationUser> _userManager;
        public SpaController(ApplicationDbContext context, IDbOperations dbOps, ISpaOperations spaOperations, UserManager<ApplicationUser> manager)
        {
            _dbOps = dbOps;
            _context = context;
            _userManager = manager;
            _spaOperations = spaOperations;
        }
        [AllowAnonymous]
        [HttpGet("/GetPostal/{name}")]
        public IActionResult GetPostal(string name)
        {
            string address = "";
            var name2 = int.Parse(name);
            try
            {
                address = _context.tbPostalCodes.AsNoTracking().FirstOrDefault(c => c.Code == name2).RegionName;
                ViewData["postalAddress"] = address;
                address = address ?? "Address";
            }
            catch (Exception ex)
            {

                throw;
            }

            return Content(address);
        }
        // GET: Spa
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.SpaDetails.ToListAsync());
        //}
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewData["spaName"] = String.IsNullOrEmpty(sortOrder) ? "a" : "";
            ViewData["spaReg"] = String.IsNullOrEmpty(sortOrder) ? "b" : "";
            ViewData["spaKra"] = String.IsNullOrEmpty(sortOrder) ? "c" : "";
            ViewData["spaIdNumber"] = String.IsNullOrEmpty(sortOrder) ? "d" : "";
            ViewData["spaLoc"] = String.IsNullOrEmpty(sortOrder) ? "f" : "";
            ViewData["spaPostal"] = String.IsNullOrEmpty(sortOrder) ? "g" : "";
           
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var ApplicationDbContext = _context.SpaDetails.Include(c => c.SpaUsers).AsQueryable();
           
            #region Sort
            switch (sortOrder)
            {
                case "a":
                    ApplicationDbContext = ApplicationDbContext.OrderBy(m => m.spaName);
                    break;
                case "b":
                    ApplicationDbContext = ApplicationDbContext.OrderBy(m => m.RegCertNo);
                    break;
                case "c":
                    ApplicationDbContext = ApplicationDbContext.OrderBy(m => m.PinNo);
                    break;
                case "d":
                    ApplicationDbContext = ApplicationDbContext.OrderBy(m => m.SpaUsers.FirstOrDefault().idNumber);
                    break;
                case "f":
                    ApplicationDbContext = ApplicationDbContext.OrderBy(m => m.pysicalLoc);
                    break;
                case "g":
                    ApplicationDbContext = ApplicationDbContext.OrderBy(m => m.postalAddress);
                    break;
                default:
                    ApplicationDbContext = ApplicationDbContext.OrderByDescending(m => m.regDate);
                    break;
            }
            #endregion

            int pageSize = 400;
            return View(await PaginatedList<SpaDetails>.CreateAsync(ApplicationDbContext.AsNoTracking(), page ?? 1, pageSize));

        }
        // GET: Spa/Details/5
        public async Task<IActionResult> Details(Guid? id, string f = null)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var spaDetails = await _context.SpaDetails
                    .SingleOrDefaultAsync(m => m.spaGuid == id);

                if (spaDetails == null)
                {
                    return NotFound();
                }

                var tbcrb = await _context.TbCRBChecks
                .SingleOrDefaultAsync(m => m.compGuid == id);
                if (spaDetails == null)
                {
                    return NotFound();
                }


                var appliedby = await _dbOps.GetSpaRegistrarDetails(spaDetails);

                SpaBusinessDetails det = new SpaBusinessDetails
                {
                    appliedby = appliedby.sirname,
                    spaDetails = spaDetails,
                    ApplicantAddress = appliedby.email,
                    Contact = appliedby.contact,
                    crb = tbcrb
                };
                if (id == null)
                {
                    return NotFound();
                }
              
                ViewData["Gui"] = det.spaDetails.spaGuid;
                ViewData["SpaGuid"] = det.spaDetails.spaGuid;
                ViewData["State0"] = det.spaDetails.status;
               // ViewData["crbStatus"] = det.crb.status;
                if (!object.ReferenceEquals(f, null))
                {
                    ViewData["SpaDetails"] = f;
                }

                return View(det);
            }

            catch (Exception ex)
            {
                await _dbOps.LogError("Spa/Details", "SpaDetails", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());

            }
            return NotFound();
        }


        [Authorize(Roles = ("MasterAdmin"))]
        public async Task<IActionResult> Verify(string btn, string spaID)
        {
            try
            {
                if (spaID == null)
                {
                    return NotFound();
                }
                Guid gui = Guid.Parse(spaID);

                var spaDet = await _context.SpaDetails
                    .SingleOrDefaultAsync(m => m.spaGuid == gui);

                if (spaDet == null)
                {
                    return NotFound();
                }

                var me = await _userManager.GetUserAsync(HttpContext.User);


                var user = _context.SpaUsers.FirstOrDefault(g => g.spaUserGuid.ToString() == spaDet.registeredBy);
                if (!object.ReferenceEquals(user, null))
                {
                    
                    if (btn == "Verify")
                    {
                        if (spaDet.status == 0)
                        {

                            spaDet.status = 1;
                            var Adduser = new ApplicationUser
                            {
                                UserName = user.email,
                                Email = user.email,
                                spaUserGuid = user.spaUserGuid,
                                PhoneNumber = phoneNumberNomalizer.phoneNum(user.contact),
                                EmailConfirmed = true

                            };
                            //Send Email

                            var pass = _dbOps.GenerateRandomPassword(); 
                            var result = await _userManager.CreateAsync(Adduser, pass);
                            var code = await _userManager.GenerateEmailConfirmationTokenAsync(Adduser);
                            await _userManager.AddToRoleAsync(Adduser, "SPAADMIN");
                            _context.Update(spaDet);
                            await _context.SaveChangesAsync();
                           // String body = " <br /> Click the link here to go to Tradepawa : <a href='https://www.tradepawa.com'></a>";
                            await _dbOps.LogandSendSMS(user.contact, "Dear " + user.FirstName + ", Your Business Registration has been Verified ," + " Your Login Password is " + pass + " and your login email is :" + user.email + " . Kindly keep your password private", "", "", "");
                            await _dbOps.LogAndSendMail(user.email, "Account Password", "Dear " + user.FirstName + ", Your Login Password is " + pass + " and your login email is :" + user.email + " ." + "");
                            return RedirectToAction(nameof(Index));
                        }

                    }
                    if (btn == "Reject")
                    {
                        if (spaDet.status == 0)
                        {

                            spaDet.status = 2;

                            _context.Update(spaDet);
                            await _context.SaveChangesAsync();
                            await _dbOps.LogandSendSMS(user.contact, "Dear " + user.FirstName + " Sorry we could not validate your Business Registration credentials, Please provide valid details", "", "", "");
                            await _dbOps.LogAndSendMail(user.email, "Password", "Dear " + user.FirstName + " Sorry we could not verify your company credentials, Please provide valid details");

                            //Send Email                     
                            return RedirectToAction(nameof(Index));
                        }


                    }
                }

                else
                {
                    return (RedirectToAction("details", new { id = spaID, f = "Applicant Profile is incomplete" }));
                }
                _context.Update(spaDet);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                await _dbOps.LogError("SpaDetails/Verify", "Verify", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());

                return (RedirectToAction("details", new { id = spaID, f = "Error Occured During Verification" }));

            }
        }
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var spaDetails = await _context.SpaDetails
        //        .SingleOrDefaultAsync(m => m.spaGuid == id);
        //    if (spaDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(spaDetails);
        //}

        // GET: Spa/Create
        public IActionResult Create()
        {
            ViewData["idType"] = new SelectList(_context.TbIdTypes.AsNoTracking(), "idType", "idType");
            ViewData["PostalCode"] = new SelectList(_context.tbPostalCodes.OrderBy(c => c.Code).AsNoTracking(), "Code", "Code");
            return View();
        }

        public async Task<IActionResult> Users(Guid? id)
        {
            try
            {
                ViewData["DocumentsVerified"] = true;
                ViewData["DirectorsVerified"] = true;
                ViewData["DirectorsRegistered"] = true;
                ViewData["DocumentsRegistered"] = true;
                if (id == null)
                {
                    return NotFound();
                }
                ViewData["spaGuid"] = id.Value;
                ViewData["spaName"] = _context.SpaDetails.FirstOrDefault(k => k.spaGuid == id).spaName;
                var users = await _context.SpaUsers.Where(h => h.spaGuid == id).ToListAsync();
                if (users == null)
                {
                    return NotFound();
                }
                List<ViewSpaUsers> _spaUsers = new List<ViewSpaUsers>();
                int i = 1;
                foreach (var a in users)
                {
                    ViewSpaUsers user = new ViewSpaUsers()
                    {
                        id = i++,
                        spaUserGuid = a.spaUserGuid,
                        Name = string.Format("{0} {1} {2}", a.SirName, a.FirstName, a.LastName),
                        contact = a.contact,
                        Email = a.email,
                        idNumber = a.idNumber,
                        Role = await _dbOps.GetUserRole(a.spaUserGuid, 4),
                        status = a.status
                    };
                    _spaUsers.Add(user);
                }
                ViewData["spaName"] = _context.SpaDetails.FirstOrDefault(k => k.spaGuid == id).spaName;
                ViewData["spaGuid"] = id;
                //return View(await ApplicationDbContext.ToListAsync());
                return View(_spaUsers);
            }
            catch (Exception ex)
            {

                await _dbOps.LogError("SpaDetails/Users", "Find Users", "", ex.Message.ToString(), ex.InnerException is null ? "" : ex.InnerException.ToString());
                return NotFound();
            }

            //return View(users);
        }



        // POST: Spa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("spaGuid,registeredBy,spaName,email,pysicalLoc,postalAddress,PostalCode,PinNo,RegCertNo,contact,incNum,regDate,status")] SpaDetails spaDetails)
        {
            if (ModelState.IsValid)
            {
                spaDetails.spaGuid = Guid.NewGuid();
                _context.Add(spaDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spaDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SpaSignUp([Bind("spaGuid,registeredBy,spaName,email,pysicalLoc,postalAddress,PostalCode,PinNo,RegCertNo,contact,incNum,regDate,status")] SpaDetails spaDetails, [Bind("spaGuid,spaUserGuid,SirName,MiddleName,FirstName,LastName,contact,email,dob,idType,idNumber,pysicalLoc")] SpaUsers spaUsers)
        {
            try
            {
                string address = "Address";
                ViewData["postalAddress"] = address;

                var BusinessRegistrationResponse = await _spaOperations.RegisterSpa(spaDetails, spaUsers);

                if (string.Equals(BusinessRegistrationResponse.Item2, "The Applicant email is already used") && BusinessRegistrationResponse.Item1 == false)
                {
                    return RedirectToAction(nameof(EmailUsed));
                }
                if (string.Equals(BusinessRegistrationResponse.Item2, "This Spa Is already Registered") && BusinessRegistrationResponse.Item1 == false)
                {
                    return RedirectToAction(nameof(SpaExists));
                }
                if (string.Equals(BusinessRegistrationResponse.Item2, "Successfully Registered Spa") && BusinessRegistrationResponse.Item1 == true)
                {
                    return RedirectToAction(nameof(verify));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
                await _dbOps.LogError("Spa/Create", "Add new Business", "", ex.Message.ToString(), ex.InnerException is null ? "" : ex.InnerException.ToString());
            }
            return RedirectToAction(nameof(verify));
        }




        // GET: Spa/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaDetails = await _context.SpaDetails.SingleOrDefaultAsync(m => m.spaGuid == id);
            if (spaDetails == null)
            {
                return NotFound();
            }
            return View(spaDetails);
        }

        // POST: Spa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("spaGuid,registeredBy,spaName,email,pysicalLoc,postalAddress,PostalCode,PinNo,RegCertNo,contact,incNum,regDate,status")] SpaDetails spaDetails)
        {
            if (id != spaDetails.spaGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spaDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpaDetailsExists(spaDetails.spaGuid))
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
            return View(spaDetails);
        }

        // GET: Spa/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaDetails = await _context.SpaDetails
                .SingleOrDefaultAsync(m => m.spaGuid == id);
            if (spaDetails == null)
            {
                return NotFound();
            }

            return View(spaDetails);
        }

        // POST: Spa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var spaDetails = await _context.SpaDetails.SingleOrDefaultAsync(m => m.spaGuid == id);
            _context.SpaDetails.Remove(spaDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpaDetailsExists(Guid id)
        {
            return _context.SpaDetails.Any(e => e.spaGuid == id);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult verify()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult SpaExists()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult EmailUsed()
        {
            return View();
        }

       
        public class ViewSpaUsers
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

        public class SpaBusinessDetails
        {
            [Display(Name = "Applicant Name")]
            public string appliedby { get; set; }

            [Display(Name = "Applicant Address")]
            public string ApplicantAddress { get; set; }

            [Display(Name = "Mobile Number")]
            public string Contact { get; set; }

            public SpaDetails spaDetails { get; set; }

           public tbCRBChecks crb { get; set; }
         //  public List<tbDirectors> directors { get; set; }
        // public CompanyDocs compDocs { get; set; }


        }
    }
}
