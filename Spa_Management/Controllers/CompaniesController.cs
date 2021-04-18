using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Models;
using Spa_Management.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Xml;

namespace Spa_Management.Controllers
{
	public class CompaniesController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IDbOperations _dbOps;
		private readonly UserManager<ApplicationUser> _userManager;
		public CompaniesController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> manager)
		{
			_dbOps = dbOps;
			_context = context;
			_userManager = manager;


		}

		// GET: Companies
		public async Task<IActionResult> Index(int id)
		{
            var ApplicationDbContext = id == 0 ? _context.TbCompanies : _context.TbCompanies.AsNoTracking().Where(c => c.status == 0);/*.AsNoTracking().FirstOrDefault(c=>c.status==0)*/;
			return View(await ApplicationDbContext.ToListAsync());
		}

		// GET: Companies/Details/5

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
                //ViewData["BankGuid"] = id.Value;
                ViewData["compGuid"] = id.Value;
                ViewData["CompanyName"] = _context.TbCompanies.FirstOrDefault(k => k.compGuid == id).compName;
                var users = await _context.TbCompanyUsers.Where(h => h.compGuid == id).ToListAsync();
                //.SingleOrDefaultAsync(m => m.SystemBanksGuid == id);
                if (users == null)
                {
                    return NotFound();
                }
                List<ViewcompanyUsers> _CompUsers = new List<ViewcompanyUsers>();
                int i = 1;
                foreach (var a in users)
                {
                    ViewcompanyUsers user = new ViewcompanyUsers()
                    {
                        id = i++,
                        compUserGuid = a.compUserGuid,
                        Name = string.Format("{0} {1} {2}", a.SirName, a.FirstName, a.LastName),
                        contact = a.contact,
                        Email = a.email,
                        idNumber = a.idNumber,
                        Role = await _dbOps.GetUserRole(a.compUserGuid, 1),
                        status = a.status
                    };
                    _CompUsers.Add(user);
                }
                ViewData["CompanyName"] = _context.TbCompanies.FirstOrDefault(k => k.compGuid == id).compName;
                ViewData["compGuid"] = id;
                //return View(await ApplicationDbContext.ToListAsync());
                return View(_CompUsers);
            }
            catch (Exception ex)
            {

                await _dbOps.LogError("Companies/Users", "Find Users", "", ex.Message.ToString(), ex.InnerException is null ? "" : ex.InnerException.ToString());
                return NotFound();
            }
			
			//return View(users);
		}

        public async Task<IActionResult> ApproveDocs(string Details1, string btn, string appId)
        {
            try
            {
                if (appId == null)
                {
                    return NotFound();
                }
                Guid gui = Guid.Parse(appId);
                using (_context)
                {
                    var tbCompanyDocs = _context.TbCompanyDocs
                                   .FirstOrDefault(m => m.Id == gui);

                 //   var appicantId = tbCompanyDocs.ApplicantId;

                   // var applicantDetails = _context.TbCompanyUsers.FirstOrDefaultAsync(c => c.compUserGuid == appicantId);


                    if (tbCompanyDocs == null)
                    {
                        return NotFound();
                    }
                    var ToEmail = _context.Users.FirstOrDefault(c => c.Id == tbCompanyDocs.ApplicantId.ToString());
                    if (btn == "Approve")
                    {
                        if (tbCompanyDocs.Status == 0)
                        {
                            tbCompanyDocs.Status = 1;
                            tbCompanyDocs.AdminComments = Details1;
                            tbCompanyDocs.Verified = true;

                            //log info to users
                            //send them mails and sms
                       

                             await _dbOps.LogNotification(tbCompanyDocs.ApplicantId.ToString(), 1, "Your Company Documents have been verified");
                             await _dbOps.LogAndSendMail(ToEmail.Email,"TradePawa Documents Approval","Dear Applicant ,Your Company Documents have been verified successfully");
                        }
                        else
                          if (tbCompanyDocs.Status == 4)
                        {
                            tbCompanyDocs.Status = 5;
                            tbCompanyDocs.Verified = true;
                            tbCompanyDocs.AdminComments = Details1;
                            //Send ammendment acknowledgement
                            await _dbOps.LogNotification(tbCompanyDocs.ApplicantId.ToString(), 1, "Your Company Documents have been verified");
                            await _dbOps.LogAndSendMail(ToEmail.Email, "TradePawa Documents Approval", "Dear Applicant ,Your Company Documents have been verified successfully");
                        }
                        else
                        {
                        }

                    }
                    if (btn == "Reject")
                    {
                        if (tbCompanyDocs.Status == 0)
                        {
                            tbCompanyDocs.Status = 2;
                            tbCompanyDocs.Verified = false;
                            tbCompanyDocs.AdminComments = Details1;
                            await _dbOps.LogNotification(tbCompanyDocs.ApplicantId.ToString(), 1, "Your Company Documents have not been verified . " +Details1);
                            await _dbOps.LogAndSendMail(ToEmail.Email, "TradePawa Documents Approval Declined", "Dear Applicant ,Your Company Documents have not been verified successfully. " +Details1);
                            //     await _dbOps.LogNotification(profile.Id, 1, "Your Application has been Rejected step 1");
                            //_dbOps.logandSendSMS(profile.PhoneNumber, "Your Application has been Rejected step 1");
                        }
                        else
                        if (tbCompanyDocs.Status == 4)
                        {
                            //4 is for ammended one
                            //if rejected flag with 6
                            //if approved flag with 5
                            tbCompanyDocs.Status = 6;
                            tbCompanyDocs.Verified = false;
                            tbCompanyDocs.AdminComments = Details1;
                            await _dbOps.LogNotification(tbCompanyDocs.ApplicantId.ToString(), 1, "Your Company Documents have not been verified . "+Details1);
                            await _dbOps.LogAndSendMail(ToEmail.Email, "TradePawa Documents Approval Declined", "Dear Applicant ,Your Company Documents have not been Verified . "+ Details1 + "");
                        }
                        {


                        }
                    }
                    _context.Update(tbCompanyDocs);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
                //   return RedirectToAction(nameof(Details{ ""}));
            }
            catch (Exception ex)
            {
                await _dbOps.LogError("Companies/ApproveDocs", "Approve Company Docs", "", ex.Message.ToString(), ex.InnerException is null ? "" : ex.InnerException.ToString());

                return RedirectToAction(nameof(Index));
            }
           
        }
        public async Task<IActionResult> Directors(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                //ViewData["BankGuid"] = id.Value;
                ViewData["compGuid"] = id.Value;
                ViewData["CompanyName"] = _context.TbCompanies.FirstOrDefault(k => k.compGuid == id).compName;
                var users = await _context.TbDirectors.Where(h => h.CompanyId == id).ToListAsync();
                //.SingleOrDefaultAsync(m => m.SystemBanksGuid == id);
                if (users == null)
                {
                    return NotFound();
                }
                List<ViewcompanyDirectors> _CompUsers = new List<ViewcompanyDirectors>();
                int i = 1;
                foreach (var a in users)
                {
                    ViewcompanyDirectors user = new ViewcompanyDirectors()
                    {
                        id = i++,
                        DirectorId = a.Id,
                        FirsName = a.FirstName, //string.Format("{0} {1}", a.FirstName, a.LastName),
                        TelephoneNumber = a.TelephoneNumber,
                        Email = a.Email,
                        idNumber = a.IdNumber,
                        LastName = a.LastName,
                        MiddleName = a.MiddleName,
                        // Role = await _dbOps.GetUserRole(a.compUserGuid, 1),
                        status = a.Verified
                    };
                    _CompUsers.Add(user);
                }
                ViewData["CompanyName"] = _context.TbCompanies.FirstOrDefault(k => k.compGuid == id).compName;
                ViewData["compGuid"] = id;
                //return View(await ApplicationDbContext.ToListAsync());
                return View(_CompUsers);

            }
            catch (Exception ex)
            {

                await _dbOps.LogError("Companies/Directors", "Add new Director", "", ex.Message.ToString(), ex.InnerException is null ? "" : ex.InnerException.ToString());
                return NotFound();
            }

            //return View(users);
        }
        // GET: Companies/Create
        public IActionResult Create() =>
			//ViewData["BankCode"] = new SelectList(_context.TbBanks, "BankCode", "bank");
			//ViewData["branchCode"] = new SelectList(_context.TbBranches, "branchCode", "branch");
			View();

		// POST: Companies/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("compGuid,compName,email,pysicalLoc,postalAddress,PostalCode,PinNo,RegCertNo,contact,incDate,incNum,regDate,BankCode,branchCode,accNum,status")] tbCompanies tbCompanies)
		{
			try
			{
				tbCompanies comp = await _context.TbCompanies.SingleOrDefaultAsync(m => m.compName == tbCompanies.compName
				&& m.contact == tbCompanies.contact && m.email == tbCompanies.email);
				tbCompanies.status = 0;
				tbCompanies.regDate = DateTime.Now;
				//  tbco
				if (comp != null)
				{
					ModelState.AddModelError(string.Empty, "This company already exists");
					return View(tbCompanies);
				}
				else
				{
					tbCompanies.compGuid = Guid.NewGuid();
					_context.Add(tbCompanies);
					await _context.SaveChangesAsync();
					await _dbOps.AuditOperation(User.Identity.Name, "Companies/Create", "Added a new company " + tbCompanies.compGuid.ToString(), "", "Companies");
					return RedirectToAction(nameof(Index));
				}

			}
			catch (Exception ex)
			{
				await _dbOps.LogError("Companies/Create", "Add new company", "", ex.Message.ToString(), ex.InnerException is null ? "" : ex.InnerException.ToString());
			}

			//ViewData["BankCode"] = new SelectList(_context.TbBanks, "BankCode", "bank", tbCompanies.BankCode);
			//ViewData["branchCode"] = new SelectList(_context.TbBranches, "branchCode", "branch", tbCompanies.branchCode);
			return View(tbCompanies);
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult verify()
		{
			return View();
		}

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CompanyExists()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult EmailUsed()
        {
            return View();
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

        //LoadUnverified

        //public async Task<IActionResult> LoadUnverified()
        //{
        //    var ApplicationDbContext = _context.TbCompanies.AsNoTracking().FirstOrDefault(c=>c.status==0);
        //    return View(await ApplicationDbContext.ToList());
        //}

        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CompanySignUp([Bind("compGuid,compName,email,pysicalLoc,postalAddress,PostalCode,PinNo,RegCertNo,contact,incDate,incNum,regDate,BankCode,branchCode,accNum,status")] tbCompanies tbCompanies, [Bind("compGuid,compUserGuid,designation,SirName,FirstName,LastName,contact,email,gender,dob,idType,idNumber,status")] tbCompanyUsers tbCompanyUsers)
		{
			try
			{
                string address = "Address";
                ViewData["postalAddress"] = address;


                //if ((tbCompanies.compName == null) || (tbCompanies.PinNo == null))
                //{
                //    ViewData["Message"] = "Please fill all required details";

                //    ModelState.AddModelError("", "Please fill all required details");
                //    return View(tbCompanies);
                //    // return RedirectToAction(nameof(HomeController.CompanySignUp), "Home");
                //}

                var user = await _userManager.FindByEmailAsync(tbCompanyUsers.email);

                if (user != null)
                {
                    ModelState.AddModelError(string.Empty, "The Applicant email is already used");
                    return RedirectToAction(nameof(EmailUsed));
                }

                tbCompanies comp = await _context.TbCompanies.SingleOrDefaultAsync(m => m.compName == tbCompanies.compName
                
				&& m.contact == tbCompanies.contact && m.email == tbCompanies.email);
				tbCompanies.status = 0;
				tbCompanies.regDate = DateTime.Now;
                tbCompanies.FirstTimeUse = true;
               
                if (comp != null)
				{
					ModelState.AddModelError(string.Empty, "This company already exists");
                    return RedirectToAction(nameof(CompanyExists));
                }
				else
				{
					tbCompanies.compGuid = Guid.NewGuid();

					var users = new tbCompanyUsers()
					{
						compGuid = tbCompanies.compGuid,
						compUserGuid = tbCompanyUsers.compUserGuid,
						SirName = tbCompanyUsers.SirName ?? "",
						FirstName = tbCompanyUsers.FirstName ?? "",
                        LastName=tbCompanyUsers.LastName ?? "",
						contact = phoneNumberNomalizer.phoneNum(tbCompanyUsers.contact),
						email = tbCompanyUsers.email,
						idNumber = tbCompanyUsers.idNumber,
						status = 0,
                        
					};
                    address = _context.tbPostalCodes.FirstOrDefault(c => c.Code ==int.Parse(tbCompanies.PostalCode)).RegionName;
                    ViewData["postalAddress"] = address;
                    tbCompanies.postalAddress = address ?? "Address";
                    _context.TbCompanyUsers.Add(users);
					tbCompanies.registeredBy = users.compUserGuid.ToString();
					_context.Add(tbCompanies);
					await _context.SaveChangesAsync();
                    await _dbOps.LogAndSendMail(users.email, "Company Registration", "Dear " + users.FirstName + ", Thank you for registering your company with us. You will receive an email notification once your details have been verified");
                    await _dbOps.LogandSendSMS(users.contact, "Dear " + users.FirstName + ", Thank you for registering your company with us. You will receive an email notification once your details have been verified", "", "", "");
                    await _dbOps.AuditOperation(tbCompanyUsers.compUserGuid.ToString(), "Companies/Create", "Added a new company " + tbCompanies.compGuid.ToString(), "", "Companies");
                    return RedirectToAction(nameof(verify));
                }

            }
			catch (Exception ex)
			{
				await _dbOps.LogError("Companies/Create", "Add new company", "", ex.Message.ToString(), ex.InnerException is null ? "" : ex.InnerException.ToString());
				// return RedirectToAction(nameof(HomeController.Index), "Home");
			}

            //return View(tbCompanies);
            return RedirectToAction(nameof(verify));
        }


		// GET: Companies/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var tbCompanies = await _context.TbCompanies.SingleOrDefaultAsync(m => m.compGuid == id);
			if (tbCompanies == null)
			{
				return NotFound();
			}
			//ViewData["BankCode"] = new SelectList(_context.TbBanks, "BankCode", "bank", tbCompanies.BankCode);
			//ViewData["branchCode"] = new SelectList(_context.TbBranches, "branchCode", "branch", tbCompanies.branchCode);
			return View(tbCompanies);
		}

		// POST: Companies/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("compGuid,compName,email,pysicalLoc,postalAddress,PostalCode,PinNo,RegCertNo,contact,incDate,incNum,regDate,BankCode,branchCode,accNum,status")] tbCompanies tbCompanies)
		{
			if (id != tbCompanies.compGuid)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(tbCompanies);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!tbCompaniesExists(tbCompanies.compGuid))
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
			//ViewData["BankCode"] = new SelectList(_context.TbBanks, "BankCode", "bank", tbCompanies.BankCode);
			//ViewData["branchCode"] = new SelectList(_context.TbBranches, "branchCode", "branch", tbCompanies.branchCode);
			return View(tbCompanies);
		}

		// GET: Companies/Delete/5
		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var tbCompanies = await _context.TbCompanies
				//.Include(t => t.tbBanks)
				//.Include(t => t.tbBranches)
				.SingleOrDefaultAsync(m => m.compGuid == id);
			if (tbCompanies == null)
			{
				return NotFound();
			}

			return View(tbCompanies);
		}

		// POST: Companies/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			try
			{
				var tbCompanies = await _context.TbCompanies.SingleOrDefaultAsync(m => m.compGuid == id);
				_context.TbCompanies.Remove(tbCompanies);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				await _dbOps.LogError("Companies/DeleteConfirmed", "Delete", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());

			}
			return NotFound();

		}

		private bool tbCompaniesExists(Guid id)
		{
			return _context.TbCompanies.Any(e => e.compGuid == id);
		}

        //VerifyDirectors
        [Authorize(Roles = ("MasterAdmin"))]
        public async Task<IActionResult> VerifyDirectors(string btn, string compDirID,string Comment)
        {
            try
            {
                if (compDirID == null)
                {
                    //redirect to error page
                    return NotFound();
                }
                Guid gui = Guid.Parse(compDirID);

                var tbCompanies = await _context.TbDirectors
                    .SingleOrDefaultAsync(m => m.Id == gui);

                if (tbCompanies == null)
                {
                    return NotFound();
                }

                var me = await _userManager.GetUserAsync(HttpContext.User);

                var ToEmail = _context.Users.FirstOrDefault(c => c.Id == tbCompanies.Maker.ToString());

                //var user = _context.TbCompanyUsers.FirstOrDefault(g => g.compUserGuid.ToString() == tbCompanies.registeredBy);

                // var profile = _context.Users.FirstOrDefault(j => j.Id == user.systemID);
                if (btn == "Approve")
                    {
                        if (tbCompanies.Verified ==false)
                        {

                            tbCompanies.Verified = true;
                            tbCompanies.CheckerComments = Comment;
                            tbCompanies.Checker = me.userGuid;
                            _context.Update(tbCompanies);
                            await _context.SaveChangesAsync();
                        await _dbOps.LogNotification(tbCompanies.Maker.ToString(), 1, "Your Company Director "+ tbCompanies .FirstName+ " has  been verified");
                        await _dbOps.LogAndSendMail(ToEmail.Email, "TradePawa Directors Approval", "Dear Applicant ,Your Company Director "+ tbCompanies .FirstName+ ", has been verified successfully");
                        return RedirectToAction(nameof(Index));
                        }

                    }
                    if (btn == "Reject")
                    {
                        if (tbCompanies.Verified == false)
                        {

                            tbCompanies.Verified = true;
                            tbCompanies.CheckerComments = Comment;
                            tbCompanies.Checker = me.userGuid;
                             _context.Update(tbCompanies);
                            await _context.SaveChangesAsync();
                        await _dbOps.LogNotification(tbCompanies.Maker.ToString(), 1, "Your Company Director " + tbCompanies.FirstName + " has  been not verified");
                        await _dbOps.LogAndSendMail(ToEmail.Email, "TradePawa Directors Approval Declined", "Dear Applicant ,Your Company Director " + tbCompanies.FirstName + ", has been not been verified successfully"); return RedirectToAction(nameof(Index));
                        }
                    }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                //throw ex;
               await _dbOps.LogError("Directors/Verify", "Verify", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());

            }
            return RedirectToAction(nameof(Index));
            //return NotFound();
        }

        [Authorize(Roles = ("MasterAdmin"))]
		public async Task<IActionResult> Verify(string btn, string compID)
		{
			try
			{
				if (compID == null)
				{
					return NotFound();
				}
				Guid gui = Guid.Parse(compID);

				var tbCompanies = await _context.TbCompanies
					.SingleOrDefaultAsync(m => m.compGuid == gui);

				if (tbCompanies == null)
				{
					return NotFound();
				}

				var me = await _userManager.GetUserAsync(HttpContext.User);


				var user = _context.TbCompanyUsers.FirstOrDefault(g => g.compUserGuid.ToString() == tbCompanies.registeredBy);
				if (!object.ReferenceEquals(user, null))
				{
					// var profile = _context.Users.FirstOrDefault(j => j.Id == user.systemID);
					if (btn == "Verify")
					{
						if (tbCompanies.status == 0)
						{

							tbCompanies.status = 1;
                            tbCompanies.FirstTimeUse = true;
                            var Adduser = new ApplicationUser
							{
								UserName = user.email,
								Email = user.email,
								compUserGuid = user.compUserGuid,
								PhoneNumber = phoneNumberNomalizer.phoneNum(user.contact),
								EmailConfirmed = true

							};
							//Send Email

							var pass = _dbOps.GenerateRandomPassword(); // + "aA1@";
							var result = await _userManager.CreateAsync(Adduser, pass);
							var code = await _userManager.GenerateEmailConfirmationTokenAsync(Adduser);
							//var callbackUrl = Url.EmailConfirmationLink(Adduser.Id, code, Request.Scheme);
							//_dbOps.LogAndSendMail(user.email, "Email Confirmation", callbackUrl);
							await _userManager.AddToRoleAsync(Adduser, "CompanyAdmin");
                            _context.Update(tbCompanies);
                            await _context.SaveChangesAsync();
                            String body = " <br /> Click the link here to go to Tradepawa : <a href='https://www.tradepawa.com'></a>";
                            await _dbOps.LogandSendSMS(user.contact, "Dear " + user.FirstName +", Your Company has been Verified ,"+ " Your Login Password is " + pass + " and your login email is :"+user.email+ " . Kindly keep your password private", "", "", "");
							await _dbOps.LogAndSendMail(user.email, "Account Password", "Dear " + user.FirstName + ", Your Login Password is " + pass +" and your login email is :"+user.email+ " ."+ body);
							return RedirectToAction(nameof(Index));
						}

					}
					if (btn == "Reject")
					{
						if (tbCompanies.status == 0)
						{

							tbCompanies.status = 2;
                            tbCompanies.FirstTimeUse = true;

							_context.Update(tbCompanies);
							await _context.SaveChangesAsync();
                            await _dbOps.LogandSendSMS(user.contact, "Dear " + user.FirstName + " Sorry we could not validate your company credentials, Please provide valid details", "", "", "");
                            await _dbOps.LogAndSendMail(user.email, "Password", "Dear " + user.FirstName + " Sorry we could not verify your company credentials, Please provide valid details");

                            //Send Email                     
                            return RedirectToAction(nameof(Index));
						}


					}
				}

				else
				{
					return (RedirectToAction("details", new { id = compID, f = "Applicant Profile is incomplete" }));
					//_dbOps.LogNotification(profile.Id, 1, "Your Application has been Approved final Step, Proceed to Check out");
				}
				_context.Update(tbCompanies);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));

			}
			catch (Exception ex)
			{
				//throw ex;
               // _dbOps.LogError
				await _dbOps.LogError("Companies/Verify", "Verify", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());

                return (RedirectToAction("details", new { id = compID, f = "Sorry Cannot Verify Details at the moment" }));

            }
			//return NotFound();
		}
        public async Task<IActionResult> AttachmentDetails(Guid? id, string f = null)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var companyDocs = await _context.TbCompanyDocs
              .SingleOrDefaultAsync(m => m.CompanyId == id);
                if (companyDocs == null)
                {
                    return NotFound();
                }
                ViewData["BoardResolutionDocPath"] = companyDocs.BoardResolution;
                ViewData["RegCertDocPath"] = companyDocs.RegistrationCertificate;
                ViewData["PinCertDocPath"] = companyDocs.PinCertificate;
                ViewData["Cr12DocPath"] = companyDocs.Cr12;
                ViewData["Gui"] = id;
                ViewData["State0"] = companyDocs.Status;
               // ViewData["DirId"] = companyDocs.Status;
                ViewData["DocsId"] = companyDocs.Id;


                if (!object.ReferenceEquals(f, null))
                {
                    ViewData["CompanyDocumentDetails"] = f;
                }
                return View(companyDocs);
            }

            catch (Exception ex)
            {
                throw ex;
                // _dbOps.logError("Companies/Details", "CompanyDetails", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());

            }
            //return NotFound();
        }

        //Get crb details
        // GET: Applications/Details/5
        public async Task<IActionResult> CRBDetails(Guid? id, string f = null)
		{
			try
			{
				if (id == null)
				{
					return NotFound();
				}

				var tbCompanies = await _context.TbCompanies
					 .SingleOrDefaultAsync(m => m.compGuid == id);
				if (tbCompanies == null)
				{
					return NotFound();
				}

				var tbcrb = await _context.TbCRBChecks
				.SingleOrDefaultAsync(m => m.compGuid == id);


				var appliedby = await _dbOps.GetCompanyRegistrarDetails(tbCompanies);
                var directors_ = _context.TbDirectors.Where(c => c.CompanyId == tbCompanies.compGuid).ToList();
				CompanyDetails det = new CompanyDetails
				{
					appliedby = appliedby.sirname,
					company = tbCompanies,
					ApplicantAddress = appliedby.email,
					Contact = appliedby.contact,
					crb = tbcrb,
                    directors= directors_
                };

				ViewData["Gui"] = det.company.compGuid;
				ViewData["CompGuid"] = det.company.compGuid;
				ViewData["State0"] = det.company.status;

				if (!object.ReferenceEquals(f, null))
				{
					ViewData["CompanyDetails"] = f;
				}

				return View(det);
			}

			catch (Exception ex)
			{
				throw ex;
				// _dbOps.logError("Companies/Details", "CompanyDetails", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());

			}
			//return NotFound();
		}

		// GET: Applications/Details/5
		public async Task<IActionResult> Details(Guid? id, string f = null)
		{
			try
			{
				if (id == null)
				{
					return NotFound();
				}

				var tbCompanies = await _context.TbCompanies
					 .SingleOrDefaultAsync(m => m.compGuid == id);
				if (tbCompanies == null)
				{
					return NotFound();
				}

				var tbcrb = await _context.TbCRBChecks
				.SingleOrDefaultAsync(m => m.compGuid == id);
				if (tbCompanies == null)
				{
					return NotFound();
				}


				var appliedby = await _dbOps.GetCompanyRegistrarDetails(tbCompanies);
                var directors_ = _context.TbDirectors.Where(d => d.CompanyId == tbCompanies.compGuid).ToList();
				CompanyDetails det = new CompanyDetails
				{
					appliedby = appliedby.sirname,
					company = tbCompanies,
					ApplicantAddress = appliedby.email,
					Contact = appliedby.contact,
					crb = tbcrb,
                    directors= directors_

                };
                if (id == null)
                {
                    return NotFound();
                }
                var companyDocs = await _context.TbCompanyDocs
              .SingleOrDefaultAsync(m => m.CompanyId == id);
                if (companyDocs == null)
                {
                    ViewData["BoardResolutionDocPath"] = " ";
                    ViewData["RegCertDocPath"] = " ";
                    ViewData["PinCertDocPath"] = " ";
                    ViewData["Cr12DocPath"] = " ";
                    ViewData["AppGui"] = Guid.Empty;
                    ViewData["DocState0"] = 20;
                    ViewData["DocsId"] = Guid.Empty;
                }
                else
                {
                    ViewData["BoardResolutionDocPath"] = companyDocs.BoardResolution;
                    ViewData["RegCertDocPath"] = companyDocs.RegistrationCertificate;
                    ViewData["PinCertDocPath"] = companyDocs.PinCertificate;
                    ViewData["Cr12DocPath"] = companyDocs.Cr12;
                    ViewData["AppGui"] = companyDocs.Id;
                    ViewData["DocState0"] = companyDocs.Status;
                    ViewData["DocsId"] = companyDocs.Id;
                }
               


                if (!object.ReferenceEquals(f, null))
                {
                    ViewData["CompanyDocumentDetails"] = f;
                }
                ViewData["Gui"] = det.company.compGuid;
                ViewData["DirGui"] = det.company.compGuid;
				ViewData["CompGuid"] = det.company.compGuid;
				ViewData["State0"] = det.company.status;
				// ViewData["crbStatus"] = det.crb.status;
				if (!object.ReferenceEquals(f, null))
				{
					ViewData["CompanyDetails"] = f;
				}

				return View(det);
			}

			catch (Exception ex)
			{
				await _dbOps.LogError("Companies/Details", "CompanyDetails", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());

			}
			return NotFound();
		}


		//Check Company Whether it qualifies for a bond by checking credit score in CRB
		[Authorize(Roles = ("MasterAdmin"))]
		[Obsolete]
		public async Task<IActionResult> CRBRefresh(Guid? id)
		{

			try
			{
				if (id == null)
				{
					return NotFound();
				}


				var tbCompanies = await _context.TbCompanies
					 .SingleOrDefaultAsync(m => m.compGuid == id);
				if (tbCompanies == null)
				{
					return NotFound();
				}

				var comp = _context.TbCompanies.FirstOrDefault(x => x.compGuid == id);

				var a = await _context.TbCRBChecks.SingleOrDefaultAsync(m => m.compGuid == id);

				var binding = new BasicHttpBinding();

				//subject to discussion

				//DateTime Today = DateTime.Now;

				//if (a == null)
				//{
				//    a.date = DateTime.Now;
				//}

				// TimeSpan span = Today.Subtract(a.date);


				tbCRBChecks ikocrb = await _context.TbCRBChecks.SingleOrDefaultAsync(m => m.compGuid == id); //&& span.Days < 14);

				tbCRBChecks expired = await _context.TbCRBChecks.SingleOrDefaultAsync(m => m.compGuid == id);

				if (ikocrb == null)
				{
					var consent = "true";
					var idNumber = comp.RegCertNo;
					var idNumberType = "RegistrationNumber";
					var inquiryReason = "InitialCollection";
					var reportDate = XmlConvert.ToString(DateTime.Now);
					var scoringReport = "CreditinfoReportPlus";
					var SubjectType = "Company";
					var Trend = "";
					string result = _dbOps.CallCompanyWebService(consent, idNumber, idNumberType, inquiryReason, reportDate, scoringReport, SubjectType);
					if (!string.IsNullOrWhiteSpace(result))
					{
						string description = _dbOps.Between(result, "ubject", "<b:Grade>");

						string desc = "Subject" + description + "";

						string companyType = _dbOps.Between(result, "<b:CompanyType>", "</b:CompanyType>");

						string IndustryCode = _dbOps.Between(result, "<b:IndustryCode>", "</b:IndustryCode>");

						string RegName = _dbOps.Between(result, "<b:RegisteredName>", "</b:RegisteredName>");

						DateTime RegDate = Convert.ToDateTime(_dbOps.Between(result, "<b:RegistrationDate>", "</b:RegistrationDate>"));

						string TradeName = _dbOps.Between(result, "<b:TradingName>", "</b:TradingName>");

						string TradeStatus = _dbOps.Between(result, "<b:TradingStatus>", "</b:TradingStatus>");

						string Pin = _dbOps.Between(result, "<b:PinNumber>", "</b:PinNumber>");

						string Address = _dbOps.Between(result, "<b:AddressLine>", "</b:AddressLine><b:Country>");

						var FullNm = _dbOps.Between(result, "<b:FullName>", "</b:FullName>");

						var IDNo = _dbOps.Between(result, "<b:IDNumber>", "</b:IDNumber>");

						var IDType = _dbOps.Between(result, "<b:IDNumberType>", "</b:IDNumberType>");

						var Relation = _dbOps.Between(result, "<b:TypeOfRelation>", "</b:TypeOfRelation>");


						var Valid = _dbOps.Between(result, "<b:ValidFrom>", "</b:ValidFrom>");


						if (Trend == null)
						{
							Trend = _dbOps.Between(result, "<b:Trend>", "</b:Trend>");
						}

						if (result == "")
						{
							//blah blah blah((
							ModelState.AddModelError("", " " + comp.compName + " credit score is Okay");
							return (RedirectToAction("details", new { id = id }));
						}
						else
						{
							int Score = Convert.ToInt32(_dbOps.Between(result, "<b:Score>", "</b:Score>"));

							if (Score >= 713 && Score >= 900)
							{
								Trend = "Very Low Risk";
							}
							else
							if (Score >= 677 && Score >= 712)
							{
								Trend = "Low Risk";
							}
							else
							if (Score >= 641 && Score >= 676)
							{
								Trend = "Average Risk";
							}
							else
							if (Score >= 574 && Score >= 640)
							{
								Trend = "High Risk";
							}
							else
							if (Score >= 250 && Score >= 573)
							{
								Trend = "Very High Risk";
							}
							// Update Company details 

							tbCompanies.compName = RegName  ?? "";
							tbCompanies.PinNo = Pin ?? "";
							tbCompanies.regDate = RegDate;
							tbCompanies.pysicalLoc = Address ?? "";

							_context.Update(tbCompanies);
							await _context.SaveChangesAsync();

                            //log Tbcrb checks 
                            DateTime toLogdate = DateTime.Now;
                            if (Valid != "")
                            {
                                toLogdate = Convert.ToDateTime(Valid ?? "");
                            }
							var CrbDetails = new tbCRBChecks
							{
								compGuid = id.Value,
								inComeDetails = "" + companyType ?? "" + " ," + RegName ?? "",
								score = Convert.ToInt32(Score),
								details = Trend ?? "",
								status = 1,
								date = DateTime.Now,
								FullName = FullNm ?? "",
								IDNumber = IDNo ?? "",
								IDNumberType = IDType ?? "",
								TypeOfRelation = Relation ?? "",
                                
								ValidFrom = toLogdate
                            };
							_context.Add(CrbDetails);
							await _context.SaveChangesAsync();


							//ModelState.AddModelError("", "" + comp.compName + " credit score is not okay. Kindly clear with CRB first");
							return (RedirectToAction("details", new { id = id/*, f ="Sorry ," +" "+comp.compName +" "+ " credit score is not okay. Kindly clear with CRB first"*/ }));

						}
					}
					else
					{
						//ModelState.AddModelError("", "" + comp.compName + " credit score cannot be validated at the moment ");

                        return (RedirectToAction("details", new { id = id, f ="Sorry," +" "+comp.compName+" "+ " credit score cannot be validated at the moment, please try again later" }));
                        //return (RedirectToAction("details", new { id = id }));
                    }
				}
				else
				{
					return (RedirectToAction("details", new { id = id }));
				}

			}
			catch (Exception ex)
			{
				throw ex;
				// _dbOps.logError("Companies/CRBRefresh", "CRBRefresh", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
			}
		}

	}
}
