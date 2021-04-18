using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Operations
{
	public class insertOps : Controller
	{
		private readonly ApplicationDbContext db;
		private readonly DbOperations _dbOps;
		private insertRespo _res; // = new insertRespo();
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IEmailSender _emailSender;
		private readonly IDatabaseErrorLogger _databaseErrorLogger;
		public insertOps(ApplicationDbContext context, IEmailSender emailSender, DbOperations dbOps,
			UserManager<ApplicationUser> manager, IDatabaseErrorLogger databaseErrorLogger)
		{
			db = context;
			_dbOps = dbOps;
			_userManager = manager;
			_emailSender = emailSender;
			_databaseErrorLogger = databaseErrorLogger;
		}
		public async Task<insertRespo> createNewIndividual(tbIndivuduals tbIndivuduals)
		{
			_res = new insertRespo();
			_res.desc = new List<string>();
			try
			{
				tbIndivuduals.contact = phoneNumberNomalizer.phoneNum(tbIndivuduals.contact);
				if (!object.ReferenceEquals(tbIndivuduals.contact, null))
				{
					if (phoneNumberNomalizer.IsValidEmail(tbIndivuduals.email))
					{
						tbIndivuduals.regDate = DateTime.Now;
						tbIndivuduals.status = 0;

						if (Object.ReferenceEquals(db.TbIndivuduals.FirstOrDefault(j => j.status == 0 && j.email == tbIndivuduals.email), null))
						{
							tbIndivuduals.indGuid = Guid.NewGuid();
							db.Add(tbIndivuduals);
							await db.SaveChangesAsync();
							// Add User to System
							var user = new ApplicationUser
							{
								UserName = tbIndivuduals.email,
								Email = tbIndivuduals.email,
								indGuid = tbIndivuduals.indGuid,
								PhoneNumber = tbIndivuduals.contact
							};
							var pass = _dbOps.GenerateRandomPassword(); // + "aA1@";
							var result = await _userManager.CreateAsync(user, pass);
							var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
							var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
							await _dbOps.LogAndSendMail(tbIndivuduals.email, "Email Confirmation", callbackUrl);
							await _userManager.AddToRoleAsync(user, "Individual");
							await _dbOps.LogAndSendMail(tbIndivuduals.email, "Password", "Dear " + tbIndivuduals.FirstName + " Your Account Password is " + pass);
							//return RedirectToAction(nameof(emailConfirm));
							_res.status = true;
							return _res;
						}
						else
						{
							_res.desc.Add("Email Address already used");
						}

					}
					else
					{
						_res.desc.Add("Invalid Email Address");
					}
				}
				else
				{
					_res.desc.Add("Invalid Phone Number");
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("Indivuduals/Create", "Adding new Individual", "", ex.Message.ToString(), object.ReferenceEquals(ex.InnerException, null) ? "N/A" : ex.InnerException.ToString());
				_res.desc.Add("An error Occured while saving, Please try again");
			}
			_res.status = false;
			return _res;
		}

	}
	public class insertRespo
	{
		public bool status { get; set; }
		public List<string> desc { get; set; }
	}
}
