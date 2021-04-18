using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Models;
using Spa_Management.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace Spa_Management.Controllers
{
    public class tbDirectorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOperations;
        private readonly UserManager<ApplicationUser> _userManager;
        public tbDirectorsController(ApplicationDbContext context,IDbOperations dbOperations,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _dbOperations = dbOperations;
            _userManager = userManager;
        }

        //public async Task<IActionResult> Index(int id)
        //{
        //    var ApplicationDbContext = id == 0 ? _context.TbCompanies : _context.TbCompanies.AsNoTracking().Where(c => c.status == 0);/*.AsNoTracking().FirstOrDefault(c=>c.status==0)*/;
        //    return View(await ApplicationDbContext.ToListAsync());
        //}

        // GET: tbDirectors
        public async Task<IActionResult> Index(int id)
        {
            if (User.IsInRole("CompanyAdmin") || User.IsInRole("MasterAdmin"))
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);


                if (User.IsInRole("CompanyUser") || User.IsInRole("CompanyAdmin"))
                {
                    var userId = me.compUserGuid;
                    var companyId = _context.TbCompanyUsers.FirstOrDefault(c => c.compUserGuid == userId).compGuid;
                    ViewData["Gui"] = companyId;
                    

                    //ViewBag.State0
                    // var companyId = _context.TbCompanyUsers.FirstOrDefault(c => c.compUserGuid == userId).compGuid;  There is an error here

                    //Optimize querries afterwards
                    var CompanyDirectors = _context.TbDirectors.Where(c => c.CompanyId == companyId && c.OtpVerified == true).ToList();
                    if (CompanyDirectors.Count() > 0)
                    {
                        if (CompanyDirectors.FirstOrDefault().Verified == false)
                        {
                            ViewData["State0"] = 0;
                        }
                    }

                   
                       

                    var companyDocuments = _context.TbCompanyDocs.FirstOrDefault(c => c.CompanyId == companyId);
                    if (CompanyDirectors.Count() <= 0)
                    {

                        //Flag with correct details
                        ViewData["DirectorsRegistered"] = false; //should be false after test
                        ViewData["DocumentsVerified"] = false;
                        ViewData["DirectorsVerified"] = false;
                        ViewData["DocumentsRegistered"] = false;


                        //Redirect To Registration Page for Directors
                    }
                    else
                    {

                        if (companyDocuments == null)
                        {
                            var AtleastOnedirectorVerified1 = CompanyDirectors.Count(d => d.Verified == true && d.OtpVerified == true);
                            if (AtleastOnedirectorVerified1 > 0)
                            {
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DirectorsVerified"] = true;
                            }
                            else
                            {
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DirectorsVerified"] = false;
                            }
                            ViewData["DocumentsVerified"] = false;

                            ViewData["DocumentsRegistered"] = false;
                        }
                        else
                        {


                            var AtleastOnedirectorVerified = CompanyDirectors.Count(d => d.Verified == true && d.OtpVerified == true);
                            var DocsApproved = companyDocuments.Verified;

                            if (AtleastOnedirectorVerified > 0 && DocsApproved == true)
                            {
                                ViewData["DocumentsVerified"] = true;
                                ViewData["DirectorsVerified"] = true;
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DocumentsRegistered"] = DocsApproved;
                            }
                            else
                            {
                                bool dirAppr = true;
                                if (AtleastOnedirectorVerified <= 0)
                                {
                                    dirAppr = false;
                                }

                                ViewData["DocumentsVerified"] = DocsApproved;
                                ViewData["DirectorsVerified"] = dirAppr;
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DocumentsRegistered"] = true;
                            }

                        }
                      
                     }
                }

                IQueryable < tbDirectors > ApplicationDbContext=null;
                if (User.IsInRole("MasterAdmin"))
                {
                  ApplicationDbContext = id == 0 ? _context.TbDirectors.Where(k => k.OtpVerified == true) : _context.TbDirectors.Where(k => k.OtpVerified == true && k.Verified == false);

                   

                }
                else
                {
                    var id2 = _context.TbCompanyUsers.FirstOrDefault(j => j.compUserGuid == me.compUserGuid).compGuid;
                     ApplicationDbContext = _context.TbDirectors.Where(k => k.CompanyId == id2 && k.OtpVerified == true);
                }
                   // var ApplicationDbContext = id == 0 ? _context.TbDirectors.Where(k => k.CompanyId == id2 && k.OtpVerified == true) : _context.TbDirectors.Where(k => k.CompanyId == id2 && k.OtpVerified == true&&k.Verified==false);
           //  var ApplicationDbContext = _context.TbDirectors.Where(k => k.CompanyId == id && k.OtpVerified==true);
                //var directors = _context.TbDirectors.Where(k => k.CompanyId == id && k.OtpVerified == true).ToList();
                List<ViewcompanyDirectors> _CompUsers = new List<ViewcompanyDirectors>();
                int i = 1;
                foreach (var a in ApplicationDbContext)
                {
                    ViewcompanyDirectors user = new ViewcompanyDirectors()
                    {
                        id = i++,
                        DirectorId = a.Id,
                        FirstName = a.FirstName,
                        LastName=a.LastName,
                        TelephoneNumber = a.TelephoneNumber,
                        Email = a.Email,
                        idNumber = a.IdNumber,
                        
                        CompanyName= _context.TbCompanies.FirstOrDefault(k => k.compGuid == a.CompanyId).compName,
                       // Role = await _dbOperations.GetUserRole(a.compUserGuid, 1),
                        Verified = a.Verified
                    };
                    _CompUsers.Add(user);

                    if (a.Verified == false)
                    {
                        ViewData["State0"] = 0;
                    }
                    ViewData["Gui"] = a.CompanyId;
                }
                if (User.IsInRole("CompanyAdmin"))
                {
                    var id2 = _context.TbCompanyUsers.FirstOrDefault(j => j.compUserGuid == me.compUserGuid).compGuid;
                    ViewData["CompanyName"] = _context.TbCompanies.FirstOrDefault(k => k.compGuid == id2).compName;
                    ViewData["compGuid"] = id2;
                }
                else
                {
                    ViewData["CompanyName"] = _context.TbCompanies.FirstOrDefault(k => k.compGuid == ApplicationDbContext.FirstOrDefault().CompanyId).compName;
                    ViewData["compGuid"] = id;
                }
                    
              
               
                //return View(await ApplicationDbContext.ToListAsync());
                return View(_CompUsers);
            }
            return new ForbidResult();

            //return View(await _context.TbDirectors.ToListAsync());
        }

        // GET: tbDirectors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDirectors = await _context.TbDirectors
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbDirectors == null)
            {
                return NotFound();
            }

            return View(tbDirectors);
        }

        // GET: tbDirectors/Create
        public async Task<IActionResult> Create()
        {
            var me =  await _userManager.GetUserAsync(HttpContext.User);

            if (me == null){
                return RedirectToAction(nameof(Index),"home");
            }
            if (User.IsInRole("CompanyAdmin"))
            {
                if (User.IsInRole("CompanyUser") || User.IsInRole("CompanyAdmin"))
                {
                    var userId = me.compUserGuid;
                    var companyId = _context.TbCompanyUsers.FirstOrDefault(c => c.compUserGuid == userId).compGuid;

                    // var companyId = _context.TbCompanyUsers.FirstOrDefault(c => c.compUserGuid == userId).compGuid;  There is an error here

                    //Optimize querries afterwards
                    var CompanyDirectors = _context.TbDirectors.Where(c => c.CompanyId == companyId && c.OtpVerified == true).ToList();
                    var companyDocuments = _context.TbCompanyDocs.FirstOrDefault(c => c.CompanyId == companyId);
                    if (CompanyDirectors.Count() <= 0)
                    {

                        //Flag with correct details
                        ViewData["DirectorsRegistered"] = false; //should be false after test
                        ViewData["DocumentsVerified"] = false;
                        ViewData["DirectorsVerified"] = false;
                        ViewData["DocumentsRegistered"] = false;


                        //Redirect To Registration Page for Directors
                    }
                    else
                    {

                        if (companyDocuments == null)
                        {
                            var AtleastOnedirectorVerified1 = CompanyDirectors.Count(d => d.Verified == true && d.OtpVerified == true);
                            if (AtleastOnedirectorVerified1 > 0)
                            {
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DirectorsVerified"] = true;
                            }
                            else
                            {
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DirectorsVerified"] = false;
                            }
                            ViewData["DocumentsVerified"] = false;

                            ViewData["DocumentsRegistered"] = false;
                        }
                        else
                        {


                            var AtleastOnedirectorVerified = CompanyDirectors.Count(d => d.Verified == true && d.OtpVerified == true);
                            var DocsApproved = companyDocuments.Verified;

                            if (AtleastOnedirectorVerified > 0 && DocsApproved == true)
                            {
                                ViewData["DocumentsVerified"] = true;
                                ViewData["DirectorsVerified"] = true;
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DocumentsRegistered"] = DocsApproved;
                            }
                            else
                            {
                                bool dirAppr = true;
                                if (AtleastOnedirectorVerified <= 0)
                                {
                                    dirAppr = false;
                                }

                                ViewData["DocumentsVerified"] = DocsApproved;
                                ViewData["DirectorsVerified"] = dirAppr;
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DocumentsRegistered"] = true;
                            }

                        }

                    }
                }
            }

                ViewData["CompanyId"] = new SelectList(_context.TbCompanies.Where(C=>C.registeredBy==me.compUserGuid.ToString()), "compName", "compName");
            var x = new SelectList(_context.TbCompanies, "CompanyId", "compName");
            ViewData["idType"] = new SelectList(_context.TbIdTypes, "idType", "idType");
            return View();
        }

        // POST: tbDirectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,TelephoneNumber,IdNumber,Maker,Checker,CheckerComments,checkerDate,Dob,IdType")] tbDirectors tbDirectors)
        {
            //([Bind("Id,CompanyId,Verified,FirstName,LastName,Email,TelephoneNumber,IdNumber,Maker,Checker,CheckerComments,checkerDate,Dob,IdType")] tbDirectors tbDirectors)
            if (ModelState.IsValid)
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
                if (User.IsInRole("Individual"))
                {
                    //return View(await ApplicationDbContext.Where(y => y.indGuid == me.indGuid).ToListAsync());
                  //  ApplicationDbContext = ApplicationDbContext.Where(y => y.indGuid == me.indGuid).Include(t => t.tbSystemBanks);
                }
                if (User.IsInRole("CompanyUser") || User.IsInRole("CompanyAdmin"))
                {
                    var company = _context.TbCompanyUsers.FirstOrDefault(j => j.compUserGuid == me.compUserGuid).compGuid;
                    tbDirectors.CompanyId = company;
                    //return View(await _context.TbApplications.Where(y => y.compGuid == company).ToListAsync());
                    // ApplicationDbContext = ApplicationDbContext.Where(y => y.compGuid == company).Include(t => t.tbSystemBanks);
                }
                if (User.IsInRole("BankUser") || User.IsInRole("BankAdmin"))
                {
                    var bank = _context.TbBankUsers.FirstOrDefault(o => o.bankUserGuid == me.bankUserGuid).SystemBanksGuid;
                    //return View(await _context.TbApplications.Where(y => y.SystemBanksGuid == bank).ToListAsync());
                   // ApplicationDbContext = ApplicationDbContext.Where(y => y.SystemBanksGuid == bank).Include(t => t.tbSystemBanks);
                }
                tbDirectors.Maker = Guid.Parse(me.Id);
               
                var res=await _dbOperations.AddDirector(tbDirectors);
                if (!string.Equals("Success", res.Item2))
                {
                    ModelState.AddModelError("", res.Item2);
                }
                else
                {
                    return RedirectToAction(nameof(Verify));
                }
                //  tbDirectors.Id = Guid.NewGuid();
                //   _context.Add(tbDirectors);
                //   await _context.SaveChangesAsync();
               

                // return RedirectToAction(nameof(Index));
            }
            return View(tbDirectors);
        }

        // GET: tbDirectors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDirectors = await _context.TbDirectors.SingleOrDefaultAsync(m => m.Id == id);
            if (tbDirectors == null)
            {
                return NotFound();
            }
            var me = await _userManager.GetUserAsync(HttpContext.User);
            ViewData["CompanyId"] = new SelectList(_context.TbCompanies.Where(C => C.registeredBy == me.compUserGuid.ToString()), "compName", "compName");
            var x = new SelectList(_context.TbCompanies, "CompanyId", "compName");
            ViewData["idType"] = new SelectList(_context.TbIdTypes, "idType", "idType");
            return View(tbDirectors);
        }

        // POST: tbDirectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CompanyId,Verified,FirstName,LastName,Email,TelephoneNumber,IdNumber,Maker,Checker,CheckerComments,checkerDate,Dob,IdType")] tbDirectors tbDirectors)
        {
            if (id != tbDirectors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDirectors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbDirectorsExists(tbDirectors.Id))
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
            return View(tbDirectors);
        }

        // GET: tbDirectors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDirectors = await _context.TbDirectors
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbDirectors == null)
            {
                return NotFound();
            }

            return View(tbDirectors);
        }

        // POST: tbDirectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tbDirectors = await _context.TbDirectors.SingleOrDefaultAsync(m => m.Id == id);
            _context.TbDirectors.Remove(tbDirectors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Verify()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> verifyOtp(Guid id, [Bind("Otp")] tbOtpVerify tbOtpVerify)
        {

            tbOtpVerify otp =  _context.Otp.FirstOrDefault(m => m.Otp == tbOtpVerify.Otp);


            if (ModelState.IsValid)
            {
                //Check if otp exists
                //if yes is it used?
                //if no is it matching?
                //
                if (otp == null)
                {
                    var toDelete = _context.TbDirectors.FirstOrDefault(c => c.Id == otp.UserId);
                    //_context.TbDirectors.Remove(toDelete);
                    //await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(InvalidOtp));
                }
                else
                {
                    if (otp.Used == false)
                    {
                        otp.Used = true;
                        _context.Otp.Update(tbOtpVerify);
                        await _context.SaveChangesAsync();
                        //var update directors

                        var toUpdate = _context.TbDirectors.FirstOrDefault(c => c.Id == otp.UserId);
                        toUpdate.OtpVerified = true;
                        await _context.SaveChangesAsync();
                        var me = await _userManager.GetUserAsync(HttpContext.User);
                        var userId = me.compUserGuid;
                        var companyId = _context.TbCompanyUsers.FirstOrDefault(c => c.compUserGuid == userId).compGuid;

                        var CompanyDirectors = _context.TbDirectors.Where(c => c.CompanyId == companyId && c.OtpVerified == true).ToList();

                        if (CompanyDirectors.Count() > 0)
                        {
                            return RedirectToAction(nameof(Index), "mer");
                        }
                        else
                        {
                            return RedirectToAction(nameof(Index));
                        }

                    
                    }
                  
                }
            }
            return View(tbOtpVerify);
        }
        public IActionResult InvalidOtp()
        {
            return View();
        }

    private bool tbDirectorsExists(Guid id)
        {
            return _context.TbDirectors.Any(e => e.Id == id);
        }
        public class ViewcompanyDirectors
        {
            public int id { get; set; }
            public Guid DirectorId { get; set; }

            public string FirstName { get; set; }
            public string LastName { get; set; }

            [Display(Name = "Mobile Number")]
            public string TelephoneNumber { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "ID NO")]
            public string idNumber { get; set; }
            public string CompanyName { get; set; }

            public string Role { get; set; }

            public bool Verified { get; set; }
        }
    }
}
