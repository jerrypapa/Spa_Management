using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spa_Management.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spa_Management.Data;
using Microsoft.AspNetCore.Authorization;
using Spa_Management.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Spa_Management.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _dbOps = dbOps;
            _userManager = manager;
        }
        public async Task<IActionResult> Index()
        {
            //return RedirectToAction("Login", "Account");
            
           // ViewData["idType"] = new SelectList(_context.TbIdTypes, "idType", "idType");
          //  ViewData["PostalCode"] = new SelectList(_context.tbPostalCodes.AsNoTracking().OrderBy(c => c.Code), "Code", "Code");
            //var myList = _context.tbPostalCodes.AsNoTracking().ToList().Remove("");
            //foreach(var item in myList)
            //{
            //    item.
            //}
            //  var data = _context.tbPostalCodes.AsNoTracking().OrderByDescending(c => c.Code).ToList();
            //   var data2 = data.FirstOrDefault().Code;
            //   ViewData["PostalCode"] = new SelectList(_context.tbPostalCodes.AsNoTracking().OrderByDescending(c=>c.Code).ToList(), "Code", "Code");
            var me = await _userManager.GetUserAsync(HttpContext.User);
            if (me != null)
            {
                if (User.IsInRole("Spa Admin"))
                {

                }
                if (User.IsInRole("Spa User"))
                {
                    var usr = me.spaUserGuid;

                    var spa = _context.SpaUsers.Include(c=>c.spaRoles).AsNoTracking().FirstOrDefault(c => c.spaUserGuid == usr);
                    var roleId =Guid.Parse(spa.spaRolesId);
                    var roleName_ =_context.SpaRoles.FirstOrDefault(c=>c.Id== roleId);
                    if (roleName_.RoleName.Contains("RECEPTIONIST"))
                    {
                        ViewData["IsReceptionist"] = true;
                    }
                    if (roleName_.RoleName.Contains("ATTENDANT"))
                    {
                        ViewData["IsAttendant"] = true;
                    }
                }


                if (User.IsInRole("CompanyUser") || User.IsInRole("CompanyAdmin"))
                {
                    var userId = me.compUserGuid;
                    var companyId = _context.TbCompanyUsers.FirstOrDefault(c => c.compUserGuid == userId).compGuid;
                    //Optimize querries afterwards
                    var CompanyDirectors = _context.TbDirectors.Where(c => c.CompanyId == companyId && c.OtpVerified==true).ToList();
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
                            var AtleastOnedirectorVerified1 = CompanyDirectors.Count(d => d.Verified == true && d.OtpVerified==true);
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
                            //Since both are now registered..Check their approval status
                            //
                            ViewData["DirectorsRegistered"] = true; //should be maintained as true
                            ViewData["DocumentsVerified"] = false;
                            ViewData["DirectorsVerified"] = false;
                            ViewData["DocumentsRegistered"] = true;//maintain as true

                            var AtleastOnedirectorVerified = CompanyDirectors.Count(d => d.Verified == true && d.OtpVerified==true);
                            var DocsApproved = companyDocuments.Verified;

                            if (AtleastOnedirectorVerified > 0 && DocsApproved == true)
                            {
                                ViewData["DocumentsVerified"] = true;
                                ViewData["DirectorsVerified"] = true;
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
                            }

                        }
                        if (await _dbOps.GetCompanyUserAccountStatus(me.compUserGuid) != 0)
                        {
                            //return RedirectToAction(nameof(UnVerified));
                            return RedirectToAction("UnVerified", "Account");
                        }
                    }
                    if (User.IsInRole("Individual"))
                    {
                        if (await _dbOps.GetIndUserAccountStatus(me.indGuid) != 0)
                        {
                            return RedirectToAction("UnVerified", "Account");
                        }
                    }
                }
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public async Task<IActionResult> CompanySignUp()
        {
            //return RedirectToAction("Login", "Account");
            ViewData["idType"] = new SelectList(_context.TbIdTypes, "idType", "idType");
            // ViewData["PostalCode"] = new SelectList(_context.tbPostalCodes, "Code", "Code");
            ViewData["PostalCode"] = new SelectList(_context.tbPostalCodes.AsNoTracking().OrderBy(c => c.Code), "Code", "Code");
           // ViewData["PostalCode"] = new SelectList(_context.tbPostalCodes.AsNoTracking().OrderByDescending(c => c.Code).ToList(), "Code", "Code");
            var me = await _userManager.GetUserAsync(HttpContext.User);
            if (me != null)
            {
                if (User.IsInRole("CompanyUser") || User.IsInRole("CompanyAdmin"))
                {
                    var userId = me.compUserGuid;
                    var companyId = _context.TbCompanyUsers.FirstOrDefault(c => c.compUserGuid == userId).compGuid;
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
                            //Since both are now registered..Check their approval status
                            //
                            ViewData["DirectorsRegistered"] = true; //should be maintained as true
                            ViewData["DocumentsVerified"] = false;
                            ViewData["DirectorsVerified"] = false;
                            ViewData["DocumentsRegistered"] = true;//maintain as true

                            var AtleastOnedirectorVerified = CompanyDirectors.Count(d => d.Verified == true && d.OtpVerified == true);
                            var DocsApproved = companyDocuments.Verified;

                            if (AtleastOnedirectorVerified > 0 && DocsApproved == true)
                            {
                                ViewData["DocumentsVerified"] = true;
                                ViewData["DirectorsVerified"] = true;
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
                            }

                        }
                        if (await _dbOps.GetCompanyUserAccountStatus(me.compUserGuid) != 0)
                        {
                            //return RedirectToAction(nameof(UnVerified));
                            return RedirectToAction("UnVerified", "Account");
                        }
                    }
                    if (User.IsInRole("Individual"))
                    {
                        if (await _dbOps.GetIndUserAccountStatus(me.indGuid) != 0)
                        {
                            return RedirectToAction("UnVerified", "Account");
                        }
                    }
                }
            }
            return View();
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacy";

            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Terms()
        {
            ViewData["Title"] = "Terms";

            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult FaQs()
        {
            ViewData["Title"] = "FaQs";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
