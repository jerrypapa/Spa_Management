using System;
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
using static Spa_Management.Operations.IPRSDetails;
using Spa_Management.Interfaces;
using System.Collections.Generic;
//using Newtonsoft.Json;

namespace Spa_Management.Controllers
{
    [Authorize]
    public class IndivudualsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly UserManager<ApplicationUser> _userManager;
        private Controllers.ApplicationsController _applicationsController;
        private readonly IPRSDetails _IPRS;

        public IndivudualsController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> manager, Controllers.ApplicationsController applicationsController, IPRSDetails IPRS)
        {
            _context = context;
            _dbOps = dbOps;
            //_insOps = insertOps;
            _userManager = manager;
            _applicationsController = applicationsController;
            _IPRS = IPRS;
       }

        // GET: Indivuduals
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.TbIndivuduals.Include(t => t.tbGender).Include(t => t.tbIdTypes).Include(t => t.tbMaritalStatus).Include(t => t.tbNationalities).Include(t => t.tbSuffixes);
            var me = await _userManager.GetUserAsync(HttpContext.User);
            if (User.IsInRole("Individual"))
            {
                return View(await ApplicationDbContext.Where(y=>y.indGuid == me.indGuid).ToListAsync());
            }
            //if (User.IsInRole("CompanyUser"))
            //{
            //    return View(await ApplicationDbContext.Where(y => y.indGuid == me.indGuid).ToListAsync());
            //}
            //if (User.IsInRole("BankUser"))
            //{
            //    return View(await ApplicationDbContext.Where(y => y.co == me.indGuid).ToListAsync());
            //}
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: Indivuduals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbIndivuduals = await _context.TbIndivuduals
                //.Include(t => t.tbBanks)
                //.Include(t => t.tbBranches)
                .Include(t => t.tbGender)
                .Include(t => t.tbIdTypes)
                .Include(t => t.tbMaritalStatus)
                .Include(t => t.tbNationalities)
                .Include(t => t.tbSuffixes)
                .SingleOrDefaultAsync(m => m.indGuid == id);
            if (tbIndivuduals == null)
            {
                return NotFound();
            }

            return View(tbIndivuduals);
        }

        // GET: Indivuduals/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            //ViewData["BankCode"] = new SelectList(_context.TbBanks, "BankCode", "bank");
            //ViewData["branchCode"] = new SelectList(_context.TbBranches, "branchCode", "branch");
            ViewData["gender"] = new SelectList(_context.TbGenders, "gender", "gender");
            ViewData["idType"] = new SelectList(_context.TbIdTypes, "idType", "idType");
            ViewData["maritalStatus"] = new SelectList(_context.TbMaritalStatuses, "maritalStatus", "maritalStatus");
            ViewData["NationCode"] = new SelectList(_context.TbNationalities, "NationCode", "Nationality");
            ViewData["suffix"] = new SelectList(_context.TbSuffixes, "suffix", "suffix");
            return View();
        }

        // POST: Indivuduals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("indGuid,suffix,SirName,FirstName,LastName,contact,email,gender,dob,NationCode,idType,idNumber,maritalStatus,pysicalLoc,BankCode,branchCode,accNum")] tbIndivuduals tbIndivuduals)
        {
         
            try
            {
                
                if (object.ReferenceEquals(_context.TbIndivuduals.FirstOrDefault(j => j.status == 0 && j.idType == tbIndivuduals.idType && j.idNumber==tbIndivuduals.idNumber), null))
                {
                    
                    tbIndivuduals.contact = phoneNumberNomalizer.phoneNum(tbIndivuduals.contact);
                    if (!object.ReferenceEquals(tbIndivuduals.contact, null))
                    {
                        if (phoneNumberNomalizer.IsValidEmail(tbIndivuduals.email))
                        {
                            tbIndivuduals.regDate = DateTime.Now;
                            tbIndivuduals.status = 0;
                            if (ModelState.IsValid)
                            {
                                if (Object.ReferenceEquals(_context.TbIndivuduals.FirstOrDefault(j => j.status == 0 && j.email == tbIndivuduals.email), null))
                                {
                                    tbIndivuduals.indGuid = Guid.NewGuid();
                                    var pp = await _applicationsController.GenerateIPRSToken();
                                    // Send JSON To GET IPRS Details

                                    var message_v = new IPRSDetails.message_validation()
                                    {
                                        api_user = (await _dbOps.GetSysParameter("IPRS Api User")).Value.Trim() ?? "dit",
                                        api_password = (await _dbOps.GetSysParameter("IPRS Api Password")).Value.Trim() ?? "123456",
                                        token = pp
                                    };
                                    var message_r = new IPRSDetails.message_route()
                                    {
                                        @interface = (await _dbOps.GetSysParameter("IPRS interface")).Value.Trim() ?? "IPRS",
                                        request_type = (await _dbOps.GetSysParameter("IPRS request_type")).Value.Trim() ?? "iprs",
                                        external_ref_number = tbIndivuduals.indGuid.ToString(),
                                    };
                                    var message_b = new IPRSDetails.message_body()
                                    {
                                        query_by = tbIndivuduals.idType,
                                        id_number = tbIndivuduals.idNumber,
                                        serial_number = ""
                                    };

                                    var obj = new IPRSDetails.IPRSSendResponse()
                                    {
                                        message_validation = message_v,
                                        message_route = message_r,
                                        message_body = message_b
                                    };
                                    var stringResp = "Bypassed"; //_IPRS.IPRSResponseDetails(obj).Trim();  bypass for now
                                    if (!object.ReferenceEquals(stringResp, null))
                                    {
                                        var mainResp = "Bypassed";// Newtonsoft.Json.JsonConvert.DeserializeObject<MainResp>(stringResp);
											if (mainResp=="Bypassed"/*mainResp.error_code != "00"*/) //Details Found ....papa change to == once we have conn
											{
												if (mainResp=="Bypassed"/*.error_desc.first_name != null*/)
												{
													//Get details from IPRS
													//tbIndivuduals.FirstName = mainResp.error_desc.first_name;//restDetails.first_name;
													//tbIndivuduals.dob = Convert.ToDateTime(mainResp.error_desc.date_of_birth);
													//// Did not update gender due to Foreign constraints in TBGenders
													////tbIndivuduals.gender = mainResp.error_desc.gender;
													//tbIndivuduals.LastName = mainResp.error_desc.other_name;
													//tbIndivuduals.SirName = mainResp.error_desc.surname;



													_context.Add(tbIndivuduals);
													

													// Add User to System
													var user = new ApplicationUser
													{
														UserName = tbIndivuduals.email,
														Email = tbIndivuduals.email,
														indGuid = tbIndivuduals.indGuid,
														PhoneNumber = tbIndivuduals.contact

													};
                                                //The INSERT statement conflicted with the FOREIGN KEY constraint "FK_TbCompanyUsers_TbCompanies_compGuid". The conflict occurred in database "Spa_Management", table "dbo.TbCompanies", column 'compGuid'.
                                               

                                                                                                //Map as admin too
                                              var users = new tbCompanyUsers()
                                                {
                                                    compGuid = Guid.Empty,
                                                    compUserGuid = tbIndivuduals.indGuid,
                                                    SirName = "",//tbIndivuduals.SirName,
                                                    FirstName = tbIndivuduals.FirstName,
                                                    contact = phoneNumberNomalizer.phoneNum(tbIndivuduals.contact),
                                                    email = tbIndivuduals.email,
                                                    idNumber = tbIndivuduals.idNumber,
                                                    status = 0,
                                                    LastName=tbIndivuduals.LastName,
                                                    regDate=DateTime.Now,
                                                    idType=tbIndivuduals.idType,
                                                 //   Name=tbIndivuduals.Name,

                                                };
                                                _context.Add(users);

                                                await _context.SaveChangesAsync();
                                                // Send an email with this link                                              

                                                var pass = _dbOps.GenerateRandomPassword(); // + "aA1@";
													var result = await _userManager.CreateAsync(user, pass);
													var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
													var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
													await _dbOps.LogAndSendMail(tbIndivuduals.email, "Email Confirmation", callbackUrl);
													await _userManager.AddToRoleAsync(user, "Individual");
													await _dbOps.LogAndSendMail(tbIndivuduals.email, "Password", "Dear " + tbIndivuduals.FirstName + " Your Account Password is " + pass);
													return RedirectToAction(nameof(emailConfirm));
												}
												else
												{
													await _dbOps.LogAndSendMail(tbIndivuduals.email, "Invalid Details", "Dear user.We apologize that your details could not be verified in the Integrated Population Registration System ");
													return RedirectToAction(nameof(Registration));
												}

											}
											else
											{
												await _dbOps.LogAndSendMail(tbIndivuduals.email, "Invalid Details", "Dear user.We apologize that your details could not be verified in the Integrated Population Registration System ");
											ModelState.AddModelError("", "Could not verify your details from Integrated Population Registration System");
											return RedirectToAction(nameof(Registration));
											}
										//}
										//else
										//{
										//	ModelState.AddModelError("", "Cannot Verify Details. Record not found");
										//}
                                        
                                    }
                                    else
                                    {
                                        ModelState.AddModelError("", "Cannot Verify Details. Record not found");
                                    }
                                }
                                else
                                {
                                    ModelState.AddModelError("", "Email Address already used");
                                }

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
                else
                {
                    ModelState.AddModelError("", "ID Number already registered ");
                }
                
            }
            catch (Exception ex)
            {
                await _dbOps.LogError("Individuals/Create", "Adding new Individual", "", ex.Message.ToString(), object.ReferenceEquals(ex.InnerException, null) ? "N/A" : ex.InnerException.ToString());
                ModelState.AddModelError("", "An error Occurred while saving, Please try again");
            
            }
            //ViewData["BankCode"] = new SelectList(_context.TbBanks, "BankCode", "bank", tbIndivuduals.BankCode);
            //ViewData["branchCode"] = new SelectList(_context.TbBranches, "branchCode", "branch", tbIndivuduals.branchCode);
            ViewData["gender"] = new SelectList(_context.TbGenders, "gender", "gender", tbIndivuduals.gender);
            ViewData["idType"] = new SelectList(_context.TbIdTypes, "idType", "idType", tbIndivuduals.idType);
            ViewData["maritalStatus"] = new SelectList(_context.TbMaritalStatuses, "maritalStatus", "maritalStatus", tbIndivuduals.maritalStatus);
            ViewData["NationCode"] = new SelectList(_context.TbNationalities, "NationCode", "Nationality", tbIndivuduals.NationCode);
            ViewData["suffix"] = new SelectList(_context.TbSuffixes, "suffix", "suffix", tbIndivuduals.suffix);

            return View(tbIndivuduals);
        }

        //call email confirm view

        [AllowAnonymous]
        [HttpGet]
        public IActionResult emailConfirm (){
            return View();
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }



        // GET: Indivuduals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbIndivuduals = await _context.TbIndivuduals.SingleOrDefaultAsync(m => m.indGuid == id);
            if (tbIndivuduals == null)
            {
                return NotFound();
            }
            //ViewData["BankCode"] = new SelectList(_context.TbBanks, "BankCode", "bank", tbIndivuduals.BankCode);
            //ViewData["branchCode"] = new SelectList(_context.TbBranches, "branchCode", "branch", tbIndivuduals.branchCode);
            ViewData["gender"] = new SelectList(_context.TbGenders, "gender", "gender", tbIndivuduals.gender);
            ViewData["idType"] = new SelectList(_context.TbIdTypes, "idType", "idType", tbIndivuduals.idType);
            ViewData["maritalStatus"] = new SelectList(_context.TbMaritalStatuses, "maritalStatus", "maritalStatus", tbIndivuduals.maritalStatus);
            ViewData["NationCode"] = new SelectList(_context.TbNationalities, "NationCode", "Nationality", tbIndivuduals.NationCode);
            ViewData["suffix"] = new SelectList(_context.TbSuffixes, "suffix", "suffix", tbIndivuduals.suffix);
            return View(tbIndivuduals);
        }

        // POST: Indivuduals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("indGuid,suffix,SirName,FirstName,LastName,contact,gender,dob,NationCode,idType,idNumber,maritalStatus,pysicalLoc,BankCode,branchCode,accNum")] tbIndivuduals tbIndivuduals)
        {
            if (id != tbIndivuduals.indGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbIndivuduals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbIndivudualsExists(tbIndivuduals.indGuid))
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
            //ViewData["BankCode"] = new SelectList(_context.TbBanks, "BankCode", "bank", tbIndivuduals.BankCode);
            //ViewData["branchCode"] = new SelectList(_context.TbBranches, "branchCode", "branch", tbIndivuduals.branchCode);
            ViewData["gender"] = new SelectList(_context.TbGenders, "gender", "gender", tbIndivuduals.gender);
            ViewData["idType"] = new SelectList(_context.TbIdTypes, "idType", "idType", tbIndivuduals.idType);
            ViewData["maritalStatus"] = new SelectList(_context.TbMaritalStatuses, "maritalStatus", "maritalStatus", tbIndivuduals.maritalStatus);
            ViewData["NationCode"] = new SelectList(_context.TbNationalities, "NationCode", "Nationality", tbIndivuduals.NationCode);
            ViewData["suffix"] = new SelectList(_context.TbSuffixes, "suffix", "suffix", tbIndivuduals.suffix);
            return View(tbIndivuduals);
        }

        // GET: Indivuduals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbIndivuduals = await _context.TbIndivuduals
                //.Include(t => t.tbBanks)
                //.Include(t => t.tbBranches)
                .Include(t => t.tbGender)
                .Include(t => t.tbIdTypes)
                .Include(t => t.tbMaritalStatus)
                .Include(t => t.tbNationalities)
                .Include(t => t.tbSuffixes)
                .SingleOrDefaultAsync(m => m.indGuid == id);
            if (tbIndivuduals == null)
            {
                return NotFound();
            }

            return View(tbIndivuduals);
        }

        // POST: Indivuduals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tbIndivuduals = await _context.TbIndivuduals.SingleOrDefaultAsync(m => m.indGuid == id);
            _context.TbIndivuduals.Remove(tbIndivuduals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbIndivudualsExists(Guid id)
        {
            return _context.TbIndivuduals.Any(e => e.indGuid == id);
        }
    }
    public class MainResp
    {
        public string error_code { get; set; }

        public error_description error_desc { get; set; }

    }
	public class Respo
	{
		public string error_code { get; set; }
		public List<errorBody> error_desc { get; set; }
	}
	public class errorBody
	{
		public string exception { get; set; }
	}
}
