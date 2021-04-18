using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Models;
using Spa_Management.Services;
using Spa_Management.Operations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Spa_Management.Interfaces;

namespace Spa_Management.Controllers
{
	public class CompanyUsersController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IDbOperations _dbOps;
		private readonly UserManager<ApplicationUser> _userManager;

		public CompanyUsersController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> manager)
		{
			_context = context;
			_dbOps = dbOps;
			_userManager = manager;
		}

		// GET: CompanyUsers
		public async Task<IActionResult> Index()
		{
            ViewData["DocumentsVerified"] = true;
            ViewData["DirectorsVerified"] = true;
            ViewData["DirectorsRegistered"] = true;
            ViewData["DocumentsRegistered"] = true;

            if (User.IsInRole("CompanyAdmin"))
			{
				var me = await _userManager.GetUserAsync(HttpContext.User);
				var id = _context.TbCompanyUsers.FirstOrDefault(j => j.compUserGuid == me.compUserGuid).compGuid;
				var ApplicationDbContext = _context.TbCompanyUsers.Where(k => k.compGuid == id).Include(t => t.tbDesignations);
				List<ViewcompanyUsers> _CompUsers = new List<ViewcompanyUsers>();
				int i = 1;
				foreach(var a in ApplicationDbContext)
				{
					ViewcompanyUsers user = new ViewcompanyUsers()
					{
						id = i++,
						compUserGuid = a.compUserGuid,
						Name = string.Format("{0} {1} {2}", a.SirName, a.FirstName, a.LastName),
						contact = a.contact,
						Email = a.email,
						idNumber = a.idNumber,
						Role =  await _dbOps.GetUserRole(a.compUserGuid, 1),
						status = a.status
					};
					_CompUsers.Add(user);
				}
				ViewData["CompanyName"] = _context.TbCompanies.FirstOrDefault(k => k.compGuid == id).compName;
				ViewData["compGuid"] = id;
				//return View(await ApplicationDbContext.ToListAsync());
				return View(_CompUsers);
			}
			return new ForbidResult();
			
		}

		// GET: CompanyUsers/Details/5
		public async Task<IActionResult> Details(Guid? id)
		{
            ViewData["DocumentsVerified"] = true;
            ViewData["DirectorsVerified"] = true;
            ViewData["DirectorsRegistered"] = true;
            ViewData["DocumentsRegistered"] = true;
            if (id == null)
			{
				return NotFound();
			}

			var tbCompanyUsers = await _context.TbCompanyUsers
				.Include(t => t.tbDesignations)
				.SingleOrDefaultAsync(m => m.compUserGuid == id);
			if (tbCompanyUsers == null)
			{
				return NotFound();
			}

			return View(tbCompanyUsers);
		}

		// GET: CompanyUsers/Create
		public IActionResult Create(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var user = new tbCompanyUsers() { compGuid = id.Value };
			ViewData["CompanyName"] = _context.TbCompanies.FirstOrDefault(k => k.compGuid == id).compName;
			ViewData["designation"] = new SelectList(_context.TbDesignations, "designation", "designation");
			return View(user);
			//return View();
		}

		// POST: CompanyUsers/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("compGuid,compUserGuid,designation,SirName,FirstName,LastName,contact,email,gender,dob,idType,idNumber,status,pysicalLoc")] tbCompanyUsers tbCompanyUsers)
		{
			try
			{
				tbCompanyUsers.status = 0;
				tbCompanyUsers.regDate = DateTime.Now;
				var fon = phoneNumberNomalizer.phoneNum(tbCompanyUsers.contact);
				if (phoneNumberNomalizer.IsValidEmail(tbCompanyUsers.email))
				{
					if (!object.ReferenceEquals(fon, null))
					{
						if (!await _dbOps.IsEmailUsed(tbCompanyUsers.email))
						{
							if (ModelState.IsValid)
							{
								tbCompanyUsers.contact = fon;
								tbCompanyUsers.compUserGuid = Guid.NewGuid();
								_context.Add(tbCompanyUsers);
								await _context.SaveChangesAsync();
								//Create new System User

								var user = new ApplicationUser
								{
									UserName = tbCompanyUsers.email,
									Email = tbCompanyUsers.email,
									compUserGuid = tbCompanyUsers.compUserGuid,
									PhoneNumber = tbCompanyUsers.contact
								};
								
								var pass = _dbOps.GenerateRandomPassword(); // + "aA1@";
								var result = await _userManager.CreateAsync(user, pass);
								var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
								var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                                var text1 = $". To confirm your tradepawa account,please click here: <a href='{callbackUrl}'>link</a>";
                                await _dbOps.LogAndSendMail(tbCompanyUsers.email,"Tradepawa Account Email Confirmation", text1);
								if (User.IsInRole("MasterAdmin"))
								{
									await _userManager.AddToRoleAsync(user, "CompanyAdmin");
								}
								if (User.IsInRole("CompanyAdmin"))
								{
									await _userManager.AddToRoleAsync(user, "CompanyUser");
								}
                                string callbackUrl1 = "https://www.tradepawa.com";
                                var text = $". Please go to tradepawa by clicking here: <a href='{callbackUrl1}'>link</a>";

                                await _dbOps.LogAndSendMail(tbCompanyUsers.email, "TradePawa User Account", "Dear " + tbCompanyUsers.FirstName + " Your Account Password is " + pass+" and your login email is "+tbCompanyUsers.email+ "</br>"+ text);
								await _dbOps.AuditOperation(User.Identity.Name, "CompanyUsers/Create", "Added a new company User" + tbCompanyUsers.compUserGuid.ToString(), "", "CompanyUsers");
								return RedirectToAction("Users", "Companies", new { id = tbCompanyUsers.compGuid });
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
				await _dbOps.LogError("CompanyUsers/Create", "Add new company User", "", ex.Message.ToString(), object.ReferenceEquals(ex.InnerException, null) ? "" : ex.InnerException.ToString());
			}
			ViewData["CompanyName"] = _context.TbCompanies.FirstOrDefault(k => k.compGuid == tbCompanyUsers.compGuid).compName;
			ViewData["designation"] = new SelectList(_context.TbDesignations, "designation", "designation", tbCompanyUsers.designation);
			return View(tbCompanyUsers);
		}

		// GET: CompanyUsers/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var tbCompanyUsers = await _context.TbCompanyUsers.SingleOrDefaultAsync(m => m.compUserGuid == id);
			if (tbCompanyUsers == null)
			{
				return NotFound();
			}
			ViewData["designation"] = new SelectList(_context.TbDesignations, "designation", "designation", tbCompanyUsers.designation);
			ViewData["Status"] = new List<SelectListItem>
						{
							new SelectListItem {Text = "Active", Value = "0"},
							new SelectListItem {Text = "Discontinue", Value = "1"}
						};
			return View(tbCompanyUsers);
		}

		// POST: CompanyUsers/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("compGuid,regDate,compUserGuid,designation,SirName,FirstName,LastName,contact,email,gender,dob,idType,idNumber,status,pysicalLoc")] tbCompanyUsers tbCompanyUsers)
		{
			try
			{
				if (id != tbCompanyUsers.compUserGuid)
				{
					return NotFound();
				}
				
				var fon = phoneNumberNomalizer.phoneNum(tbCompanyUsers.contact);
				if (!object.ReferenceEquals(fon, null))
				{
					if (phoneNumberNomalizer.IsValidEmail(tbCompanyUsers.email))
					{
						//tbCompanyUsers.status = 0;
						_context.Update(tbCompanyUsers);
						await _context.SaveChangesAsync();
						_dbOps.AuditOperation(User.Identity.Name, "CompanyUsers/Edit", "Edited user id = " + tbCompanyUsers.compUserGuid.ToString(), "", "CompanyUsers/Edit");
						//return RedirectToAction(nameof(Index));
						//return RedirectToAction(nameof(Index), new { id = tbCompanyUsers.compGuid });
						return RedirectToAction("Users", "Companies", new { id = tbCompanyUsers.compGuid });
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
			catch (Exception ex)
			{
				_dbOps.LogError("CompanyUsers/Edit", "Editimg Company user " + tbCompanyUsers.compUserGuid.ToString(),"", ex.Message, object.ReferenceEquals(ex.InnerException, null) ? "" : ex.InnerException.ToString());
			}
			ViewData["Status"] = new List<SelectListItem>
						{
							new SelectListItem {Text = "Active", Value = "0"},
							new SelectListItem {Text = "Discontinue", Value = "1"}
						};
			ViewData["designation"] = new SelectList(_context.TbDesignations, "designation", "designation", tbCompanyUsers.designation);
			return View(tbCompanyUsers);
		}

		// GET: CompanyUsers/Delete/5
		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var tbCompanyUsers = await _context.TbCompanyUsers
				.Include(t => t.tbDesignations)
				.SingleOrDefaultAsync(m => m.compUserGuid == id);
			if (tbCompanyUsers == null)
			{
				return NotFound();
			}

			return View(tbCompanyUsers);
		}

		// POST: CompanyUsers/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var tbCompanyUsers = await _context.TbCompanyUsers.SingleOrDefaultAsync(m => m.compUserGuid == id);
			_context.TbCompanyUsers.Remove(tbCompanyUsers);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool tbCompanyUsersExists(Guid id)
		{
			return _context.TbCompanyUsers.Any(e => e.compUserGuid == id);
		}
	}
	public class ViewcompanyUsers
	{
		public int id { get; set; }
		public Guid compUserGuid { get; set; }

		public string Name{get; set;}

		[Display(Name = "Mobile Number")]
		public string contact { get; set; }
		
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Display(Name = "ID NO")]
		public string idNumber { get; set; }

		public string Role { get; set; }
		
		public int status { get; set; }
	}
    public class ViewspaUsers
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
    public class ViewcompanyDirectors
    {
        public int id { get; set; }
        public Guid DirectorId { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Mobile Number")]
        public string TelephoneNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "ID NO")]
        public string idNumber { get; set; }

        public string FirsName { get; set; }
        public string MiddleName { get; set; }

        public bool status { get; set; }
    }
}
