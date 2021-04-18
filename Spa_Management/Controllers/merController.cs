using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Models;
using Spa_Management.Operations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Spa_Management.Controllers
{
    public class merController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly ICurrencies _currencies;
        private readonly UserManager<ApplicationUser> _userManager;
        public merController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> manager, ICurrencies currencies)
        {
            _context = context;
            _dbOps = dbOps;
            _userManager = manager;
            _currencies = currencies;
        }
        public async Task<IActionResult >Index()
        {
            //ViewData["DirectorsRegistered"] = true; //should be false after test
            //ViewData["DocumentsVerified"] = true;
            //ViewData["DirectorsVerified"] = true;
            //ViewData["DocumentsRegistered"] = true;


            var me = await _userManager.GetUserAsync(HttpContext.User);

            if (User.IsInRole("Spa Admin"))
            {

            }
            if (User.IsInRole("Spa User"))
            {
                var usr = me.spaUserGuid;

                var spa = _context.SpaUsers.Include(c => c.spaRoles).AsNoTracking().FirstOrDefault(c => c.spaUserGuid == usr);
                var roleId = Guid.Parse(spa.spaRolesId);
                var roleName_ = _context.SpaRoles.FirstOrDefault(c => c.Id == roleId);
                if (roleName_.RoleName.Contains("RECEPTIONIST"))
                {
                    ViewData["IsReceptionist"] = true;
                }
                if (roleName_.RoleName.Contains("ATTENDANT"))
                {
                    ViewData["IsAttendant"] = true;
                }
            }
            //if (User.IsInRole("Spa User"))
            //{
            //    var userId = me.spaUserGuid;
            //    var spaId = _context.SpaUsers.AsNoTracking().FirstOrDefault(c => c.spaUserGuid == userId);


            //}
            //if (User.IsInRole("Spa User"))
            //{

            //}
            //Combine this into a personal defined Annotation 
            if (User.IsInRole("BankUser") || User.IsInRole("BankAdmin"))
            {
                if (await _dbOps.GetBankUserAccountStatus(me.bankUserGuid) != 0)
                {
                    return RedirectToAction("UnVerified", "Account");
                }
            }
            if (User.IsInRole("CompanyUser") || User.IsInRole("CompanyAdmin"))
            {
                var userId = me.compUserGuid;
                var companyId = _context.TbCompanyUsers.FirstOrDefault(c => c.compUserGuid == userId).compGuid;

               // var companyId = _context.TbCompanyUsers.FirstOrDefault(c => c.compUserGuid == userId).compGuid;  There is an error here

                //Optimize querries afterwards
                var CompanyDirectors = _context.TbDirectors.Where(c => c.CompanyId == companyId && c.OtpVerified==true).ToList();
                var companyDocuments = _context.TbCompanyDocs.FirstOrDefault(c => c.CompanyId == companyId);
                if (CompanyDirectors.Count() <=0 )
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
                     

                        var AtleastOnedirectorVerified = CompanyDirectors.Count(d => d.Verified == true && d.OtpVerified==true);
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
            if (User.IsInRole("Individual"))
            {
                ViewData["ApprovedOrders"] = _context.TbApplications.Where(j => j.indGuid == me.indGuid && j.status == 1).Count();
            }
            if (User.IsInRole("CompanyUser") || User.IsInRole("CompanyAdmin"))
            {
                tbCompanyUsers compUser = null;
                if (me.compUserGuid != null)
                {
                    compUser = _context.TbCompanyUsers.FirstOrDefault(k => k.compUserGuid == me.compUserGuid);
                }
              
                var appr= _context.TbApplications.Where(j => j.compGuid == compUser.compGuid && j.status == 1).Count();
                ViewData["ApprovedOrders"] = _context.TbApplications.Where(j => j.compGuid == compUser.compGuid && j.status == 1).Count();
                ViewData["TotalApplications"] = _context.TbApplications.Where(j => j.compGuid == compUser.compGuid).Count();
                ViewData["MyApplications"] = _context.TbApplications.Where(j => j.compGuid == compUser.compGuid &&Guid.Parse(j.appliedBy)==compUser.compUserGuid).Count();
                ViewData["AllCompanyUsers"] = _context.TbCompanyUsers.Where(c=>c.compGuid==compUser.compGuid).Count();
            }
            if (User.IsInRole("BankAdmin"))
            {
                

                //TotalBidBondValue
                //TotalCommision
                var compUser = _context.TbBankUsers.FirstOrDefault(k => k.bankUserGuid == me.bankUserGuid);
                ViewData["ApprovedOrders"] = _context.TbApplications.Where(j => j.SystemBanksGuid == compUser.SystemBanksGuid && j.status == 13).Count();//ApplicationsPendingAuth
                ViewData["TotalBidBonds"] = _context.TbApplications.Where(j => j.SystemBanksGuid == compUser.SystemBanksGuid && j.BidBondDocStatus == 200 && !string.IsNullOrWhiteSpace(j.QrCode)).Count();//ApplicationsPendingAuth
                ViewData["TotalBranches"] = _context.TbBankBranches.Where(j => j.SystemBanksGuid == compUser.SystemBanksGuid).Count();
                ViewData["ApplicationsPendingPayment"] = _context.TbApplications.Where(j => j.SystemBanksGuid == compUser.SystemBanksGuid && j.status == 9).Count();//ApplicationsPendingPayment
                ViewData["AllBankUsers"] = _context.TbBankUsers.Where(k => k.SystemBanksGuid == compUser.SystemBanksGuid).Count();
                ViewData["RejectedOrders"] = _context.TbApplications.Where(j => j.status == 12 && j.SystemBanksGuid == compUser.SystemBanksGuid).Count();//RejectedOrders
                ViewData["OveralLimitBalance"] = _currencies.FormatCurrency( _context.TbSystemBanks.FirstOrDefault(j => j.SystemBanksGuid == compUser.SystemBanksGuid).LimitBalance);//OveralLimitBalance
               // var OverralSecuringLimit = _context.TbSystemBanks.FirstOrDefault(j => j.SystemBanksGuid == compUser.SystemBanksGuid).MaximumSecurityLimit;

              //  string OverralSecuringLimit2 = _currencies.FormatCurrency(OverralSecuringLimit);
                ViewData["OverralSecuringLimit"] = _currencies.FormatCurrency(_context.TbSystemBanks.FirstOrDefault(j => j.SystemBanksGuid == compUser.SystemBanksGuid).OveralSecuringLimit);



                ViewData["MaximumSecuringLimit"] = _currencies.FormatCurrency( _context.TbSystemBanks.FirstOrDefault(j => j.SystemBanksGuid == compUser.SystemBanksGuid).MaximumSecurityLimit);//MaximumSecuringLimit
                ViewData["TotalVerifiedPendingApproval"] = _context.TbApplications.Where(j => j.SystemBanksGuid == compUser.SystemBanksGuid && j.status == 11).Count();//TotalVerifiedPendingApproval
                ViewData["TotalBidBondValue"] = _currencies.FormatCurrency( _context.TbApplications.Where(j => j.SystemBanksGuid == compUser.SystemBanksGuid).Sum(f=>f.amount));//TotalBidBondValue
                ViewData["TotalCommision"] = _currencies.FormatCurrency(_context.TbApplications.Where(j => j.SystemBanksGuid == compUser.SystemBanksGuid).Sum(f=>f.BankComm));//TotalCommision
            }

                if (User.IsInRole("BankUser"))
            {
                var compUser = _context.TbBankUsers.FirstOrDefault(k => k.bankUserGuid == me.bankUserGuid);

                ViewData["MyApplicationsPendingVer"] = _context.TbApplications.Where(j => j.SystemBanksGuid == compUser.SystemBanksGuid && j.status == 10).Count();//MyApplicationsPendingVer

                ViewData["MyApplicationsPendingAuth"] = _context.TbApplications.Where(j => j.SystemBanksGuid == compUser.SystemBanksGuid && j.status == 11 && j.checkedBy!= Guid.Parse(me.Id)).Count();//MyApplicationsPendingAuth
                ViewData["MyApprovedOrders"] = _context.TbApplications.Where(j => j.SystemBanksGuid == compUser.SystemBanksGuid && j.status == 13 && j.approvedBy == Guid.Parse(me.Id)).Count(); //MyApprovedOrders
                ViewData["MyVerifiedOrders"] = _context.TbApplications.Where(j => j.SystemBanksGuid == compUser.SystemBanksGuid && j.status == 11 && j.checkedBy == Guid.Parse(me.Id)).Count(); //MyVerifiedOrders
              
            }
            if (User.IsInRole("MasterAdmin"))
            {
                var x = _context.TbApplications.Where(j => j.status == 1).Count();
                ViewData["PendingApplications"] = _context.TbApplications.Where(j => j.status == 9).Count(); //PendingApplications
                ViewData["UnverifiedCompanies"] = _context.TbCompanies.Where(j => j.status == 0).Count(); //UnverifiedCompanies
                ViewData["UnverifiedDirectors"] = _context.TbDirectors.Where(j => j.Verified == false).Count(); //UnverifiedDirectors
                ViewData["UnverifiedCompanyDocs"] = _context.TbCompanyDocs.Where(j => j.Verified == false).Count(); //UnverifiedCompanyDocs
                ViewData["VerifiedApplications"] = _context.TbApplications.Where(j => j.status == 13).Count(); //VerifiedApplications
                ViewData["VerifiedCompanies"] = _context.TbCompanies.Where(j => j.status == 1).Count(); //VerifiedCompanies
                ViewData["TotalBanks"] = _context.TbSystemBanks.Where(j => j.status == 0).Count(); //TotalBanks
                ViewData["ApprovedOrders"] = _context.TbApplications.Where(j => j.status == 13).Count();
                var rejects = _context.TbApplications.Where(j => j.status == 12).Count() == 0 ? 1 : _context.TbApplications.Where(j => j.status == 12).Count();
                ViewData["BounceRate"] = (_context.TbApplications.Where(j => j.status == 1).Count() / rejects) * 100;                
                ViewData["RejectedOrders"] = _context.TbApplications.Where(j => j.status == 2).Count();
                ViewData["TotalBidBonds"] = _context.TbApplications.Where(j => j.BidBondDocStatus == 200 && !string.IsNullOrWhiteSpace(j.QrCode)).Count();
                //var compUser = _context.TbBankUsers.FirstOrDefault(k => k.bankUserGuid == me.bankUserGuid);
                // ViewData["Commission"] = _context.TbComMatrices.Where(m=>m.SystemBanksGuid == me.bankUserGuid);
            }
            ViewData["AllUsers"] =  _context.TbCompanyUsers.Count()
                    + _context.TbBankUsers.Count();
            ViewData["Notifications"] = _context.TbEmailLogs.Where(j => j.to == me.Email).Count();

            ViewData["Noti"] = _context.TbNotifications.Where(m=> m.systemID == me.Id).Count();
            return View();
        }

        public async Task<IActionResult> terms()
        {
            return View();
        }
        public async Task<IActionResult> privacy()
        {
            return View();
        }
    }
}