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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System.ComponentModel.DataAnnotations;
using Spa_Management.Services;
using System.ServiceModel;
using Spa_Management.Interfaces;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf.Action;
using Spa_Management.Autogen;
using static Spa_Management.Operations.DbOperations;
using System.Threading;
using Rotativa;

namespace Spa_Management.Controllers
{

    [Authorize]
    public class ApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly UserManager<ApplicationUser> _userManager;
        private static IHostingEnvironment _env;
        private readonly IFileProvider _fileProvider;
        private readonly CRB _CRB;
        private readonly IRouter _router;
        private readonly IAutoGen _autoGen;
        private readonly ICurrencies _currencies;


        public ApplicationsController(ApplicationDbContext context, IHostingEnvironment hosting,
            IDbOperations dbOps, UserManager<ApplicationUser> manager, IFileProvider fileProvider, CRB crbserv,IRouter router,IAutoGen autoGen, ICurrencies currencies)
        {
            _context = context;
            _dbOps = dbOps;
            _userManager = manager;
            _env = hosting;
            _fileProvider = fileProvider;
            _CRB = crbserv;
            _router = router;
            _autoGen = autoGen;
            _currencies = currencies;
            // _client = client;
            //_emailSender = emailSender;
        }
        public ActionAsPdf PrintAllEmployee()
        {
            var report = new ActionAsPdf("Details");
            return report;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
		{
            ViewData["DirectorsRegistered"] = true; //should be false after test
            ViewData["DocumentsVerified"] = true;
            ViewData["DirectorsVerified"] = true;
            ViewData["DocumentsRegistered"] = true;

            ViewData["appDate"] = String.IsNullOrEmpty(sortOrder) ? "a" : "";
			ViewData["Amount"] = String.IsNullOrEmpty(sortOrder) ? "b" : "";
			ViewData["Bond"] = String.IsNullOrEmpty(sortOrder) ? "c" : "";
			ViewData["status"] = String.IsNullOrEmpty(sortOrder) ? "d" : "";
			ViewData["approvalDate"] = String.IsNullOrEmpty(sortOrder) ? "e" : DateTime.Now.ToString("DD/MM/YY");
			ViewData["Beneficiary"] = String.IsNullOrEmpty(sortOrder) ? "f" : "";
			ViewData["TradePawaComm"] = String.IsNullOrEmpty(sortOrder) ? "g" : "";
            ViewData["BondPrintOptions"] = new SelectList(_context.BondPrintOptions, "Code", "Description");
            if (searchString != null)
			{
				page = 1;
			}
			else
			{
				searchString = currentFilter;
			}
			//var ApplicationDbContext = _context.TbApplications.Include(t => t.tbSystemBanks);
			ViewData["CurrentFilter"] = searchString;
			var ApplicationDbContext = from m in _context.TbApplications
							//join h in _context.TbIstTypes on m.instType equals h.instType
							select m;
			if (!String.IsNullOrEmpty(searchString))
			{
				string fala = "";
				var ug = _context.TbIndivuduals.FirstOrDefault(j => j.FirstName.Contains(searchString) || j.contact.Contains(searchString) ||
				j.email.Contains(searchString) || j.LastName.Contains(searchString) || j.SirName.Contains(searchString));
				if (!object.ReferenceEquals(ug, null))
				{
					fala =  _context.Users.FirstOrDefault(f => f.indGuid == ug.indGuid).Id;
				}
				var tx = _context.TbCompanyUsers.FirstOrDefault(j => j.FirstName.Contains(searchString) || j.contact.Contains(searchString) ||
				j.email.Contains(searchString) || j.LastName.Contains(searchString) || j.SirName.Contains(searchString));
				if (!object.ReferenceEquals(tx, null))
				{
					fala = _context.Users.FirstOrDefault(f => f.compUserGuid == tx.compUserGuid).Id;
				}
				//string fala =  
				ApplicationDbContext = ApplicationDbContext.Where(p => p.comments.Contains(searchString) || p.currency.Contains(searchString) || p.Details.Contains(searchString)
									|| p.PIN.Contains(searchString) || p.tenderNo.Contains(searchString) || p.appliedBy == fala);
			}
			var me = await _userManager.GetUserAsync(HttpContext.User);
			if (User.IsInRole("Individual"))
			{
				//return View(await ApplicationDbContext.Where(y => y.indGuid == me.indGuid).ToListAsync());
				ApplicationDbContext = ApplicationDbContext.Where(y => y.indGuid == me.indGuid).Include(t => t.tbSystemBanks);
			}
            if (User.IsInRole("MasterAdmin"))
            {
                //return View(await ApplicationDbContext.Where(y => y.indGuid == me.indGuid).ToListAsync());
                ApplicationDbContext = ApplicationDbContext.Include(t => t.tbSystemBanks);
            }
            if (User.IsInRole("CompanyUser"))
            {
                var company = _context.TbCompanyUsers.FirstOrDefault(j => j.compUserGuid == me.compUserGuid).compGuid;
                //return View(await _context.TbApplications.Where(y => y.compGuid == company).ToListAsync());
                ApplicationDbContext = ApplicationDbContext.Where(y => y.compGuid == company && Guid.Parse(y.appliedBy)==me.compUserGuid).Include(t => t.tbSystemBanks);
            }
            if (User.IsInRole("CompanyAdmin"))
			{
				var company = _context.TbCompanyUsers.FirstOrDefault(j => j.compUserGuid == me.compUserGuid).compGuid;
                ApplicationDbContext = ApplicationDbContext.Where(y => y.compGuid == company && Guid.Parse(y.appliedBy) == me.compUserGuid).Include(t => t.tbSystemBanks);
                //return View(await _context.TbApplications.Where(y => y.compGuid == company).ToListAsync());
                //ApplicationDbContext = ApplicationDbContext.Where(y => y.compGuid == company).Include(t => t.tbSystemBanks);
            }
            if (User.IsInRole("BankUser") || User.IsInRole("BankAdmin"))
			{
               
                var bank = _context.TbBankUsers.FirstOrDefault(o => o.bankUserGuid == me.bankUserGuid).SystemBanksGuid;
				//return View(await _context.TbApplications.Where(y => y.SystemBanksGuid == bank).ToListAsync());
				ApplicationDbContext = ApplicationDbContext.Where(y => y.SystemBanksGuid == bank).Include(t => t.tbSystemBanks);
			}
          
            #region Sort
            switch (sortOrder)
			{
				case "a":
					ApplicationDbContext = ApplicationDbContext.OrderBy(m => m.appDate);
					break;
				case "b":
					ApplicationDbContext = ApplicationDbContext.OrderBy(m => m.amount);
					break;
				case "c":
					ApplicationDbContext = ApplicationDbContext.OrderBy(m => m.approvedAmount);
					break;
				case "d":
					ApplicationDbContext = ApplicationDbContext.OrderBy(m => m.status);
					break;
				case "e":
					ApplicationDbContext = ApplicationDbContext.OrderBy(m => m.approvalDate);
					break;
				case "f":
					ApplicationDbContext = ApplicationDbContext.OrderBy(m => m.Purchaser);
					break;
                case "g":
                    ApplicationDbContext = ApplicationDbContext.OrderBy(m => m.BankComm);
                    break;
                default:
					ApplicationDbContext = ApplicationDbContext.OrderByDescending(m => m.appDate);
					break;
			}
			#endregion
			
			int pageSize = 400;
			return View(await PaginatedList<tbApplications>.CreateAsync(ApplicationDbContext.AsNoTracking(), page ?? 1, pageSize));
			//return View(await ApplicationDbContext.ToListAsync());
		}
        public async Task<IActionResult> CreateDocument(string id, bool BankAccess=false)
        {
            if (id == null)
            {
                ModelState.AddModelError("","Please Select Application To Generate Bid Bond For");
            }
            Guid gui = Guid.Parse(id);

            //Find 
        var created =  await _autoGen.AutoGenerateBond(gui, BankAccess);

            if (created.Item1 == true && !string.IsNullOrWhiteSpace(created.Item3))
            {
                try
                {
                    var appToflag = _context.TbApplications.FirstOrDefault(c => c.CRBGuid == gui);
                    appToflag.ClientPrinted = false;
                    appToflag.ClientPreviewApproved = false;
                    appToflag.BidBondDocStatus = 0200;
                    appToflag.BidBondPath = created.Item3;
                    appToflag.QrCode = created.Item4;

                    _context.Update(appToflag);
                    _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    await _dbOps.LogError("Applications/UpdatingAutogeneratedBond", "UpdatingAutogeneratedBond", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
                    ModelState.AddModelError("", "Unable To Download Bid Bond");
                    // throw;
                }
                try
                {
                    return await DownloadBondDocument(created.Item3);
                }
                catch (Exception ex)
                {
                    await _dbOps.LogError("Applications/UpdatingAutogeneratedBond", "DownloadingBidBond", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
                    ModelState.AddModelError("", "Unable To Download Bid Bond");
                   // throw ex;
                }

                

                ////flag db status codes
                ///invoke download Parameters
            }
            else
            {
                //error creating bid bod
                // return model
                ModelState.AddModelError("", created.Item2);
            }
            //if true ....go to location and open doc in browser

            try
            {
                return await DownloadBondDocument(created.Item3);
            }
            catch (Exception ex)
            {
                await _dbOps.LogError("Applications/UpdatingAutogeneratedBond", "DownloadingBidBond", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
                ModelState.AddModelError("", "Unable To Download Bid Bond");
              //  throw ex;
            }
            return null;//ModelState.AddModelError("", "Unable To Download Bid Bond");

        }

        public async Task<IActionResult> DownloadBond(string id, bool BankAccess = false)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Please Select Application To Generate Bid Bond For");
            }
            Guid gui = Guid.Parse(id);
            var DocPath = _context.TbApplications.FirstOrDefault(c => c.CRBGuid == gui).BidBondPath;
            if (!string.IsNullOrWhiteSpace(DocPath))
            {
                try
                {
                    return await DownloadBondDocument(DocPath);
                }
                catch (Exception ex)
                {
                    await _dbOps.LogError("Applications/UpdatingAutogeneratedBond", "DownloadingBidBond", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
                    ModelState.AddModelError("", "Unable To Download Bid Bond");
                    // throw ex;
                }
            }
            else
            {
                ModelState.AddModelError("", "Unable To Download Bid Bond");
            }


            return NotFound();
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(Guid? id, string f = null)
		{
			if (id == null)
			{
				return NotFound();
			}

			var tbApplications = await _context.TbApplications              
				.Include(t => t.tbSystemBanks)
				.SingleOrDefaultAsync(m => m.CRBGuid == id);
			if (tbApplications == null)
			{
				return NotFound();
			}
		  

			var tbcrb = await _context.TbCRBChecks
				.SingleOrDefaultAsync(m => m.compGuid == tbApplications.compGuid);

			// Removed this verification since some company details are not found within CRB using the test environment
			//if (tbcrb == null)
			//{
			//    return NotFound();
			//}

			var appliedby = await _dbOps.DetailsOfWhoApplied(tbApplications);

			var benef = await _dbOps.DetailOfBeneficiary(tbApplications);

			applicationDetails det = new applicationDetails
			{
				appliedby = await _dbOps.GetCompanyDetails(tbApplications.CRBGuid),
				aplication = tbApplications,
				ApplicantAddress = appliedby.CompanyAddress,
				BenefName = benef?.BenefName,
				BenefAddress = benef?.address,
				crb = tbcrb,
				docs = _context.TbApplicationDocs.Where(j => j.CRBGuid == id).ToList()
				
			};
			if (tbApplications.status == 11 || tbApplications.status == 12)
			{
				det.approvedby = await _dbOps.GetWhoApprovedOrChecked(tbApplications.CRBGuid, 0);
			}
			if (tbApplications.status == 13 || tbApplications.status == 14)
			{
				det.approvedby = await _dbOps.GetWhoApprovedOrChecked(tbApplications.CRBGuid, 0);
				det.checkedby = await _dbOps.GetWhoApprovedOrChecked(tbApplications.CRBGuid, 1);
			}
            if (User.IsInRole("BankUser"))
            {
                ViewData["BondProcessingActions"] = new SelectList(_context.BondProcessingActions, "Code", "Description");
                //  ViewData["appliedBy"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).FirstName;
                //  ViewData["ApplicantAdd"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).pysicalLoc;
            }

            ViewData["Gui"] = det.aplication.CRBGuid;
			ViewData["compGuid"] = det.aplication.compGuid;
			ViewData["State0"] = det.aplication.status;
            var actCode= det.aplication.ActionCode;
            ViewData["Action"] = actCode; //det.aplication.ActionCode;
            //ViewData["crbStatus"] = det.crb.status;
            if (!object.ReferenceEquals(f, null))
			{
				ViewData["Gitumi"] = f;
			}
			return View(det);
		}
        public async Task<IActionResult> DownloadBondDocument(string filename)
        {
            if (filename == null)
                return Content("Sorry,Bid Bond Not Requested is Not Avalaible");//Papa Map to  A Friendly Page

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/BidBonds", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        public async Task<IActionResult> Download(string filename)
		{
			if (filename == null)
				return Content("filename not present");

			var path = Path.Combine(
						   Directory.GetCurrentDirectory(),
						   "wwwroot/Uploads", filename);

			var memory = new MemoryStream();
			using (var stream = new FileStream(path, FileMode.Open))
			{
				await stream.CopyToAsync(memory);
			}
			memory.Position = 0;
			return File(memory, GetContentType(path), Path.GetFileName(path));
		}

		private string GetContentType(string path)
		{
			var types = GetMimeTypes();
			var ext = Path.GetExtension(path).ToLowerInvariant();
			return types[ext];
		}

		private Dictionary<string, string> GetMimeTypes()
		{
			return new Dictionary<string, string>
			{
				{".txt", "text/plain"},
				{".pdf", "application/pdf"},
				{".doc", "application/vnd.ms-word"},
				{".docx", "application/vnd.ms-word"},
				{".xls", "application/vnd.ms-excel"},
				{".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},  
				{".png", "image/png"},
				{".jpg", "image/jpeg"},
				{".jpeg", "image/jpeg"},
				{".gif", "image/gif"},
				{".csv", "text/csv"}
			};
		}
   
		[Authorize(Roles = ("BankUser"))]

		public async Task<IActionResult> Approve2( string Details,string CoreBankingRef,string btn, string appId)
		{
			if (appId == null)
			{
				return NotFound();
			}
			Guid gui = Guid.Parse(appId);
			var tbApplications = await _context.TbApplications
				.Include(t => t.tbSystemBanks)
				.SingleOrDefaultAsync(m => m.CRBGuid == gui);
			if (tbApplications == null)
			{
				return NotFound();
			}
			var me = await _userManager.GetUserAsync(HttpContext.User);
			var bank = (await _context.TbBankUsers.FirstOrDefaultAsync(o => o.bankUserGuid == me.bankUserGuid)).SystemBanksGuid;
			if (tbApplications.SystemBanksGuid == bank)
			{
				if (!object.ReferenceEquals(Details, null) && !string.IsNullOrEmpty(Details.Trim())&&(!object.ReferenceEquals(CoreBankingRef, null) && !string.IsNullOrEmpty(CoreBankingRef.Trim())))
				{
					//var user = await _context.TbUserProfiles.FirstOrDefaultAsync(g => g.systemID == tbApplications.appliedBy);
					//if (!object.ReferenceEquals(user, null))
					//{
						var profile = _context.Users.FirstOrDefault(j => j.compUserGuid ==Guid.Parse(tbApplications.appliedBy));
						if (btn == "Approve")
						{
							if (tbApplications.status == 0)
							{
								tbApplications.status = 1;
								tbApplications.comments = Details;
                                tbApplications.CoreBankingReferenceNumber = CoreBankingRef;
								tbApplications.approvalDate = DateTime.Now;
								tbApplications.approvedBy = Guid.Parse(me.Id);
								await _dbOps.LogNotification(profile.Id, 1, "Your Application has been Approved step 1");
							}
							else
							{
								if (tbApplications.status == 1)
								{

                                var makerCoreBankingRef = _context.TbApplications.FirstOrDefault(a => a.CRBGuid == gui).CoreBankingReferenceNumber;

                                if(!String.Equals(CoreBankingRef, makerCoreBankingRef))
                                {
                                    return (RedirectToAction("details", new { id = appId, f = "Application Approval Failed.!!! Core Banking From Maker Does Not Match with Provided Reference Number" }));
                                    //QUIT...ERR MESSAGE CORE BANKING MISMATCH
                                }
                                else
                                {
                                    if (tbApplications.approvedBy != Guid.Parse(me.Id))
                                    {
                                        tbApplications.status = 3;
                                        tbApplications.checkerComments = Details;
                                        //Validate if matches
                                        //else quit


                                        // tbApplications.CoreBankingReferenceNumber = CoreBankingRef;
                                        tbApplications.checkerDate = DateTime.Now;
                                        tbApplications.checkedBy = Guid.Parse(me.Id);

                                        //Send Email

                                        string email = ""; string sms = "";
                                        //if (user.preferedCommMethod == 0 || user.preferedCommMethod == 2)
                                        //{
                                        email = "Your Application having tender number " + tbApplications.tenderNo + " has been approved. Kindly Proceed to payments";
                                        //}
                                        //if (user.preferedCommMethod == 1 || user.preferedCommMethod == 2)
                                        //{
                                        sms = "Your Application with tender number " + tbApplications.tenderNo + " has been approved. Kindly Proceed to payments";
                                        //}
                                        //if (!string.IsNullOrEmpty(email))
                                        //{
                                        await _dbOps.LogAndSendMail(profile.Email, "Application Approved", email,"","");
                                        //}
                                        if (!string.IsNullOrEmpty(sms))
                                        {
                                            //Afrika is Talking Gateway
                                            await _dbOps.LogandSendSMS(profile.PhoneNumber, "Application Approved", "", "", "");
                                        }
                                        //Notice
                                        await _dbOps.LogNotification(profile.Id, 1, "Your Application has been Approved final Step, Proceed to Check out");
                                        //Generate and Store Receipt
                                    }
                                    else
                                    {
                                        return (RedirectToAction("details", new { id = appId, f = "Approver cannot be checker" }));
                                    }
                                }
							}
						}

						}
						if (btn == "Reject")
						{
							if (tbApplications.status == 0)
							{
								tbApplications.status = 2;
								tbApplications.comments = Details;
								tbApplications.approvalDate = DateTime.Now;
                                tbApplications.CoreBankingReferenceNumber = CoreBankingRef;
                                tbApplications.approvedBy = Guid.Parse(me.Id);
								await _dbOps.LogNotification(profile.Id, 1, "Your Application has been Rejected step 1");
								//_dbOps.logandSendSMS(profile.PhoneNumber, "Your Application has been Rejected step 1");
							}
							else
							{
								if (tbApplications.approvedBy != Guid.Parse(me.Id))
								{
									tbApplications.status = 4;
									tbApplications.checkerComments = Details;
									tbApplications.checkerDate = DateTime.Now;
									tbApplications.checkedBy = Guid.Parse(me.Id);
									await _dbOps.LogNotification(profile.Id, 1, "Your Application has been Rejected step 2");
								}
								else
								{
									return (RedirectToAction("details", new { id = appId, f = "Approver cannot be checker" }));
								}
							}
						}
					}
					//else
					//{
					//	return (RedirectToAction("details", new { id = appId, f = "Applicant Profile is incomplete" }));
					//	//_dbOps.LogNotification(profile.Id, 1, "Your Application has been Approved final Step, Proceed to Check out");
					//}
					
				
				else
				{
					return (RedirectToAction("details", new { id = appId, f = "Please provide CoreBanking Ref" }));
				}
			}

			//tbApplications.
			_context.Update(tbApplications);
			await _context.SaveChangesAsync();
			
			return RedirectToAction(nameof(Index));
		}
        [Authorize(Roles = ("BankUser"))]

        public async Task<IActionResult> Approve(string Details, string CoreBankingRef, string btn, string appId,string ActionCode)
        {
            if (appId == null)
            {
                return NotFound();
            }
            Guid gui = Guid.Parse(appId);
            var tbApplications = await _context.TbApplications
                .Include(t => t.tbSystemBanks)
                .SingleOrDefaultAsync(m => m.CRBGuid == gui);
            if (tbApplications == null)
            {
                return NotFound();
            }
            var me = await _userManager.GetUserAsync(HttpContext.User);
            var bank = (await _context.TbBankUsers.FirstOrDefaultAsync(o => o.bankUserGuid == me.bankUserGuid)).SystemBanksGuid;
            if (tbApplications.SystemBanksGuid == bank)
            {
                if (!object.ReferenceEquals(Details, null) && !string.IsNullOrEmpty(Details.Trim()) && (!object.ReferenceEquals(CoreBankingRef, null) && !string.IsNullOrEmpty(CoreBankingRef.Trim())))
                {

                    var profile = _context.Users.FirstOrDefault(j => j.compUserGuid == Guid.Parse(tbApplications.appliedBy));
                    if (btn == "Approve")
                    {
                       var msg = "Your Application having tender number " + tbApplications.tenderNo + " has been Verified first step";

                        if (tbApplications.status == 10)
                        {
                            tbApplications.status = 11;
                            tbApplications.comments = Details;
                            tbApplications.ActionCode = ActionCode;
                            tbApplications.CoreBankingReferenceNumber = CoreBankingRef;
                            tbApplications.approvalDate = DateTime.Now;
                            tbApplications.checkedBy = Guid.Parse(me.Id);
                            await _dbOps.LogNotification(profile.Id, 1, msg);
                        }
                        else
                        {
                            if (tbApplications.status == 11)
                            {

                                var makerCoreBankingRef = _context.TbApplications.FirstOrDefault(a => a.CRBGuid == gui).CoreBankingReferenceNumber;

                                if (!String.Equals(CoreBankingRef, makerCoreBankingRef))
                                {
                                    return (RedirectToAction("details", new { id = appId, f = "Application Approval Failed.!!! Core Banking From Maker Does Not Match with Provided Reference Number" }));
                                    //QUIT...ERR MESSAGE CORE BANKING MISMATCH
                                }
                                else
                                {
                                    if (tbApplications.checkedBy != Guid.Parse(me.Id))
                                    {
                                        tbApplications.status = 13;//Checker
                                        tbApplications.ActionCode = ActionCode;//Checker
                                        tbApplications.checkerComments = Details;
                                        tbApplications.checkerDate = DateTime.Now;
                                        tbApplications.approvedBy = Guid.Parse(me.Id);
                                      //  tbApplications.checkedBy = Guid.Parse(me.Id);

                                        //Send Email

                                        string email = ""; string sms = "";
                                        email = "Your Application having tender number " + tbApplications.tenderNo + " has been approved.Please proceed and collect Bid Bond";
                                        //}
                                        //if (user.preferedCommMethod == 1 || user.preferedCommMethod == 2)
                                        //{
                                        sms = "Your Application having tender number " + tbApplications.tenderNo + " has been approved.Please proceed and collect Bid Bond";
                                        //}
                                        //if (!string.IsNullOrEmpty(email))
                                        //{

                                        //}
                                        await _dbOps.LogNotification(profile.Id, 1, email);

                                        //Get Bank where this application is
                                        var bankToDeplete = _context.TbSystemBanks.FirstOrDefault(c => c.SystemBanksGuid == tbApplications.SystemBanksGuid);

                                        bankToDeplete.LimitBalance = ((bankToDeplete.LimitBalance) - (tbApplications.amount));
                                        _context.TbSystemBanks.Update(bankToDeplete);

                                        if (!string.IsNullOrEmpty(sms))
                                        {
                                            //Afrika is Talking Gateway
                                            await _dbOps.LogandSendSMS(profile.PhoneNumber, sms, "", "", "");
                                        }
                                        if (!string.IsNullOrEmpty(email))
                                        {
                                            await _dbOps.LogAndSendMail(profile.Email, "Application Approved", email, "", "");
                                        }
                                            //Notice
                                           
                                        //Generate and Store Receipt
                                    }
                                    else
                                    {
                                        return (RedirectToAction("details", new { id = appId, f = "Verifier cannot be checker" }));
                                    }
                                }
                            }
                        }

                    }
                    if (btn == "Reject")
                    {
                        string email = ""; string sms = "";
                        email = "Your Application having tender number " + tbApplications.tenderNo + " has been Rejected.Please contact the bank for further information";
                        sms = "Your Application having tender number " + tbApplications.tenderNo + " has been Rejected.Please contact the bank for further information";

                        if (tbApplications.status == 10)
                        {
                            tbApplications.status = 12;//Rejected application
                            tbApplications.comments = Details;
                            tbApplications.ActionCode = ActionCode;
                            tbApplications.approvalDate = DateTime.Now;
                            tbApplications.CoreBankingReferenceNumber = CoreBankingRef;
                            tbApplications.checkedBy = Guid.Parse(me.Id);
                        
                        }
                        else
                        {
                            if (tbApplications.checkedBy != Guid.Parse(me.Id) && tbApplications.status == 12)
                            {
                                tbApplications.status = 14;
                                tbApplications.checkerComments = Details;
                                tbApplications.ActionCode = ActionCode;
                                tbApplications.checkerDate = DateTime.Now;
                                tbApplications.approvedBy = Guid.Parse(me.Id);
                                await _dbOps.LogNotification(profile.Id, 1, email);

                                await _dbOps.LogAndSendMail(profile.Email, "Application Rejected", email, "", "");

                                if (!string.IsNullOrEmpty(sms))
                                {
                                    await _dbOps.LogandSendSMS(profile.PhoneNumber, sms, "", "", "");
                                }
                            }
                            else
                            {
                                return (RedirectToAction("details", new { id = appId, f = "Approver cannot be checker" }));
                            }
                        }
                    }
                }
                //else
                //{
                //	return (RedirectToAction("details", new { id = appId, f = "Applicant Profile is incomplete" }));
                //	//_dbOps.LogNotification(profile.Id, 1, "Your Application has been Approved final Step, Proceed to Check out");
                //}


                else
                {
                    return (RedirectToAction("details", new { id = appId, f = "Please provide CoreBanking Ref" }));
                }
            }

            //tbApplications.
            _context.Update(tbApplications);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = ("BankUser"))]
		public async Task<IActionResult> CRBRefresh(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var tbApplications = await _context.TbApplications
				.Include(t => t.tbSystemBanks)
				.SingleOrDefaultAsync(m => m.CRBGuid == id);
			if (tbApplications == null)
			{
				return NotFound();
			}
			var me = await _userManager.GetUserAsync(HttpContext.User);
			var bank = (await _context.TbBankUsers.FirstOrDefaultAsync(o => o.bankUserGuid == me.bankUserGuid)).SystemBanksGuid;
			var a = await _context.TbIndivuduals.FirstOrDefaultAsync(x => x.indGuid == tbApplications.indGuid);
			var indNum = a.idNumber;
			var idType = a.idType;
			if (tbApplications.SystemBanksGuid == bank)
			{            
				var binding = new BasicHttpBinding();

				//subject to discussion
				tbCRBChecks ikocrb = await _context.TbCRBChecks.SingleOrDefaultAsync(m => m.CRBGuid == id);//&& (DateTime.Now - m.date).Days > 7 );

				if (ikocrb == null)
				{
					string result = _dbOps.CallWebService(indNum, idType);

					if (result == "SubjectNotFound")
					{
						//blah blah blah
						ModelState.AddModelError("", " " + a.FirstName + " credit score is Okay");
						return (RedirectToAction("details", new { id = id }));
					}
					else
					{
						// usimpatie bond 

						//System.IO.File.WriteAllText(@"C:\Users\admin\Documents\WriteLines.txt", result);

						//log Tbcrb checks 

						var CrbDetails = new tbCRBChecks
						{
							indGuid = a.indGuid,
							inComeDetails = result,
							score = 0,
							details = result,
							status = 1,
							date = DateTime.Now
						};
						_context.TbCRBChecks.Add(CrbDetails);
						_context.SaveChanges();

						ModelState.AddModelError("", "" + a.FirstName + " credit score is not okay. Kindly clear with CRB first");
						return (RedirectToAction("details", new { id = id }));

					}
				}
				else
				{

					return (RedirectToAction("details", new { id = id }));


				}

			}
				return (RedirectToAction("details", new { id = id}));
		}

		public async Task<IActionResult> CheckOut(Guid? id,string payopt, string error = null)
		{
			if (id == null)
			{
				return NotFound();
			}

			var tbApplications = await _context.TbApplications
				.Include(t => t.tbSystemBanks)
				.SingleOrDefaultAsync(m => m.CRBGuid == id);
			if (tbApplications == null)
			{
				return NotFound();
			}
			var appliedby = await _dbOps.DetailsOfWhoApplied(tbApplications);

			var benef = await _dbOps.DetailOfBeneficiary(tbApplications);

			applicationDetails det = new applicationDetails
			{
				appliedby = await _dbOps.GetCompanyDetails(tbApplications.CRBGuid),
				aplication = tbApplications,
				ApplicantAddress = appliedby.CompanyAddress,
				docs = _context.TbApplicationDocs.Where(j => j.CRBGuid == id).ToList(),
				BenefName = benef?.BenefName,
				BenefAddress = benef?.address
			};
			if (tbApplications.status == 11 || tbApplications.status == 12)
			{
				det.approvedby = await _dbOps.GetWhoApprovedOrChecked(tbApplications.CRBGuid, 0);
			}
			if (tbApplications.status == 13 || tbApplications.status == 14)
			{
				det.approvedby = await _dbOps.GetWhoApprovedOrChecked(tbApplications.CRBGuid, 0);
				det.checkedby = await _dbOps.GetWhoApprovedOrChecked(tbApplications.CRBGuid, 1);
			}
			ViewData["Error"] = error;
			ViewData["Gui"] = det.aplication.CRBGuid;
			ViewData["State0"] = det.aplication.status;
            ViewData["ApplicantTelephone"] = appliedby.msisdn;
            ViewData["PaymentOptions"] = new SelectList(_context.PaymentOptions.Where(p=>p.Active==true), "Code", "Name");
            return View(det);
		}

        //BondAutoGen
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Terms()
        {
            return View();
        }
        //AppendCoreBankingRef

        public async Task<IActionResult> BondAutoGen(string appId)
        {
            try
			{
				if (appId == null)
				{
					return NotFound();
				}
				Guid gui = Guid.Parse(appId);
				var tbApplications = await _context.TbApplications
					.Include(t => t.tbSystemBanks)
					.SingleOrDefaultAsync(m => m.CRBGuid == gui);
				if (tbApplications == null)
				{
					return NotFound();
				}
				var appliedby = await _dbOps.DetailsOfWhoApplied(tbApplications);

				//tbApplications.CRBGuid = Guid.NewGuid();
				/// Send JSON to KenSwitch
				var obj = new DbOperations.CheckOutJson()
				{
					username = (await _dbOps.GetSysParameter("UserName")).Value.Trim() ?? "api_marineuser",// "api_marineuser",
					merchantToken = (await _dbOps.GetSysParameter("Merchant Token")).Value.Trim() ?? "e5cd8754-57c3-4361-a836-b38db2dadb9f",//"5c4467a9-cdda-4d72-a345-f1129c72c2e0", // Setups 
					msisdn = appliedby.msisdn,
					merchantreference = tbApplications.CRBGuid.ToString(),//"MCL20181126",
					firstname = appliedby.firstName,
					lastname = appliedby.lastName,
					address = appliedby.address,
					currency = tbApplications.currency, // "KES",
					email = appliedby.email,
					ordersummary = "Bond Premium Payment",
					amount = Convert.ToDouble(tbApplications.approvedAmount),// 10.00,
					merchantURL =(await _dbOps.GetSysParameter("Merchant URL")).Value.Trim() ?? "https://Spa_Management.azurewebsites.net/api/Spa_ManagementApps",// "http://localhost:65514/Simulator/index.php",
					accountNumber = appliedby.msisdn, // "254706036493",
					ServiceID = "1",
					PromoCode = "",
					Discount = "",
					extraData = ""
				};

				/// Log in Tables
				var qq = await _dbOps.PostRequest(obj,false);

				string err = string.Empty;
				if (qq.Status.Trim().Equals("2000"))
				{
					return Redirect(qq.Result.URL); // Do it in a new tab
					//  Redirect("http://apps.kenswitch.com:9090/onlinePayments/api/postPayment?id=FO/E1eAInctVSr71W0VSMrE1qcxNRMuoCG7KHg3VVHL2/cgqtb6ouXcwjyOK4T69");
				}
				else
				if (qq.Status.Trim().Equals("1007"))
				{
					err = "Merchant reference "+ tbApplications.CRBGuid.ToString() + " already exists.";
					
				}
				else
				if (qq.Status.Trim().Equals("1006"))
				{
					err = "request Expired";
				}
				else
				if (qq.Status.Trim().Equals("1005"))
				{
					err = "Token Failed";
				}
				else
				if (qq.Status.Trim().Equals("1004"))
				{
					err = "Invalid CurrencyCode";
				}
				else
				if (qq.Status.Trim().Equals("1003"))
				{
					err = "PaymentExpiredCode";
				}
				else
				if (qq.Status.Trim().Equals("1002"))
				{
					err = "Invalid AmountCode";
				}
				else
				if (qq.Status.Trim().Equals("1001"))
				{
					err = "Invalid RefenceCode";
				}
				else
				{
					//Todo: Tell some support guy about this 
					err = "Payment could not be initialized Please try again later";
				}
              //  await _dbOps.UpdateCheckouStatus();

                await UpdateReceipt(appId);

                //update status flag to 6
                //redirect to Bond Auto gen Page
                //Call that method to gen here
                //
                return (RedirectToAction("checkout", new { id = appId, error = err }));
				/// else redirect to Checkout above with a ka error
			}
			catch (Exception ex)
			{
				await _dbOps.LogError("Applications/Payments", "CheckOut", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
			}
			return NotFound();
        }
        public async Task<IActionResult> Payments(string appId,string PaymentOption,string ApplicantTelephone)
		{
            string err = string.Empty;
            try
            {
                if (appId == null)
                {
                    return NotFound();
                }
              
                Guid gui = Guid.Parse(appId);
                var tbApplications = await _context.TbApplications
                    .Include(t => t.tbSystemBanks)
                    .SingleOrDefaultAsync(m => m.CRBGuid == gui);
                if (tbApplications == null)
                {
                    return NotFound();
                }
                var appliedby = await _dbOps.DetailsOfWhoApplied(tbApplications);

                if (string.Equals(PaymentOption, "60"))
                {
                    //Trigger Mpesa
                    //Further check option enabled if paybill or till
                    var initiateMpesaRequest = new InitiateMpesaRequest();
                    var checkout = new MpesaCheckOutJson();
                    var payStatus = new InitiateLipaNaMpesaStatusRequest();
                    var paystatussend = new LipaNaMpesaStatusRequest();


                    var ConsumerKey = _context.TbSysConfigs.FirstOrDefault(x => x.code == "CONSUMER KEY").Value;
                    var ConsumerSecret = _context.TbSysConfigs.FirstOrDefault(x => x.code == "CONSUMER SECRET").Value;
                    var MpesaCallBack = _context.TbSysConfigs.FirstOrDefault(x => x.code == "MPESA CALLBACK URL").Value;
                    var MpesaPassKey = _context.TbSysConfigs.FirstOrDefault(x => x.code == "MPESA PASS KEY").Value;
                    var MpesaTransactionDescription = _context.TbSysConfigs.FirstOrDefault(x => x.code == "MPESA TRANS DESC").Value;
                    var MpesaTransactionType = _context.TbSysConfigs.FirstOrDefault(x => x.code == "MPESA TRANS TYPE").Value;
                    var MpesaAccountRef = _context.TbSysConfigs.FirstOrDefault(x => x.code == "MPESA ACCOUNT REF").Value;
                    var MpesaShortCode = _context.TbSysConfigs.FirstOrDefault(x => x.code == "MPESA SHORT CODE").Value;

                    checkout.accountReference = MpesaAccountRef ?? "TradePawa";
                    checkout.amount = tbApplications.approvedAmount.ToString().Replace(".00", String.Empty); 
                    checkout.callBackURL = MpesaCallBack ?? "http://10.101.1.36:8077/api/B2CCallback";
                    checkout.consumerKey = ConsumerKey ?? "R3coWSQqfeKvv9uVW8Hf1FHeNGK1ZdJ9";
                    checkout.businessShortCode = MpesaShortCode ?? "174379";
                    checkout.partyA = appliedby.msisdn.Substring(1);
                    checkout.partyB = MpesaShortCode ?? "174379";
                    checkout.passkey = MpesaPassKey ?? "bfb279f9aa9bdbcf158e97dd71a467cd2e0c893059b10f78e6b72ada1ed2c919";
                    checkout.phoneNumber = appliedby.msisdn.Substring(1);
                    checkout.timestamp = DateTime.Now.ToString("yyyyMMddHHmmss"); // "20200618184545";
                    checkout.transactionDesc = MpesaTransactionDescription ?? "Bond Payment";
                    checkout.transactionType = MpesaTransactionType ?? "CustomerPayBillOnline";
                    checkout.consumerSecret = ConsumerSecret ?? "tMpzIlRGit7GL5De";

                    initiateMpesaRequest.b2CRequest = checkout;


                    var qq = await _dbOps.PostLipaNaMpesaRequest(initiateMpesaRequest, true);
                    MpesaPayments details = new MpesaPayments();

                    details.CheckoutRequestID = qq.result.checkoutRequestID;
                    details.CustomerMessage = qq.CustomerMessage;
                    details.ErrorCode = qq.errorCode;
                    details.ErrorMessage = qq.errorMessage;
                    details.AccountStatusDescription = "";
                    details.ApplicationId = tbApplications.CRBGuid;

                    details.LogDate = DateTime.Now;
                    details.MerchantRequestID = qq.result.merchantRequestID;
                    details.Paid = false;
                    details.ResponseCode = qq.result.responseCode;
                    details.ResponseDescription = qq.result.responseDescription;

                    var logToDb = await _dbOps.LogMpesaPayment(details);

                   
                    if (!string.IsNullOrWhiteSpace(qq.errorCode) && !string.IsNullOrWhiteSpace(qq.errorMessage))
                    {
                        await _dbOps.LogError("Applications/Payments", "CheckOut", "", qq.errorMessage, qq.errorCode is null ? "N/A" : qq.requestId);

                        err = qq.errorMessage + "for" + tbApplications.CRBGuid.ToString() + "Is Not Valid";
                    }
                    
                    if (!string.IsNullOrWhiteSpace(qq.result.checkoutRequestID))
                    {
                        //read these from db
                        paystatussend.businessShortCode = MpesaShortCode ?? "174379";
                        paystatussend.checkoutRequestID = qq.result.checkoutRequestID;
                        paystatussend.passkey = MpesaPassKey ?? "bfb279f9aa9bdbcf158e97dd71a467cd2e0c893059b10f78e6b72ada1ed2c919";
                        paystatussend.timestamp = DateTime.Now.ToString("yyyyMMddHHmmss"); 
                        paystatussend.consumerSecret = ConsumerSecret ?? "tMpzIlRGit7GL5De";
                        paystatussend.consumerKey = ConsumerKey ?? "R3coWSQqfeKvv9uVW8Hf1FHeNGK1ZdJ9";
                        payStatus.b2CRequest = paystatussend;

                        Thread.Sleep(8000);//papa remove after implementig call backs...or recheck the state until you get a different status



                        MpesaStatusResponse accStat = await _dbOps.PostLipaNaMpesaStatus(payStatus, true);

                        if(!(accStat.ResultCode == "0" && string.Equals("The service request is processed successfully.", accStat.ResultDesc)))
                        {
                            Thread.Sleep(9000);
                            accStat = await _dbOps.PostLipaNaMpesaStatus(payStatus, true);
                        }

                        //

                        var dataToUpdate = await _context.MpesaPayments.FirstOrDefaultAsync(c => c.CheckoutRequestID == accStat.CheckoutRequestID);


                        dataToUpdate.AccountStatusDescription = accStat.ResultDesc;
                        dataToUpdate.AccountStatusRespCode = accStat.ResultCode;


                        if (accStat.ResultCode == "1032")
                        {
                            //Return user cancelled trans
                            err = "Request cancelled by user";
                            dataToUpdate.Paid = false;
                        }
                        if (accStat.ResultCode == "0" && string.Equals("The service request is processed successfully.", accStat.ResultDesc))
                        {

                            //Return user cancelled trans
                            dataToUpdate.Paid = true;
                            err = "Payment Successfuly made";

                            //Aler user and populate detais...Update payment on app  db.//Alert user that it has been paid..via sms and email,,,update db,,,,show recceipt

                        }
                        if (accStat.ResultCode == "1")
                        {
                            err = "The balance is insufficient for the transaction";
                            //Return user cancelled trans
                            dataToUpdate.Paid = false;

                        }
                        if (accStat.ResultCode == "2")
                        {
                            err = "Less Than Minimum Transaction Value";
                            dataToUpdate.Paid = false;

                        }
                        if (accStat.ResultCode == "3")
                        {
                            err = "More Than Maximum Transaction Value";
                            dataToUpdate.Paid = false;

                        }
                        if (accStat.ResultCode == "4")
                        {
                            err = "Would Exceed Daily Transfer Limit";

                            dataToUpdate.Paid = false;
                        }
                        if (accStat.ResultCode == "5")
                        {
                            err = "Would Exceed Minimum Balance";
                            dataToUpdate.Paid = false;

                        }
                        if (accStat.ResultCode == "6")
                        {
                            err = "	Unresolved Primary Party";

                            dataToUpdate.Paid = false;
                        }
                        if (accStat.ResultCode == "7")
                        {
                            err = "	Unresolved Receiver Party";

                            dataToUpdate.Paid = false;
                        }
                        if (accStat.ResultCode == "8")
                        {
                            err = "	Would Exceed Maxiumum Balance";

                            dataToUpdate.Paid = false;
                        }
                        if (accStat.ResultCode == "11")
                        {
                            err = "Debit Account Invalid";
                            dataToUpdate.Paid = false;

                        }
                        if (accStat.ResultCode == "12")
                        {
                            err = "Credit Account Invalid";
                            dataToUpdate.Paid = false;

                        }
                        if (accStat.ResultCode == "13")
                        {
                            err = "Unresolved Debit Account";
                            dataToUpdate.Paid = false;

                        }
                        if (accStat.ResultCode == "14")
                        {
                            err = "Unresolved Credit Account";
                            dataToUpdate.Paid = false;

                        }
                        if (accStat.ResultCode == "15")
                        {
                            err = "Duplicate Detected";
                            dataToUpdate.Paid = false;

                        }
                        if (accStat.ResultCode == "17")
                        {
                            err = "Internal Failure";
                            dataToUpdate.Paid = false;

                        }
                        if (accStat.ResultCode == "20")
                        {
                            err = "Unresolved Initiator";
                            dataToUpdate.Paid = false;

                        }
                        if (accStat.ResultCode == "26")
                        {
                            err = "Traffic blocking condition in place";
                            dataToUpdate.Paid = false;

                        }

                        var UpdatePayStatus = await _dbOps.UpdatePaymentstatus(dataToUpdate);


                    }
                   
                }
                else
                {
                   
                    var obj = new CheckOutJson()
                    {
                        username = (await _dbOps.GetSysParameter("UserName")).Value.Trim() ?? "api_marineuser",// "api_marineuser",
                        merchantToken = (await _dbOps.GetSysParameter("Merchant Token")).Value.Trim() ?? "e5cd8754-57c3-4361-a836-b38db2dadb9f",//"5c4467a9-cdda-4d72-a345-f1129c72c2e0", // Setups 
                        msisdn = appliedby.msisdn,
                        merchantreference = tbApplications.CRBGuid.ToString(),//"MCL20181126",
                        firstname = appliedby.firstName,
                        lastname = appliedby.lastName,
                        address = appliedby.address,
                        currency = tbApplications.currency, // "KES",
                        email = appliedby.email,
                        ordersummary = "MCI Premium Payment",
                        amount = Convert.ToDouble(tbApplications.approvedAmount),// 10.00,
                        merchantURL = (await _dbOps.GetSysParameter("Merchant URL")).Value.Trim() ?? "https://Spa_Management.azurewebsites.net/api/Spa_ManagementApps",// "http://localhost:65514/Simulator/index.php",
                        accountNumber = appliedby.msisdn, // "254706036493",
                        ServiceID = "1",
                        PromoCode = "",
                        Discount = "",
                        extraData = ""
                    };
                    var qq2 = await _dbOps.PostRequest(obj, false);
                    if (qq2.Status.Trim().Equals("2000"))
                    {
                        return Redirect(qq2.Result.URL); // Do it in a new tab
                                                         //  Redirect("http://apps.kenswitch.com:9090/onlinePayments/api/postPayment?id=FO/E1eAInctVSr71W0VSMrE1qcxNRMuoCG7KHg3VVHL2/cgqtb6ouXcwjyOK4T69");
                    }
                    else
                    if (qq2.Status.Trim().Equals("1007"))
                    {
                        err = "Merchant reference " + tbApplications.CRBGuid.ToString() + " already exists.";

                    }
                    else
                    if (qq2.Status.Trim().Equals("1006"))
                    {
                        err = "request Expired";
                    }
                    else
                    if (qq2.Status.Trim().Equals("1005"))
                    {
                        err = "Token Failed";
                    }
                    else
                    if (qq2.Status.Trim().Equals("1004"))
                    {
                        err = "Invalid CurrencyCode";
                    }
                    else
                    if (qq2.Status.Trim().Equals("1003"))
                    {
                        err = "PaymentExpiredCode";
                    }
                    else
                    if (qq2.Status.Trim().Equals("1002"))
                    {
                        err = "Invalid AmountCode";
                    }
                    else
                    if (qq2.Status.Trim().Equals("1001"))
                    {
                        err = "Invalid RefenceCode";
                    }
                    else
                    {
                        //Todo: Tell some support guy about this 
                        err = "Payment could not be initialized Please try again later";
                    }
                    //  await _dbOps.UpdateCheckouStatus();

                    await UpdateReceipt(appId);

                    //update status flag to 6
                    //redirect to Bond Auto gen Page
                    //Call that method to gen here
                    //
                    return (RedirectToAction("checkout", new { id = appId, error = err }));

                    //Trigger Kenswitch Gateway

                }
            }
            catch (Exception ex)
            {
                await _dbOps.LogError("Applications/Payments", "CheckOut", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
                return (RedirectToAction("checkout", new { id = appId, error = "Could Not Initiate Payment,Please Contact System Admin" }));

            }
            //return NotFound();
            return (RedirectToAction("checkout", new { id = appId, error = err }));
        }
		
		public async Task<string> GenerateIPRSToken()
		{
			try
			{             
				/// Send JSON 
				/// Method ONE
				var mv = new DbOperations.Message_validation()
				{
					api_user = (await _dbOps.GetSysParameter("IPRS Api User")).Value.Trim() ?? "dit",
					api_password = (await _dbOps.GetSysParameter("IPRS Api Password")).Value.Trim() ?? "123456",
				};
				var mr = new DbOperations.Message_route()
				{
					@interface = "TOKEN"
				};
				var obj = new DbOperations.IPRSToken()
				{
					message_validation = mv,
					message_route = mr
				};
				///Method TWO
			   /* var jData = new
				{
					message_Validation = new
					{
						api_user = _dbOps.GetSysParameter("IPRS Api User").Value.Trim() ?? "dit",
						api_password = _dbOps.GetSysParameter("IPRS Api Password").Value.Trim() ?? "123456",
					},
					message_route = new
					{
						@interface = "Token"
					}
				};*/

				/// Log in Tables
				var qq = await _dbOps.IPRSTokenRequest(obj);

				/// return token if successful.
				if (qq.error_code.Trim().Equals("00"))
				{
					var token = qq.error_Desc.token;
					await _dbOps.LogJson(token.ToString());
					return token;
				}

			}
			catch (Exception ex)
			{
				await _dbOps.LogError("Applications/Payments", "CheckOut", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
			}
			return "Not Found";
			// return View(); 
		}

		public async Task<bool> testSmS(Guid? id)
		{
			return await _dbOps.LogandSendSMS("+254704514301", "Nice","","","");
		}
        public async Task<bool> UpdateReceipt(string appId)
        {
            try
            {
                Guid gui = Guid.Parse(appId);
                var tbApplications = await _context.TbApplications
                    .Include(t => t.tbSystemBanks)
                    .SingleOrDefaultAsync(m => m.CRBGuid == gui);
                tbApplications.status = 10;
                _context.Update(tbApplications);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
            return false;

            //Update Status
        }
        public async Task<IActionResult> AutoApprove(string appId)
        {
            if (appId == null)
            {
                return NotFound();
            }
            Guid gui = Guid.Parse(appId);
            var tbApplications = await _context.TbApplications
                .Include(t => t.tbSystemBanks)
                .SingleOrDefaultAsync(m => m.CRBGuid == gui);
            if (tbApplications == null)
            {
                return NotFound();
            }
            var me = await _userManager.GetUserAsync(HttpContext.User);
           // var bank = (await _context.TbBankUsers.FirstOrDefaultAsync(o => o.bankUserGuid == me.bankUserGuid)).SystemBanksGuid;
                    var user = await _context.TbUserProfiles.FirstOrDefaultAsync(g => g.systemID == tbApplications.appliedBy);
                    if (!object.ReferenceEquals(user, null))
                    {
                        var profile = _context.Users.FirstOrDefault(j => j.Id == user.systemID);

                        string email = ""; string sms = "";
                        if (user.preferedCommMethod == 0 || user.preferedCommMethod == 2)
                        {
                            email = "Your Application having tender number " + tbApplications.tenderNo + " has been approved. Kindly Proceed to payments";
                        }
                        if (user.preferedCommMethod == 1 || user.preferedCommMethod == 2)
                        {
                            sms = "Your Application with tender number " + tbApplications.tenderNo + " has been approved. Kindly Proceed to payments";
                        }
                        if (!string.IsNullOrEmpty(email))
                        {
                            await _dbOps.LogAndSendMail(profile.Email, "Application Approved", email,"","");
                        }
                        if (!string.IsNullOrEmpty(sms))
                        {
                            //Afrika is Talking Gateway
                            await _dbOps.LogandSendSMS(profile.PhoneNumber, sms,"","","");
                        }
                        //Notice

                        await _dbOps.LogNotification(profile.Id, 1, "Your Application has been Approved, Proceed to Check out");
                        //Generate and Store Receipt
                }
            //tbApplications.
            _context.Update(tbApplications);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public JsonResult getBranches(Guid id)
		{
			List<tbBankBranches> list = new List<tbBankBranches>();
			list = _context.TbBankBranches.Where(a => a.SystemBanksGuid == id).ToList();
			list.Insert(0, new tbBankBranches { BranchGuid = new Guid(), branchName = "Please select branch" });
			return Json(new SelectList(list, "BranchGuid", "branchName"));
		}




		
		// GET: Applications/Create
		// [Authorize(Roles = ("Individual,CompanyUser"))]
		public async Task<IActionResult> Create()
		{
            var me = await _userManager.GetUserAsync(HttpContext.User);
            var compuser = _context.TbCompanyUsers.AsNoTracking().FirstOrDefault(n => n.compUserGuid == me.compUserGuid);
            ViewData["compGuid"] = new SelectList(_context.TbCompanies.AsNoTracking(), "compGuid", "compName");
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks.AsNoTracking(), "SystemBanksGuid", "bankName");
            //ViewData["SystemBanksGuid"] = _context.TbSystemBanks.ToList();// new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName");
            ViewData["currency"] = new SelectList(_context.TbCurrencies.AsNoTracking(), "currency", "currency");
            ViewData["BenefAdderss"] = "Address";
            ViewData["KRAPin"] = "KRAPin";
          
            if (User.IsInRole("Individual"))
			{
				ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies/*Where(m => m.indGuid == me.indGuid)*/, "benGuid", "FirstName");
				ViewData["appliedBy"] = _context.TbIndivuduals.SingleOrDefault(m => m.indGuid == me.indGuid).FirstName;
				ViewData["ApplicantAdd"] = _context.TbIndivuduals.SingleOrDefault(m => m.indGuid == me.indGuid).pysicalLoc;


			}
			if (User.IsInRole("CompanyUser"))
			{
                //Beneficiary
                ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies.AsNoTracking().OrderBy(c => c.FirstName), "benGuid", "FirstName");
                ViewData["BondPrintOptions"] = new SelectList(_context.BondPrintOptions.AsNoTracking(), "Code", "Description");
                // ViewData["PreferredCollection"] = new SelectList(_context.TbBeneficialies, "benGuid", "FirstName");
                ViewData["appliedBy"] = _context.TbCompanyUsers.AsNoTracking().SingleOrDefault(m => m.compUserGuid == me.compUserGuid).FirstName;
                //ViewData["ApplicantAdd"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).pysicalLoc;
                ViewData["ApplicantAdd"] = _context.TbCompanies.AsNoTracking().SingleOrDefault(m => m.compGuid == compuser.compGuid).postalAddress ?? "Address Not Found";

            }
            if (User.IsInRole("CompanyAdmin"))
            {
                //Beneficiary
                ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies.OrderBy(c=>c.FirstName), "benGuid", "FirstName");
                ViewData["BondPrintOptions"] = new SelectList(_context.BondPrintOptions, "Code", "Description");
                ViewData["appliedBy"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).FirstName;
              //  ViewData["PreferredCollection"] = new SelectList(_context.TbBeneficialies, "benGuid", "FirstName");
                ViewData["ApplicantAdd"] = _context.TbCompanies.SingleOrDefault(m => m.compGuid == compuser.compGuid).postalAddress ?? "Address Not Found";

            }
          //  ViewData["BondPrintOptions"] = new SelectList(_context.BondPrintOptions.AsNoTracking(), "Code", "Description");
            ViewData["CommisionAmount"] = 0;
            ViewData["ExpiryDate"] = DateTime.Today.Date;

            ViewData["ShowDoc"] = false;
            ViewData["RequiredDocs"] = _context.TbDocUploadReqs.AsNoTracking().ToList();

            ViewData["BranchGuid"] = new SelectList(_context.TbBankBranches.AsNoTracking(), "BranchGuid", "branchName");
            return View();

		}

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [Authorize(Roles = ("CompanyAdmin,CompanyUser"))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Btn, List<IFormFile> files, [Bind("CRBGuid,PIN,indGuid,compGuid,appliedBy,appDate,currency,PrintCode,TenderPeriod,PrintBondOnline,tenderNo,Details,SystemBanksGuid,BranchGuid,amount,approvedAmount,TradePawaComm,status,approvalDate,comments,terms,approvedBy,bondStartDate,expireDate,AcceptTerms,Purchaser")] tbApplications tbApplications)
        {
            ViewData["DocumentsVerified"] = true;
            ViewData["DirectorsVerified"] = true;
            ViewData["DirectorsRegistered"] = true;
            ViewData["DocumentsRegistered"] = true;

            var me = await _userManager.GetUserAsync(HttpContext.User);
            var compuser = _context.TbCompanyUsers.FirstOrDefault(n => n.compUserGuid == me.compUserGuid);



            //ViewData["compGuid"] = new SelectList(_context.TbCompanies, "compGuid", "compName");
            //ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName");
            ////  ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName");
            //ViewData["SystemBanksGuid"] = _context.TbSystemBanks.ToList();// new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName");
            //ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency");
            //ViewData["BenefAdderss"] = "Address";
            //ViewData["KRAPin"] = "KRAPin";




            //logic for minimum requirements.
            //if allowed bond amount is beyond allowed limit///flag for forther proc..
            //else autoprocess..
            //  var me = await _userManager.GetUserAsync(HttpContext.User);
            // var compuser = _context.TbCompanyUsers.FirstOrDefault(n => n.compUserGuid == me.compUserGuid);


            //    var bankRouter = await _router.ToRoute(tbApplications.amount, tbApplications.PrintCode);
            //    if (bankRouter.Item1 != null && bankRouter.Item3!=null)
            //    {
            //        ViewData["BankName"] = bankRouter.Item2 ?? "";
            //        ViewData["BranchName"] = bankRouter.Item4 ?? "";
            //        string message = bankRouter.Item5;
            //        if (!string.Equals(bankRouter.Item5, "Success"))
            //        {
            //            message = "No route matches data,please set customer print option to No";
            //        }
            //        else
            //        {
            //            message = bankRouter.Item5;
            //        }

            //        ViewData["Message"] = message;
            //    }
            //    else
            //    {
            //        ViewData["Message"] = "No route matches data,please set customer print option to No";

            //    ModelState.AddModelError("", bankRouter.Item5);
            //}


            var Company = _context.TbCompanies.FirstOrDefault(n => n.compGuid == compuser.compGuid);

            //var profile = _context.Users.FirstOrDefault(j => j.Id == tbApplications.appliedBy);
            decimal commisionAMount = 0;

            DateTime expireDate = DateTime.Today.Date;
            DateTime appDate = DateTime.Now;

            string address = "Address";


            try
            {
                if (Btn == "Save")
                {
                    if (tbApplications.bondStartDate.Date >= DateTime.Today.Date)
                    {

                        if (tbApplications.amount > 0)
                        {
                            if (tbApplications.AcceptTerms)
                            {
                                if (tbApplications.bondStartDate > tbApplications.expireDate)
                                {
                                  //  var docsSetupAvailable = _context.TbDocUploadReqs.FirstOrDefault(c => c.SystemBanksGuid == bankRouter.Item1 && c.Status == 2); --AutoRoute
                                    var docsSetupAvailable = _context.TbDocUploadReqs.FirstOrDefault(c => c.SystemBanksGuid == tbApplications.SystemBanksGuid && c.Status == 2);
                                    //tbApplications.SystemBanksGuid)
                                    if (docsSetupAvailable != null)
                                    {

                                        if (files.Count() > 0)
                                        {
                                            tbApplications.CRBGuid = Guid.NewGuid();

                                            if (User.IsInRole("Individual"))
                                            {
                                                tbApplications.indGuid = me.indGuid;

                                            }
                                            if (User.IsInRole("CompanyUser") || User.IsInRole("CompanyAdmin"))
                                            {
                                                tbApplications.compGuid = _context.TbCompanyUsers.FirstOrDefault(j => j.compUserGuid == me.compUserGuid).compGuid;

                                            }

                                            foreach (var file in files)
                                            {
                                                if (file != null && file.Length > 0 && !string.IsNullOrEmpty(file.FileName))
                                                {
                                                    var fileName = Path.GetFileName(file.FileName);
                                                    fileName = tbApplications.CRBGuid + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + fileName;

                                                    var uploads = Path.Combine(_env.WebRootPath, "Uploads", fileName);

                                                    using (var strea = new FileStream(uploads, FileMode.Create))
                                                    {
                                                        await file.CopyToAsync(strea);
                                                        tbApplications.tenderDocs = tbApplications.tenderDocs + ";" + fileName;
                                                    }
                                                    // var bankDocs = _context.TbDocUploadReqs.Where(v => v.SystemBanksGuid == tbApplications.SystemBanksGuid).ToList();
                                                    //Papa New
                                                 //   var bankDocs = _context.TbDocUploadReqs.Where(v => v.SystemBanksGuid == bankRouter.Item1).ToList();  AUTOROUTE
                                                    var bankDocs = _context.TbDocUploadReqs.Where(v => v.SystemBanksGuid == tbApplications.SystemBanksGuid).ToList();

                                                    var appDocs = new tbApplicationDocs()
                                                    {
                                                        applicationDocsGuid = Guid.NewGuid(),
                                                        CRBGuid = tbApplications.CRBGuid,

                                                        docPath = fileName,
                                                        status = 0
                                                    };
                                                    _context.TbApplicationDocs.Add(appDocs);
                                                }
                                            }
                                            if (User.IsInRole("CompanyUser"))
                                            {
                                                tbApplications.PIN = Company.PinNo;
                                            }
                                            else
                                            {
                                                tbApplications.PIN = "Not Available";
                                            }


                                          //  tbApplications.approvedAmount = await _dbOps.GetCommisionAmount(tbApplications.amount, Guid.Parse(bankRouter.Item1.ToString()), tbApplications.currency, tbApplications.TenderPeriod);
                                            tbApplications.approvedAmount = await _dbOps.GetCommisionAmount(tbApplications.amount, tbApplications.SystemBanksGuid, tbApplications.currency, tbApplications.TenderPeriod);
                                            //whatever is approved of this amount
                                            //

                                            tbApplications.BankComm = await _dbOps.GetBankCommisionAmount(tbApplications.amount, tbApplications.SystemBanksGuid, tbApplications.currency, tbApplications.TenderPeriod);
                                           // tbApplications.BankComm = await _dbOps.GetBankCommisionAmount(tbApplications.amount, Guid.Parse(bankRouter.Item1.ToString()), tbApplications.currency, tbApplications.TenderPeriod);
                                            //get max security limit...
                                            //do one for auths
                                            tbApplications.status = 9;
                                            tbApplications.PrintCode = tbApplications.PrintCode;
                                            tbApplications.appliedBy = compuser.compUserGuid.ToString();
                                          //  tbApplications.SystemBanksGuid = Guid.Parse(bankRouter.Item1.ToString()); AUTOROUTE
                                            tbApplications.SystemBanksGuid = tbApplications.SystemBanksGuid;
                                            tbApplications.BranchGuid = tbApplications.BranchGuid;
                                           // tbApplications.BranchGuid = Guid.Parse(bankRouter.Item3.ToString());//AUTOROUTE
                                            tbApplications.appDate = DateTime.Now;
                                            tbApplications.expireDate = _dbOps.GetExpDate(tbApplications.bondStartDate, tbApplications.TenderPeriod);
                                            tbApplications.ClientPrinted = false;
                                            tbApplications.ClientPreviewApproved = false;
                                            tbApplications.BidBondDocStatus = 0100;
                                            tbApplications.BidBondPath = "";
                                            tbApplications.ActionCode = "";

                                            //Convert.ToDateTime(tbApplications.bondStartDate.AddDays(Convert.ToInt32(tbApplications.Period)));

                                            _context.Add(tbApplications);
                                            await _context.SaveChangesAsync();
                                            foreach (var u in await _dbOps.GetAllBankUsers(tbApplications.SystemBanksGuid))//Papa New routing
                                            {
                                                await _dbOps.LogNotification(await _dbOps.GetBankUserSysId(u), 1, "New Application has been Made, Awaiting Further Bank Approvals");
                                            }

                                            //foreach (var u in await _dbOps.GetAllBankUsers(Guid.Parse(bankRouter.Item1.ToString())))//Papa New routing
                                            //{
                                            //    await _dbOps.LogNotification(await _dbOps.GetBankUserSysId(u), 1, "New Application has been Made, Awaiting Further Bank Approvals");
                                            //}

                                            string email = "Your Application having tender number " + tbApplications.tenderNo + " has been submitted Successfully. Kindly Proceed to payments for further processing";
                                            string EmailToBank = "There has been a new application with Tender Number " + tbApplications.tenderNo + " Pending Processing";
                                            //}
                                            //if (user.preferedCommMethod == 1 || user.preferedCommMethod == 2)
                                            //{
                                            string sms = "Your Application having tender number " + tbApplications.tenderNo + " has been submitted Successfully. Kindly Proceed to payments for further processing";
                                            //}
                                            //if (!string.IsNullOrEmpty(email))

                                            if (!string.IsNullOrEmpty(sms))
                                            {
                                                //Afrika is Talking Gateway
                                                await _dbOps.LogandSendSMS(me.PhoneNumber, sms, "", "", "");
                                            }
                                            if (!string.IsNullOrWhiteSpace(email))
                                            {
                                                await _dbOps.LogAndSendMail(me.UserName, "Application Successfull", email, "", "");
                                            }
                                            var BankName = _context.TbSystemBanks.FirstOrDefault(v => v.SystemBanksGuid ==tbApplications.SystemBanksGuid).bankName;
                                          //  var BankName = _context.TbSystemBanks.FirstOrDefault(v => v.SystemBanksGuid == bankRouter.Item1).bankName;
                                           
                                            if (BankName.Contains("FAMILY"))
                                            {
                                                var Broadcastemail = _context.TbSysConfigs.FirstOrDefault(v => v.code == "FAMILY BANK BROADCAST EMAIL").Value ?? "fbtguarantees@familybank.co.ke";
                                                await _dbOps.LogAndSendMail(Broadcastemail, "New Tender Application Alert", EmailToBank, "", "");
                                            }
                                            //{

                                            //}
                                            return RedirectToAction(nameof(Index));
                                        }
                                        else
                                        {

                                            ModelState.AddModelError("", "Please Upload Tender Documents");

                                            //check

                                        }
                                    }
                                    else
                                    {

                                        tbApplications.approvedAmount = await _dbOps.GetCommisionAmount(tbApplications.amount, tbApplications.SystemBanksGuid, tbApplications.currency, tbApplications.TenderPeriod);
                                        //whatever is approved of this amount
                                        //

                                        tbApplications.BankComm = await _dbOps.GetBankCommisionAmount(tbApplications.amount,tbApplications.SystemBanksGuid, tbApplications.currency, tbApplications.TenderPeriod);
                                        //get max security limit...
                                        //do one for auths
                                        tbApplications.PIN = "Not Available";
                                        tbApplications.status = 9;
                                        tbApplications.PrintCode = tbApplications.PrintCode;
                                        tbApplications.appliedBy = compuser.compUserGuid.ToString();
                                        tbApplications.SystemBanksGuid = tbApplications.SystemBanksGuid;//Guid.Parse(bankRouter.Item1.ToString());
                                        tbApplications.BranchGuid = tbApplications.BranchGuid;//Guid.Parse(bankRouter.Item3.ToString());
                                        tbApplications.appDate = DateTime.Now;
                                        tbApplications.expireDate = _dbOps.GetExpDate(tbApplications.bondStartDate, tbApplications.TenderPeriod); //Convert.ToDateTime(tbApplications.bondStartDate.AddDays(Convert.ToInt32(tbApplications.Period)));

                                        _context.Add(tbApplications);
                                        await _context.SaveChangesAsync();
                                        foreach (var u in await _dbOps.GetAllBankUsers(tbApplications.SystemBanksGuid))//Papa New routing
                                        {
                                            await _dbOps.LogNotification(await _dbOps.GetBankUserSysId(u), 1, "New Application has been Made, Awaiting Further Bank Approvals");
                                        }

                                        string email = "Your Application having tender number " + tbApplications.tenderNo + " has been submitted Successfully. Kindly Proceed to payments for further processing";
                                        //}
                                        //if (user.preferedCommMethod == 1 || user.preferedCommMethod == 2)
                                        //{
                                        string sms = "Your Application having tender number " + tbApplications.tenderNo + " has been submitted Successfully. Kindly Proceed to payments for further processing";
                                        //}
                                        //if (!string.IsNullOrEmpty(email))

                                        if (!string.IsNullOrEmpty(sms))
                                        {
                                            //Afrika is Talking Gateway
                                            await _dbOps.LogandSendSMS(me.PhoneNumber, sms, "", "", "");
                                        }
                                        if (!string.IsNullOrWhiteSpace(email))
                                        {
                                            await _dbOps.LogAndSendMail(me.UserName, "Application Approved", email, "", "");
                                        }
                                        //{

                                        //}


                                        return RedirectToAction(nameof(Index));
                                    }

                                }
                                else
                                {
                                    ModelState.AddModelError("", "Start Date cannot be greater than end date");
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("", "Please Accept Terms and Conditions");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please Enter a valid Amount");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Bond Start date cannot be older than today");
                    }
                }
                else
                {
                    if (tbApplications.SystemBanksGuid != Guid.Empty && tbApplications.amount > 0 && tbApplications.currency != "~ Please Select ~")
                    {
                       // commisionAMount = await _dbOps.GetCommisionAmount(tbApplications.amount, tbApplications.SystemBanksGuid, tbApplications.currency, tbApplications.TenderPeriod);
                        commisionAMount = await _dbOps.GetCommisionAmount(tbApplications.amount,Guid.Parse(tbApplications.SystemBanksGuid.ToString()), tbApplications.currency, tbApplications.TenderPeriod);
                        expireDate = _dbOps.GetExpDate(tbApplications.bondStartDate, tbApplications.TenderPeriod);
                        address = _context.TbBeneficialies.FirstOrDefault(b=>b.benGuid==Guid.Parse(tbApplications.Purchaser)).adrress;


                    }

                    if (tbApplications.SystemBanksGuid != Guid.Empty)
                    {
                        ViewData["ShowDoc"] = true;
                       // ViewData["RequiredDocs"] = _context.TbDocUploadReqs.Where(v => v.SystemBanksGuid == tbApplications.SystemBanksGuid).ToList();
                        ViewData["RequiredDocs"] = _context.TbDocUploadReqs.AsNoTracking().Where(v => v.SystemBanksGuid == tbApplications.SystemBanksGuid).ToList();//Papa new routing
                        ViewData["BranchGuid"] = tbApplications.BranchGuid;// new SelectList(_context.TbBankBranches.Where(m => m.SystemBanksGuid == tbApplications.SystemBanksGuid), "BranchGuid", "branchName", tbApplications.BranchGuid);
                    }
                }
            }
            catch (Exception ex)
            {
                await _dbOps.LogError("Applications/Create", "Make new Application", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
            }

          

            //  ViewData["appliedBy"] = _context.TbIndivuduals.FirstOrDefault(m => m.indGuid == tbApplications.indGuid).FirstName;

            ViewData["CommisionAmount"] = commisionAMount;
            ViewData["ExpiryDate"] = expireDate;
            ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies.AsNoTracking(), "benGuid", "FirstName");
            ViewData["compGuid"] = new SelectList(_context.TbCompanies.AsNoTracking(), "compGuid", "compName", tbApplications.compGuid);
          //  ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbApplications.indGuid);

           // ViewData["BondPrintOptions"] = new SelectList(_context.BondPrintOptions, "Code", "Description");
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks.AsNoTracking(), "SystemBanksGuid", "bankName", tbApplications.SystemBanksGuid);
            ViewData["BenefAdderss"] = address;
            ViewData["appDate"] = appDate;

            if (User.IsInRole("Individual"))
            {

                ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies.Where(m => m.indGuid == me.indGuid), "benGuid", "FirstName", tbApplications.Purchaser);
                ViewData["appliedBy"] = _context.TbIndivuduals.SingleOrDefault(m => m.indGuid == me.indGuid).FirstName;
                ViewData["ApplicantAdd"] = _context.TbIndivuduals.SingleOrDefault(m => m.indGuid == me.indGuid).pysicalLoc;
            }
            if (User.IsInRole("CompanyUser"))
            {
                ViewData["BondPrintOptions"] = new SelectList(_context.BondPrintOptions.AsNoTracking(), "Code", "Description");
                ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies.AsNoTracking().OrderBy(f=>f.FirstName), "benGuid", "FirstName", tbApplications.Purchaser);
                ViewData["appliedBy"] = _context.TbCompanyUsers.AsNoTracking().SingleOrDefault(m => m.compUserGuid == me.compUserGuid).FirstName;
                // ViewData["ApplicantAdd"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).pysicalLoc;
                ViewData["ApplicantAdd"] = _context.TbCompanies.AsNoTracking().SingleOrDefault(m => m.compGuid == compuser.compGuid).postalAddress ?? "Address Not Found";
            }

            if (User.IsInRole("CompanyAdmin"))
            {
                //Beneficiary
                ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies, "benGuid", "FirstName");
                ViewData["appliedBy"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).FirstName;
                ViewData["BondPrintOptions"] = new SelectList(_context.BondPrintOptions, "Code", "Description");
                ViewData["ApplicantAdd"] = _context.TbCompanies.SingleOrDefault(m => m.compGuid == compuser.compGuid).pysicalLoc ?? "Address Not Found";

            }
            ViewData["currency"] = new SelectList(_context.TbCurrencies.AsNoTracking(), "currency", "currency", tbApplications.currency);
            if (tbApplications.SystemBanksGuid != Guid.Empty)
            {
                ViewData["ShowDoc"] = true;
                ViewData["RequiredDocs"] = _context.TbDocUploadReqs.AsNoTracking().Where(v => v.SystemBanksGuid == tbApplications.SystemBanksGuid).ToList();
                ViewData["BranchGuid"] = new SelectList(_context.TbBankBranches.AsNoTracking().Where(m => m.SystemBanksGuid == tbApplications.SystemBanksGuid), "BranchGuid", "branchName", tbApplications.BranchGuid);

            }
            else
            {
               // if (tbApplications.SystemBanksGuid != Guid.Empty)
               // {
                    ViewData["ShowDoc"] = false;
                  //  ViewData["RequiredDocs"] = _context.TbDocUploadReqs.ToList();
                    ViewData["BranchGuid"] =  new SelectList(_context.TbBankBranches.AsNoTracking(), "BranchGuid", "branchName");

               // }
             //   else
               /// {
               //     ViewData["ShowDoc"] = false;
              //  }
            }
            return View(tbApplications);
        }


        [HttpPost]
		[Authorize(Roles =("Individual,CompanyUser"))]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create2(string Btn, List<IFormFile> files,[Bind("CRBGuid,PIN,indGuid,compGuid,appliedBy,appDate,currency,TenderPeriod,tenderNo,Details,SystemBanksGuid,BranchGuid,amount,approvedAmount,status,approvalDate,comments,terms,approvedBy,bondStartDate,expireDate,AcceptTerms,Purchaser")] tbApplications tbApplications)
		{
            ViewData["DocumentsVerified"] = true;
            ViewData["DirectorsVerified"] = true;
            ViewData["DirectorsRegistered"] = true;
            ViewData["DocumentsRegistered"] = true;
            //logic for minimum requirements.
            //if allowed bond amount is beyond allowed limit///flag for forther proc..
            //else autoprocess..
            var me = await _userManager.GetUserAsync(HttpContext.User);
			var compuser = _context.TbCompanyUsers.FirstOrDefault(n => n.compUserGuid == me.compUserGuid);

			var Company = _context.TbCompanies.FirstOrDefault(n => n.compGuid == compuser.compGuid);

			decimal commisionAMount = 0;
	   
			DateTime expireDate = DateTime.Today.Date;
			DateTime appDate = DateTime.Now;

			string address = "Address";

		
			try
			{
		  
			   
				if (Btn == "Save")
				{
					if (tbApplications.bondStartDate.Date >= DateTime.Today.Date)
					{
					  
							if (tbApplications.amount > 0)
						{
							if (tbApplications.AcceptTerms)
							{
								if (tbApplications.bondStartDate > tbApplications.expireDate)
								{
									if (files.Count() > 0)
									{
										tbApplications.CRBGuid = Guid.NewGuid();
									 
										if (User.IsInRole("Individual"))
										{
											tbApplications.indGuid = me.indGuid;
										 
										}
										if (User.IsInRole("CompanyUser") || User.IsInRole("CompanyAdmin"))
										{
											tbApplications.compGuid = _context.TbCompanyUsers.FirstOrDefault(j => j.compUserGuid == me.compUserGuid).compGuid;
										  
										}

										foreach (var file in files)
										{
											if (file != null && file.Length > 0 && !string.IsNullOrEmpty(file.FileName))
											{
												var fileName = Path.GetFileName(file.FileName);
												fileName = tbApplications.CRBGuid + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + fileName;
										  
												var uploads = Path.Combine(_env.WebRootPath, "Uploads", fileName);
											
												using (var strea = new FileStream(uploads, FileMode.Create))
												{
													await file.CopyToAsync(strea);
													tbApplications.tenderDocs = tbApplications.tenderDocs + ";" + fileName;
												}
												var bankDocs = _context.TbDocUploadReqs.Where(v => v.SystemBanksGuid == tbApplications.SystemBanksGuid).ToList();
											
												var appDocs = new tbApplicationDocs()
												{
													applicationDocsGuid = Guid.NewGuid(),
													CRBGuid = tbApplications.CRBGuid,
												
													docPath = fileName,
													status = 0
												};
												_context.TbApplicationDocs.Add(appDocs);
											}
										}
										if (User.IsInRole("CompanyUser"))
										{
											tbApplications.PIN = Company.PinNo;
										}
										else
										{
											tbApplications.PIN = "Not Available";
										}

                                        tbApplications.approvedAmount = await _dbOps.GetCommisionAmount(tbApplications.amount, tbApplications.SystemBanksGuid, tbApplications.currency, tbApplications.TenderPeriod);

                                        //get max security limit...
                                        var secMax = _context.TbSystemBanks.FirstOrDefault(a => a.SystemBanksGuid == tbApplications.SystemBanksGuid).MaximumSecurityLimit;
                                        if(tbApplications.amount <= secMax)
                                        {
                                            //do automated processing

                                            //call auto proc Logic Here
                                            //alerts _bOTH SMS AND eMAIL
                                            tbApplications.status = 3;
                                            tbApplications.appliedBy = compuser.compUserGuid.ToString();
                                            tbApplications.appDate = DateTime.Now;
                                            tbApplications.checkerComments = "Auto Approved";
                                            tbApplications.checkerDate = DateTime.Now;
                                            tbApplications.expireDate = _dbOps.GetExpDate(tbApplications.bondStartDate, tbApplications.TenderPeriod); //Convert.ToDateTime(tbApplications.bondStartDate.AddDays(Convert.ToInt32(tbApplications.Period)));
                                            tbApplications.approvalDate = DateTime.Now;
                                            _context.Add(tbApplications);
                                            await _context.SaveChangesAsync();
                                            //Do auto approval
                                            await AutoApprove(tbApplications.CRBGuid.ToString());
                                     
                                            foreach (var u in await _dbOps.GetAllBankUsers(tbApplications.SystemBanksGuid))
                                            {
                                                await _dbOps.LogNotification(await _dbOps.GetBankUserSysId(u), 1, "New Automated Application has been Made");
                                            }
                                            return RedirectToAction(nameof(Index));
                                           
                                        }
                                        else
                                        {
                                            //do one for auths
                                            tbApplications.status = 0;
                                            tbApplications.appliedBy = compuser.compUserGuid.ToString();
                                            tbApplications.appDate = DateTime.Now;
                                            tbApplications.expireDate = _dbOps.GetExpDate(tbApplications.bondStartDate, tbApplications.TenderPeriod); //Convert.ToDateTime(tbApplications.bondStartDate.AddDays(Convert.ToInt32(tbApplications.Period)));

                                            _context.Add(tbApplications);
                                            await _context.SaveChangesAsync();
                                            foreach (var u in await _dbOps.GetAllBankUsers(tbApplications.SystemBanksGuid))
                                            {
                                                await _dbOps.LogNotification(await _dbOps.GetBankUserSysId(u), 1, "New Application has been Made, Awaiting Further Bank Approvals");
                                            }
                                            return RedirectToAction(nameof(Index));
                                            
                                        }
                                        //
										
									}
									else
									{
										ModelState.AddModelError("", "Please Upload Tender Documents");
									}
								}
								else
								{
									ModelState.AddModelError("", "Start Date cannot be greater than end date");
								}
							}
							else
							{
								ModelState.AddModelError("", "Please Accept Terms and Conditions");
							}
						}
						else
						{
							ModelState.AddModelError("", "Please Enter a valid Amount");
						}
				 
				   }
					else
					{
						ModelState.AddModelError("", "Bond Start date cannot be older than today");
					}
				}
				else
				{
					if (tbApplications.SystemBanksGuid != Guid.Empty && tbApplications.amount > 0 && tbApplications.currency != "~ Please Select ~")
					{
						commisionAMount = await _dbOps.GetCommisionAmount(tbApplications.amount, tbApplications.SystemBanksGuid, tbApplications.currency, tbApplications.TenderPeriod);
						expireDate = _dbOps.GetExpDate(tbApplications.bondStartDate, tbApplications.TenderPeriod);
						address = _context.TbBeneficialies.FirstOrDefault(c=>c.benGuid==Guid.Parse(tbApplications.Purchaser)).adrress;
											
					
					}

					if (tbApplications.SystemBanksGuid != Guid.Empty)
					{
						ViewData["ShowDoc"] = true;
						ViewData["RequiredDocs"] = _context.TbDocUploadReqs.Where(v => v.SystemBanksGuid == tbApplications.SystemBanksGuid).ToList();
						ViewData["BranchGuid"] = new SelectList(_context.TbBankBranches.Where(m => m.SystemBanksGuid == tbApplications.SystemBanksGuid), "BranchGuid", "branchName", tbApplications.BranchGuid);

					 
					}
				}
			}
			catch (Exception ex)
			{
			   await _dbOps.LogError("Applications/Create", "Make new Application", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
			}
			//  ViewData["appliedBy"] = _context.TbIndivuduals.FirstOrDefault(m => m.indGuid == tbApplications.indGuid).FirstName;
		
			ViewData["CommisionAmount"] = commisionAMount;
			ViewData["ExpiryDate"] = expireDate;
            ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies, "benGuid", "FirstName");
            ViewData["compGuid"] = new SelectList(_context.TbCompanies, "compGuid", "compName", tbApplications.compGuid);
			ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbApplications.indGuid);
			ViewData["SystemBanksGuid"] = _context.TbSystemBanks.ToList();//new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", tbApplications.SystemBanksGuid);
			ViewData["BenefAdderss"] = address;
			ViewData["appDate"] = appDate;
		 
			if (User.IsInRole("Individual"))
			{
			   
				ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies.Where(m => m.indGuid == me.indGuid), "benGuid", "FirstName", tbApplications.Purchaser);
				ViewData["appliedBy"] = _context.TbIndivuduals.SingleOrDefault(m => m.indGuid == me.indGuid).FirstName;
				ViewData["ApplicantAdd"] = _context.TbIndivuduals.SingleOrDefault(m => m.indGuid == me.indGuid).pysicalLoc;
			}
			if (User.IsInRole("CompanyUser"))
			{
				ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies, "benGuid", "FirstName", tbApplications.Purchaser);
				ViewData["appliedBy"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).FirstName;
				ViewData["ApplicantAdd"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).pysicalLoc;
			}


			ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency",tbApplications.currency);
			if (tbApplications.SystemBanksGuid != Guid.Empty)
			{
				ViewData["ShowDoc"] = true;
				ViewData["RequiredDocs"] = _context.TbDocUploadReqs.Where(v => v.SystemBanksGuid == tbApplications.SystemBanksGuid).ToList();
				ViewData["BranchGuid"] = new SelectList(_context.TbBankBranches.Where(m => m.SystemBanksGuid == tbApplications.SystemBanksGuid), "BranchGuid", "branchName", tbApplications.BranchGuid);

			}
			else
			{
				if (tbApplications.SystemBanksGuid != Guid.Empty)
				{
					ViewData["ShowDoc"] = false;
					ViewData["RequiredDocs"] = _context.TbDocUploadReqs.ToList();
					ViewData["BranchGuid"] = new SelectList(_context.TbBankBranches, "BranchGuid", "branchName");

				}
			}
			return View(tbApplications);
		}

		// GET: Applications/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			var me = await _userManager.GetUserAsync(HttpContext.User);
			var compuser = _context.TbCompanyUsers.FirstOrDefault(n => n.compUserGuid == me.compUserGuid);

			var Company = _context.TbCompanies.FirstOrDefault(n => n.registeredBy == me.compUserGuid.ToString());

			if (id == null)
			{
				return NotFound();
			}

			var tbApplications = await _context.TbApplications.SingleOrDefaultAsync(m => m.CRBGuid == id);
			if (tbApplications == null)
			{
				return NotFound();
			}
			//if((tbApplications.status != 0))
			//{
			//	return NotFound();
			//}
   //         if ((tbApplications.status != 6))
   //         {
   //             return NotFound();
   //         }
            ViewData["std"] = ""; 
			ViewData["compGuid"] = new SelectList(_context.TbCompanies, "compGuid", "compName", tbApplications.compGuid);
			ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbApplications.indGuid);
			ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", tbApplications.SystemBanksGuid);
			ViewData["RequiredDocs"] = _context.TbDocUploadReqs.Where(h=>h.SystemBanksGuid == tbApplications.SystemBanksGuid).ToList();
			ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency");
			ViewData["BenefAdderss"] = "Address";
			ViewData["KRAPin"] = "KRAPin";
			if (User.IsInRole("Individual"))
			{
				ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies.Where(m => m.indGuid == me.indGuid), "benGuid", "FirstName");
				ViewData["appliedBy"] = _context.TbIndivuduals.SingleOrDefault(m => m.indGuid == me.indGuid).FirstName;
				ViewData["ApplicantAdd"] = _context.TbIndivuduals.SingleOrDefault(m => m.indGuid == me.indGuid).pysicalLoc;
			}
			if (User.IsInRole("CompanyUser"))
			{
				ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies.Where(m => m.compUserGuid == me.compUserGuid), "benGuid", "FirstName");
				ViewData["appliedBy"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).FirstName;
				ViewData["ApplicantAdd"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).pysicalLoc;
			}
            if (User.IsInRole("BankUser"))
            {
                ViewData["BondProcessingActions"] = new SelectList(_context.BondProcessingActions, "Code", "Description");
              //  ViewData["appliedBy"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).FirstName;
              //  ViewData["ApplicantAdd"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).pysicalLoc;
            }

            ViewData["ShowDoc"] = false;
			ViewData["RequiredDocs"] = _context.TbDocUploadReqs.ToList();         
			return View(tbApplications);
		}

		// POST: Applications/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string Btn, List<IFormFile> files, Guid id, [Bind("CRBGuid,PIN,indGuid,compGuid,appliedBy,appDate,currency,TenderPeriod,tenderNo,Details,SystemBanksGuid,amount,approvedAmount,status,approvalDate,comments,terms,approvedBy,bondStartDate,expireDate,AcceptTerms,Purchaser")] tbApplications tbApplications)
		{
            ViewData["DocumentsVerified"] = true;
            ViewData["DirectorsVerified"] = true;
            ViewData["DirectorsRegistered"] = true;
            ViewData["DocumentsRegistered"] = true;
            decimal commisionAMount = 0;
			var me = await _userManager.GetUserAsync(HttpContext.User);
			var compuser = _context.TbCompanyUsers.FirstOrDefault(n => n.compUserGuid == me.compUserGuid);

			var Company = _context.TbCompanies.FirstOrDefault(n => n.registeredBy == me.compUserGuid.ToString());

			DateTime expireDate = DateTime.Today.Date;

			try
			{
				if (Btn == "Save")
				{
					if (id != tbApplications.CRBGuid)
					{
						return NotFound();
					}
     //               if ((tbApplications.status != 0))
     //               {
					//	return NotFound();
					//}
     //               if ((tbApplications.status != 6))
     //               {
     //                   return NotFound();
     //               }
                    if (tbApplications.bondStartDate.Date >= DateTime.Today.Date)
					{
						if (tbApplications.amount > 0)
						{
							if (tbApplications.AcceptTerms)
							{
								if (tbApplications.bondStartDate < tbApplications.expireDate)
								{
									if (files.Count() < 0)
									{
										//Remove Old Docs
										tbApplications.tenderDocs = "";
										var oldDocs = _context.TbApplicationDocs.Where(s => s.CRBGuid == tbApplications.CRBGuid);
										_context.RemoveRange(oldDocs);
										_context.SaveChanges();
										//tbApplications.CRBGuid = Guid.NewGuid();
								   
										if (User.IsInRole("Individual"))
										{
											tbApplications.indGuid = me.indGuid;
										}
										if (User.IsInRole("CompanyUser") || User.IsInRole("CompanyAdmin"))
										{
											tbApplications.compGuid = _context.TbCompanyUsers.FirstOrDefault(j => j.compUserGuid == me.compUserGuid).compGuid;
										}
					 
										foreach (var file in files)
										{
											if (file != null && file.Length > 0 && !string.IsNullOrEmpty(file.FileName))
											{
												//tbApplications.tbApplicationDocs = "";
												var fileName = Path.GetFileName(file.FileName);
												fileName = tbApplications.CRBGuid + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + fileName;
												//var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
												var uploads = Path.Combine(_env.WebRootPath, "Uploads", fileName);
												//var myfilePath = Path.Combine(uploads, fileName);
												using (var strea = new FileStream(uploads, FileMode.Create))
												{
													await file.CopyToAsync(strea);
													tbApplications.tenderDocs = tbApplications.tenderDocs + ";" + fileName;
												}
												var bankDocs = _context.TbDocUploadReqs.Where(v => v.SystemBanksGuid == tbApplications.SystemBanksGuid).ToList();
												//for(int i = 0, i < fil)
												var appDocs = new tbApplicationDocs()
												{
													applicationDocsGuid = Guid.NewGuid(),
													CRBGuid = tbApplications.CRBGuid,
													//docReqGuid = Guid.NewGuid(),
													//// +++++
													docPath = fileName,
													status = 0
												};
												_context.TbApplicationDocs.Add(appDocs);
											}
										}
										if (User.IsInRole("CompanyUser"))
										{
											tbApplications.PIN = Company.PinNo;
										}
										else
										{
											tbApplications.PIN = "Not Available";
										}
										tbApplications.status = 0;
										tbApplications.appliedBy = me.Id;
										tbApplications.appDate = DateTime.Now;
										tbApplications.approvedAmount = await _dbOps.GetCommisionAmount(tbApplications.amount, tbApplications.SystemBanksGuid, tbApplications.currency, tbApplications.TenderPeriod);
										tbApplications.expireDate = _dbOps.GetExpDate(tbApplications.bondStartDate, tbApplications.TenderPeriod); //Convert.ToDateTime(tbApplications.bondStartDate.AddDays(Convert.ToInt32(tbApplications.Period)));
                                        tbApplications.ClientPrinted = false;
                                        tbApplications.ClientPreviewApproved = false;
                                        tbApplications.BidBondDocStatus = 0100;
                                        tbApplications.BidBondPath = "";
                                        tbApplications.ActionCode = "";
                                        //if (ModelState.IsValid)
                                        //{
                                        //tbApplications.CRBGuid = Guid.NewGuid();
                                        //_context.Add(tbApplications);
                                        _context.Update(tbApplications);
										await _context.SaveChangesAsync();
										return RedirectToAction(nameof(Index));
										//}
									}
									else
									{
										ModelState.AddModelError("", "Please Upload Tender Documents");
									}
								}
								else
								{
									ModelState.AddModelError("", "Start Date cannot be greater than end date");
								}
							}
							else
							{
								ModelState.AddModelError("", "Please Accept Terms and Coditions");
							}
						}
						else
						{
							ModelState.AddModelError("", "Please Enter a valid Amount");
						}
					}
					else
					{
						ModelState.AddModelError("", "Bond Start date cannot be older than today");
					}
				}
				else
				{
					//var ff = tbApplications.SystemBanksGuid == Guid.Empty;
					if (tbApplications.SystemBanksGuid != Guid.Empty && tbApplications.amount > 0 && tbApplications.currency != "~ Please Select ~")
					{
						commisionAMount = await _dbOps.GetCommisionAmount(tbApplications.amount, tbApplications.SystemBanksGuid, tbApplications.currency, tbApplications.TenderPeriod);

						expireDate = _dbOps.GetExpDate(tbApplications.bondStartDate, tbApplications.TenderPeriod);
					}
					if (tbApplications.SystemBanksGuid != Guid.Empty)
					{
						ViewData["ShowDoc"] = true;
						ViewData["RequiredDocs"] = _context.TbDocUploadReqs.Where(v => v.SystemBanksGuid == tbApplications.SystemBanksGuid).ToList();
					}
				}
			}
			catch (Exception ex)
			{
				await _dbOps.LogError("Applications/Create", "Make new Application", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
			}
			ViewData["CommisionAmount"] = commisionAMount;
			ViewData["compGuid"] = new SelectList(_context.TbCompanies, "compGuid", "compName", tbApplications.compGuid);
			ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbApplications.indGuid);
			ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", tbApplications.SystemBanksGuid);
			ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency", tbApplications.currency);
			ViewData["BenefAdderss"] = "Address";
			ViewData["KRAPin"] = "KRAPin";
			if (User.IsInRole("Individual"))
			{
				ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies, "benGuid", "FirstName");
				ViewData["appliedBy"] = _context.TbIndivuduals.SingleOrDefault(m => m.indGuid == me.indGuid).FirstName;
				ViewData["ApplicantAdd"] = _context.TbIndivuduals.SingleOrDefault(m => m.indGuid == me.indGuid).pysicalLoc;
			}
			if (User.IsInRole("CompanyUser"))
			{
				ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies, "benGuid", "FirstName");
				ViewData["appliedBy"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).FirstName;
				ViewData["ApplicantAdd"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).pysicalLoc;
			}

			if (tbApplications.SystemBanksGuid != Guid.Empty)
			{
				ViewData["ShowDoc"] = true;
				ViewData["RequiredDocs"] = _context.TbDocUploadReqs.Where(v => v.SystemBanksGuid == tbApplications.SystemBanksGuid).ToList();
			}
			else
			{
				if (tbApplications.SystemBanksGuid != Guid.Empty)
				{
					ViewData["ShowDoc"] = false;
					ViewData["RequiredDocs"] = _context.TbDocUploadReqs.ToList();
				}
			}
			ViewData["std"] = "";
			return View(tbApplications);
		}
        public async Task<IActionResult> ClientToBankAmmend(Guid? id)
        {
            var me = await _userManager.GetUserAsync(HttpContext.User);
            var compuser = _context.TbCompanyUsers.FirstOrDefault(n => n.compUserGuid == me.compUserGuid);

            var bankGuid = _context.TbApplications.FirstOrDefault(c => c.CRBGuid == id).SystemBanksGuid;

            var Company = _context.TbCompanies.FirstOrDefault(n => n.compGuid == compuser.compGuid);


            if (id == null)
            {
                return NotFound();
            }

            var tbApplications = await _context.TbApplications.AsNoTracking().SingleOrDefaultAsync(m => m.CRBGuid == id);
            if (tbApplications == null)
            {
                return NotFound();
            }
            //if((tbApplications.status != 0))
            //{
            //	return NotFound();
            //}
            //         if ((tbApplications.status != 6))
            //         {
            //             return NotFound();
            //         }
            ViewData["std"] = "";
            ViewData["compGuid"] = new SelectList(_context.TbCompanies, "compGuid", "compName", tbApplications.compGuid);
            ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbApplications.indGuid);
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", bankGuid);
            ViewData["BankName"] = new SelectList(_context.TbSystemBanks.Where(c=>c.SystemBanksGuid== bankGuid),"bankName");
            ViewData["RequiredDocs"] = _context.TbDocUploadReqs.Where(h => h.SystemBanksGuid == bankGuid).ToList();
            ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency");
            ViewData["ExpiryDate"] = tbApplications.expireDate;
            ViewData["BenefAdderss"] = "Address";
            ViewData["KRAPin"] = "KRAPin";
            if (User.IsInRole("Individual"))
            {
                ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies, "benGuid", "FirstName");
                ViewData["appliedBy"] = _context.TbIndivuduals.SingleOrDefault(m => m.indGuid == me.indGuid).FirstName;
                ViewData["ApplicantAdd"] = _context.TbIndivuduals.SingleOrDefault(m => m.indGuid == me.indGuid).pysicalLoc;
            }
            if (User.IsInRole("CompanyUser"))
            {
                ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies, "benGuid", "FirstName");
                ViewData["appliedBy"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).FirstName;
                ViewData["ApplicantAdd"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).pysicalLoc;
            }
            if (User.IsInRole("BankUser"))
            {
                ViewData["BondProcessingActions"] = new SelectList(_context.BondProcessingActions, "Code", "Description");
                //  ViewData["appliedBy"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).FirstName;
                //  ViewData["ApplicantAdd"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).pysicalLoc;
            }

            ViewData["ShowDoc"] = false;
            ViewData["RequiredDocs"] = _context.TbDocUploadReqs.Where(h => h.SystemBanksGuid == bankGuid).ToList();
            return View(tbApplications);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClientToBankAmmend(string Btn, List<IFormFile> files, Guid id, [Bind("CRBGuid,PIN,indGuid,compGuid,appliedBy,appDate,currency,TenderPeriod,tenderNo,Details,SystemBanksGuid,amount,approvedAmount,status,approvalDate,comments,terms,approvedBy,bondStartDate,expireDate,AcceptTerms,Purchaser")] tbApplications tbApplications)
        {
            decimal commisionAMount = 0;
            var me = await _userManager.GetUserAsync(HttpContext.User);
            var compuser = _context.TbCompanyUsers.FirstOrDefault(n => n.compUserGuid == me.compUserGuid);
            var bankGuid = _context.TbApplications.AsNoTracking().FirstOrDefault(c => c.CRBGuid == id).SystemBanksGuid;
            var brGuid = _context.TbApplications.AsNoTracking().FirstOrDefault(c => c.CRBGuid == id).BranchGuid;

            var Company = _context.TbCompanies.FirstOrDefault(n => n.compGuid == compuser.compGuid);

            DateTime expireDate = DateTime.Today.Date;

            try
            {
                if (Btn == "Save")
                {
                    if (id != tbApplications.CRBGuid)
                    {
                        return NotFound();
                    }
                    //               if ((tbApplications.status != 0))
                    //               {
                    //	return NotFound();
                    //}
                    //               if ((tbApplications.status != 6))
                    //               {
                    //                   return NotFound();
                    //               }
                    if (tbApplications.bondStartDate.Date >= DateTime.Today.Date)
                    {
                        if (tbApplications.amount > 0)
                        {
                            if (tbApplications.AcceptTerms)
                            {
                                if (tbApplications.bondStartDate <  tbApplications.expireDate)
                                {
                                    if (files.Count() > 0)
                                    {
                                        //Remove Old Docs
                                        tbApplications.tenderDocs = "";
                                        var oldDocs = _context.TbApplicationDocs.AsNoTracking().Where(s => s.CRBGuid == tbApplications.CRBGuid);
                                        _context.RemoveRange(oldDocs);
                                        _context.SaveChanges();
                                        //tbApplications.CRBGuid = Guid.NewGuid();

                                        if (User.IsInRole("Individual"))
                                        {
                                            tbApplications.indGuid = me.indGuid;
                                        }
                                        if (User.IsInRole("CompanyUser") || User.IsInRole("CompanyAdmin"))
                                        {
                                            tbApplications.compGuid = _context.TbCompanyUsers.FirstOrDefault(j => j.compUserGuid == me.compUserGuid).compGuid;
                                        }

                                        foreach (var file in files)
                                        {
                                            if (file != null && file.Length > 0 && !string.IsNullOrEmpty(file.FileName))
                                            {
                                                //tbApplications.tbApplicationDocs = "";
                                                var fileName = Path.GetFileName(file.FileName);
                                                fileName = tbApplications.CRBGuid + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + fileName;
                                                //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                                                var uploads = Path.Combine(_env.WebRootPath, "Uploads", fileName);
                                                //var myfilePath = Path.Combine(uploads, fileName);
                                                using (var strea = new FileStream(uploads, FileMode.Create))
                                                {
                                                    await file.CopyToAsync(strea);
                                                    tbApplications.tenderDocs = tbApplications.tenderDocs + ";" + fileName;
                                                }
                                                var bankDocs = _context.TbDocUploadReqs.Where(v => v.SystemBanksGuid == bankGuid).ToList();
                                                //for(int i = 0, i < fil)
                                                var appDocs = new tbApplicationDocs()
                                                {
                                                    applicationDocsGuid = Guid.NewGuid(),
                                                    CRBGuid = tbApplications.CRBGuid,
                                                    //docReqGuid = Guid.NewGuid(),
                                                    //// +++++
                                                    docPath = fileName,
                                                    status = 0
                                                };
                                                _context.TbApplicationDocs.Add(appDocs);
                                            }
                                        }
                                        if (User.IsInRole("CompanyUser"))
                                        {
                                            tbApplications.PIN = Company.PinNo;
                                        }
                                        else
                                        {
                                            tbApplications.PIN = "Not Available";
                                        }
                                        tbApplications.status = 50;
                                       // tbApplications.PrintCode = "";
                                        tbApplications.appliedBy = me.compUserGuid.ToString();
                                        tbApplications.appDate = DateTime.Now;
                                        tbApplications.approvedAmount = await _dbOps.GetPostAmmendCommisionAmount(tbApplications.amount, bankGuid, tbApplications.currency, tbApplications.TenderPeriod);
                                        tbApplications.expireDate = _dbOps.GetExpDate(tbApplications.bondStartDate, tbApplications.TenderPeriod); //Convert.ToDateTime(tbApplications.bondStartDate.AddDays(Convert.ToInt32(tbApplications.Period)));
                                        tbApplications.ClientPrinted = false;
                                        tbApplications.ClientPreviewApproved = false;
                                        tbApplications.BidBondDocStatus = 0100;
                                        tbApplications.BidBondPath = "";
                                        tbApplications.ActionCode = "";
                                        tbApplications.SystemBanksGuid = bankGuid;
                                        tbApplications.BranchGuid = brGuid;
                                        tbApplications.BankComm= await _dbOps.GetBankPostAmmendCommisionAmount(tbApplications.amount, bankGuid, tbApplications.currency, tbApplications.TenderPeriod);
                                        tbApplications.CoreBankingReferenceNumber = "";
                                        //if (ModelState.IsValid)
                                        //{
                                        //tbApplications.CRBGuid = Guid.NewGuid();
                                        //_context.Add(tbApplications);
                                        _context.Update(tbApplications);
                                        await _context.SaveChangesAsync();
                                        return RedirectToAction(nameof(Index));
                                        //}
                                    }
                                    else
                                    {
                                        ModelState.AddModelError("", "Please Upload Tender Documents");
                                    }
                                }
                                else
                                {
                                    ModelState.AddModelError("", "Start Date cannot be greater than end date");
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("", "Please Accept Terms and Coditions");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please Enter a valid Amount");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bond Start date cannot be older than today");
                    }
                }
                else
                {
                    //var ff = tbApplications.SystemBanksGuid == Guid.Empty;
                    if (bankGuid != Guid.Empty && tbApplications.amount > 0 && tbApplications.currency != "~ Please Select ~")
                    {
                        commisionAMount = await _dbOps.GetBankPostAmmendCommisionAmount(tbApplications.amount, bankGuid, tbApplications.currency, tbApplications.TenderPeriod);

                        expireDate = _dbOps.GetExpDate(tbApplications.bondStartDate, tbApplications.TenderPeriod);
                    }
                    if (bankGuid != Guid.Empty)
                    {
                        ViewData["ShowDoc"] = true;
                        ViewData["RequiredDocs"] = _context.TbDocUploadReqs.Where(v => v.SystemBanksGuid == bankGuid).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                await _dbOps.LogError("Applications/Create", "Make new Application", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
            }
            ViewData["CommisionAmount"] = commisionAMount;
            ViewData["ExpiryDate"] = expireDate;
            ViewData["compGuid"] = new SelectList(_context.TbCompanies, "compGuid", "compName", tbApplications.compGuid);
            ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbApplications.indGuid);
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", bankGuid);
            ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency", tbApplications.currency);
            ViewData["BenefAdderss"] = "Address";
            ViewData["KRAPin"] = "KRAPin";
            if (User.IsInRole("Individual"))
            {
                ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies, "benGuid", "FirstName");
                ViewData["appliedBy"] = _context.TbIndivuduals.SingleOrDefault(m => m.indGuid == me.indGuid).FirstName;
                ViewData["ApplicantAdd"] = _context.TbIndivuduals.SingleOrDefault(m => m.indGuid == me.indGuid).pysicalLoc;
            }
            if (User.IsInRole("CompanyUser"))
            {
                ViewData["Beneficiary"] = new SelectList(_context.TbBeneficialies, "benGuid", "FirstName");
                ViewData["appliedBy"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).FirstName;
                ViewData["ApplicantAdd"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).pysicalLoc;
            }

            if (bankGuid != Guid.Empty)
            {
                ViewData["ShowDoc"] = true;
                ViewData["RequiredDocs"] = _context.TbDocUploadReqs.Where(v => v.SystemBanksGuid == bankGuid).ToList();
            }
            else
            {
                if (bankGuid == Guid.Empty)
                {
                    ViewData["ShowDoc"] = false;
                    ViewData["RequiredDocs"] = _context.TbDocUploadReqs.ToList();
                }
            }
            ViewData["std"] = "";
            return View(tbApplications);
        }


        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var tbApplications = await _context.TbApplications
				.Include(t => t.tbSystemBanks)
				.SingleOrDefaultAsync(m => m.CRBGuid == id);
			if (tbApplications == null)
			{
				return NotFound();
			}

			return View(tbApplications);
		}

		// POST: Applications/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var tbApplications = await _context.TbApplications.SingleOrDefaultAsync(m => m.CRBGuid == id);
			_context.TbApplications.Remove(tbApplications);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool tbApplicationsExists(Guid id)
		{
			return _context.TbApplications.Any(e => e.CRBGuid == id);
		}
	}


    public class CompanyDocumentDetails
    {
        [Display(Name = "Registration Certificate")]
        public string RegCert { get; set; }

        [Display(Name = "Pin Certificate")]
        public string PinCert { get; set; }

        [Display(Name = "Cr12 Form")]
        public string Cr12 { get; set; }

        [Display(Name = "Board Resolution")]
        public string BoardResolution { get; set; }

        public CompanyDocs compDocs { get; set; }


    }
    public class CompanyDetails
	{
		[Display(Name = "Applicant Name")]
		public string appliedby { get; set; }

		[Display(Name = "Applicant Address")]
		public string ApplicantAddress { get; set; }

		[Display(Name = "Mobile Number")]
		public string Contact { get; set; }

		public tbCompanies company { get; set; }

		public tbCRBChecks crb { get; set; }
		public List<tbDirectors> directors { get; set; }
		public CompanyDocs compDocs { get; set; }


	}
	public class applicationDetails
	{
		[Display(Name = "Applicant Name")]
		public string appliedby { get; set; }
		public tbApplications aplication { get; set; }
		public List< tbApplicationDocs> docs { get; set; }
		public tbCRBChecks crb { get; set; }

		[Display(Name = "Approved By")]
		public string approvedby { get; set; }
        public string PaymentOption { get; set; }

        [Display(Name = "Checked By")]
		public string checkedby { get; set; }

		[Display(Name = "Applicant Address")]
		public string ApplicantAddress { get; set; }

		[Display(Name = "Beneficiary Name")]
		public string BenefName { get; set; }
        [Display(Name = "Action")]
        public string ActionCode { get; set; }

        [Display(Name = "Beneficiary Address")]
		public string BenefAddress { get; set; }

        [Display(Name = "Telephone Number")]
        public string Telephone { get; set; }
    }
}
