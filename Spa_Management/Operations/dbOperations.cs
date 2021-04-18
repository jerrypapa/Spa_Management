using Spa_Management.Data;
using Spa_Management.Dto;
using Spa_Management.Exceptions;
using Spa_Management.Interfaces;
using Spa_Management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Spa_Management.Operations
{
	public class DbOperations : IDbOperations
	{
		private readonly IEmailSender _emailSender;
		private readonly IDatabaseErrorLogger _databaseErrorLogger;
		private readonly ISystemParameters _systemParameters;
		private readonly ApplicationDbContext _context;
		private readonly ISMSSender _sMSSender;
		public DbOperations(ApplicationDbContext context, IEmailSender emailSender,
			IDatabaseErrorLogger databaseErrorLogger, ISystemParameters systemParameters,
			ISMSSender sMSSender)
		{
			_context = context;
			_emailSender = emailSender;
			_databaseErrorLogger = databaseErrorLogger;
			_systemParameters = systemParameters;
			_sMSSender = sMSSender;
		}
		public async Task<tbSysConfigs> GetSysParameter(string code)
		{
			return await _systemParameters.GetSysParameter(code);
		}
		public async Task LogError(string action, string desc, string json, string errMsg, string innerEx, string modelValid = null, string sess = null)
		{
			await _databaseErrorLogger.logError(action, desc, json, errMsg, innerEx, modelValid, sess);
		}
		public async Task AuditOperation(string userId, string action, string desc, string json, string page, string sess = null)
		{
			try
			{
				var tblAudit = new tbAudit()
				{
					userID = userId,
					action = action,
					Description = desc,
					json = json,
					page = page,
					actionTime = DateTime.Now,
					sessionId = sess
				};
				_context.TbAudit.Add(tblAudit);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError(action + "Log Audit", desc, json, ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
			}
		}


		public async Task LogJson(string json)
		{
			try
			{
				var j = new tbJsonLogs()
				{
					json = json,
					time = DateTime.Now
				};
				_context.TbJsonLogs.Add(j);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("logJson", "", json, ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
			}
		}



		public static void ReadError()
		{
			string strPath = @"c:\TEMP\Spa_Managementlogs.txt";//Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ErrorLogs", "Log.txt");
													   //string strPath = "~ErrorLogs";
			using (StreamReader sr = new StreamReader(strPath))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					Console.WriteLine(line);
				}
			}
		}

		public async Task LogNotification(string userId, int type, string mess)
		{
			try
			{
				tbNotifications n = new tbNotifications()
				{
					systemID = userId,
					type = type,
					message = mess,
					logDate = DateTime.Now,
					status = 0
				};
				_context.TbNotifications.Add(n);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("Log Notice", userId, mess, ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
			}
		}

		private async Task UpdateNoticeAsRead(int id)
		{
			try
			{
				var n = _context.TbNotifications.FirstOrDefault(d => d.Id == id);

				{
					n.status = 1;
					_context.Update(n);
					await _context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("updateNoticeAsRead", id.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
			}
		}
		private static Random random = new Random();


		public string GenerateRandomPassword()
		{
			string[] randomChars = new[]
			{
				"ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
				"abcdefghijkmnopqrstuvwxyz",    // lowercase
				"0123456789",                   // digits
				"!@$?_-"                        // non-alphanumeric
			};
			Random rand = new Random(Environment.TickCount);
			List<char> chars = new List<char>();

			chars.Insert(rand.Next(0, chars.Count),
				randomChars[0][rand.Next(0, randomChars[0].Length)]);

			chars.Insert(rand.Next(0, chars.Count),
				randomChars[1][rand.Next(0, randomChars[1].Length)]);

			chars.Insert(rand.Next(0, chars.Count),
				randomChars[2][rand.Next(0, randomChars[2].Length)]);

			chars.Insert(rand.Next(0, chars.Count),
				randomChars[3][rand.Next(0, randomChars[3].Length)]);

			for (int i = chars.Count; i < 8
				|| chars.Distinct().Count() < 1; i++)
			{
				string rcs = randomChars[rand.Next(0, randomChars.Length)];
				chars.Insert(rand.Next(0, chars.Count),
					rcs[rand.Next(0, rcs.Length)]);
			}
			return new string(chars.ToArray());
		}

		public async Task<string> GetUserRole(Guid guid, int userType)
		{
			try
			{
				string userId = null;
				switch (userType)
				{
					case 1:
						{
							userId = _context.Users.FirstOrDefault(h => h.compUserGuid == guid).Id;
							break;
						}
					case 2:
						{
							userId = _context.Users.FirstOrDefault(h => h.bankUserGuid == guid).Id;
							break;
						}
                    case 3:
                        {
                            userId = _context.Users.FirstOrDefault(h => h.userGuid == guid).Id;
                            break;
                        }
                    case 4:
                        {
                            userId = _context.Users.FirstOrDefault(h => h.spaUserGuid == guid).Id;
                            break;
                        }
                }
				if (!string.IsNullOrEmpty(userId))
				{
					var role = _context.UserRoles.FirstOrDefault(h => h.UserId == userId);
					if (!object.ReferenceEquals(role, null))
					{
						return _context.Roles.FirstOrDefault(l => l.Id == role.RoleId).NormalizedName;
					}
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("getUserRole", "get User Role for = " + guid.ToString() + " Type " + userType.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
			}

			return null;
		}

		public async Task<string> GetCompanyDetails(Guid guid)
		{
			try
			{
				var app = _context.TbApplications.AsNoTracking().FirstOrDefault(f => f.CRBGuid == guid);

				if (!object.ReferenceEquals(app, null))
				{
					if (app.indGuid != Guid.Empty)
					{
						var a = _context.TbIndivuduals.FirstOrDefault(x => x.indGuid == app.indGuid);
						return string.Format("{0} {1} {2}", a.SirName, a.FirstName, a.LastName);
					}
					else
					{
						var user = _context.Users.FirstOrDefault(n => n.compUserGuid ==Guid.Parse(app.appliedBy));
						var a = _context.TbCompanies.FirstOrDefault(z => z.compGuid == app.compGuid);
						return string.Format("{0} , {1}", a.compName, a.PinNo);
					}
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("getCompanyDetails", "get company applied for = " + guid.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
			}
			return "N/A";
		}
		public async Task<string> GetWhoApplied(Guid guid)
		{
			try
			{
				var app = _context.TbApplications.FirstOrDefault(f => f.CRBGuid == guid);

				if (!object.ReferenceEquals(app, null))
				{
					if (app.indGuid != Guid.Empty)
					{
						var a = _context.TbIndivuduals.FirstOrDefault(x => x.indGuid == app.indGuid);
						return string.Format("{0} {1} {2}", a.SirName, a.FirstName, a.LastName);
					}
					else
					{
						var user = _context.Users.FirstOrDefault(n => n.Id == app.appliedBy);
						var a = _context.TbCompanyUsers.FirstOrDefault(z => z.compUserGuid == user.compUserGuid);
						return string.Format("{0} {1} {2}", a.SirName, a.FirstName, a.LastName);
					}
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("getWhoApplied", "get User Who Applied for = " + guid.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
			}
			return "N/A";
		}
		public async Task<DetailOfWhoApplied> DetailsOfWhoApplied(tbApplications app)
		{
			var who = new DetailOfWhoApplied();
			try
			{
				if (!object.ReferenceEquals(app, null))
				{
					if (app.indGuid != Guid.Empty)
					{
						var a = await _context.TbIndivuduals.FirstOrDefaultAsync(x => x.indGuid == app.indGuid);
						who.firstName = a.FirstName;
						who.lastName = a.LastName ?? a.FirstName;
						who.email = a.email;
						who.address = a.pysicalLoc;
						who.msisdn = a.contact;
						who.CompanyAddress = a.pysicalLoc;

					}
					else
					{
						//var user = _context.Users.FirstOrDefault(n => n.Id == app.appliedBy);
						var a = _context.TbCompanyUsers.FirstOrDefault(z => z.compUserGuid ==Guid.Parse( app.appliedBy));
						var b = _context.TbCompanies.FirstOrDefault(z => z.compGuid == app.compGuid);
                        var contact = _context.Users.FirstOrDefault(c => c.compUserGuid == Guid.Parse(app.appliedBy)).PhoneNumber;
						who.firstName = a.FirstName;
						who.lastName = a.LastName ?? a.FirstName;
						who.email = a.email;
						who.address = a.pysicalLoc ?? b.pysicalLoc;
						who.msisdn = a.contact ?? contact;
						who.CompanyAddress = b.postalAddress;

					}
					return who;
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("getWhoApplied", "get User Who Applied for = " + app.CRBGuid.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
			}
			return null;
		}

		public async Task<CompanyRegistrarDetails> GetCompanyRegistrarDetails(tbCompanies comp)
		{
			var who = new CompanyRegistrarDetails();
			try
			{
				if (!object.ReferenceEquals(comp, null))
				{
					var a = await _context.TbCompanyUsers.FirstOrDefaultAsync(x => x.compGuid == comp.compGuid);
					who.sirname = string.Concat(a.FirstName," ",a.LastName);
					who.contact = a.contact;
					who.email = a.email;

					return who;
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("getWhoApplied", "get User Who Applied for = " + comp.compGuid.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
			}
			return null;
		}

		public async Task<DetailBeneficiary> DetailOfBeneficiary(tbApplications app)
		{
			var who = new DetailBeneficiary();
			try
			{
				if (!object.ReferenceEquals(app, null))
				{
					if (app.indGuid != Guid.Empty)
					{
						var a = await _context.TbBeneficialies.FirstOrDefaultAsync(x => x.indGuid == app.indGuid);
						who.BenefName = a.SirName;
						who.lastName = a.LastName;
						who.email = a.email;
						who.address = a.adrress;

					}
					else
					{
						//var user = _context.Users.FirstOrDefault(n => n.Id == app.appliedBy);

						var a = _context.TbBeneficialies.FirstOrDefault(z => z.benGuid == Guid.Parse(app.Purchaser));
						who.BenefName = a.SirName;
						who.lastName = a.LastName;
						who.email = a.email;
						who.address = a.adrress;
					}
					return who;
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("getBeneficiaryDetails", "get Beneficiary details = " + app.CRBGuid.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
			}
			return null;
		}

		public async Task<string> GetWhoApprovedOrChecked(Guid guid, int i)
		{
			try
			{
				var app = await _context.TbApplications.FirstOrDefaultAsync(f => f.CRBGuid == guid);
				if (i == 0)
				{
					var user = _context.Users.FirstOrDefault(n => n.Id == app.approvedBy.ToString());
					var a = _context.TbBankUsers.FirstOrDefault(z => z.bankUserGuid == user.bankUserGuid);
					return string.Format("{0} {1} {2}", a.SirName, a.FirstName, a.LastName);
				}
				if (i == 1)
				{
					var user = _context.Users.FirstOrDefault(n => n.Id == app.checkedBy.ToString());
					var a = _context.TbBankUsers.FirstOrDefault(z => z.bankUserGuid == user.bankUserGuid);
					return string.Format("{0} {1} {2}", a.SirName, a.FirstName, a.LastName);
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("getWhoApproved", "get User Who Approved or Checked for = " + guid.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
			}
			return "N/A";
		}

		public async Task<bool> IsEmailUsed(string email)
		{
			try
			{
				return !object.ReferenceEquals(await _context.Users.FirstOrDefaultAsync(g => g.Email == email), null);
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("isEmailUsed", "isEmailUsed " + email, "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
			}
			return true;
		}
		public async Task<decimal> GetCommisionAmount(decimal amount, Guid Bank, string curr, string Newperiod)
		{
			try
			{
                //var flat
                //var fixed
                //var quartely

                int n = int.Parse(Newperiod);
                bool FirstQuater = false;

                bool SecondQuater = false;
                bool ThirdQuater = false;
                bool FourthQuater = false;

                if (n>0 && n <= 90)
                {
                    FirstQuater = true;
                }
                if (n > 90 && n <= 180)
                {
                    SecondQuater = true;
                }
                if (n > 180 && n <= 270)
                {
                    ThirdQuater = true;
                }
                if (n > 270 && n <= 360)
                {
                    FourthQuater = true;
                }

                

              //  var matrix = _context.TbComMatrices.Where(j => j.SystemBanksGuid == Bank && j.currency == curr);//OOriginal
                var matrix = _context.TradePawaMatrix.AsNoTracking().Where(j =>j.currency == curr);

				var flat = matrix.FirstOrDefault(d => d.to >= Convert.ToDecimal(amount)).FlatRate;


				var AmtTo = matrix.FirstOrDefault(d => d.to >= Convert.ToDecimal(amount)).to;


                var percentageComm = matrix.FirstOrDefault(d => d.to >= Convert.ToDecimal(amount)).perCom;


                var PayablePercentageValue = (percentageComm * amount) / 100;

                decimal QuaterValue=0M;

                if (FirstQuater == true)
                {
                    QuaterValue= QuarterComputer(amount, 1, percentageComm);
                }

                if (SecondQuater == true)
                {
                    QuaterValue= QuarterComputer(amount, 2, percentageComm);
                }
                if (ThirdQuater == true)
                {
                    QuaterValue= QuarterComputer(amount, 3, percentageComm);
                }
                if (FourthQuater == true)
                {
                    QuaterValue= QuarterComputer(amount, 4, percentageComm);
                }

                var per = matrix.FirstOrDefault(d => d.to >= Convert.ToDecimal(amount)).period;

				if (matrix.Count() > 0)
				{
                    var toReturn = Max(flat, QuaterValue, PayablePercentageValue);
                 
                    return toReturn;
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("getCommisionAmount", "get Commision Amount = " + amount.ToString() + " Bank " + Bank.ToString() + " Currency " + curr, "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
			}
			return -1;
		}

        public static decimal QuarterComputer(decimal amount,int quater, decimal per)
        {
           return ( amount * per * quater)/ 100;
        }
        static decimal Max(params decimal[] numbers)
        {
            return numbers.Max();
        }

        public DateTime GetExpDate(DateTime bonddate, string period)
		{
			try
			{
				return bonddate.AddDays(Convert.ToDouble(period));
			}
			catch (Exception ex)
			{
				return DateTime.Today.Date;
			}

		}

		public async Task<int> GetBankUserAccountStatus(Guid userId)
		{
			try
			{
				var banker = await _context.TbBankUsers.FirstOrDefaultAsync(h => h.bankUserGuid == userId);
				if (!object.ReferenceEquals(banker, null))
				{
					return banker.status;
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("getBankUserAccountStatus", "get User Account Status for = " + userId.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
			}
			return -1;
		}
		public async Task<int> GetCompanyUserAccountStatus(Guid userId)
		{
			try
			{
				var banker = await _context.TbCompanyUsers.FirstOrDefaultAsync(h => h.compUserGuid == userId);
				if (!object.ReferenceEquals(banker, null))
				{
					return banker.status;
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("getBankUserAccountStatus", "get User Account Status for = " + userId.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
			}
			return -1;
		}
		public async Task<int> GetIndUserAccountStatus(Guid userId)
		{
			try
			{
				var banker = await _context.TbIndivuduals.FirstOrDefaultAsync(h => h.indGuid == userId);
				if (!object.ReferenceEquals(banker, null))
				{
					return banker.status;
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("getBankUserAccountStatus", "get User Account Status for = " + userId.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
			}
			return -1;
		}

		public async Task<List<Guid>> GetAllBankUsers(Guid guid)
		{
			try
			{
				return await _context.TbBankUsers.Where(h => h.SystemBanksGuid == guid).Select(j => j.bankUserGuid).ToListAsync();
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("getAllBankUsers", "get all User for bank = " + guid.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
			}
			return null;
		}
		public UserBase GetUserType(ApplicationUser _user)
		{
			UserBase ub = new UserBase();
			try
			{
				if (_user.indGuid != Guid.Empty)
				{
					ub.type = 1; ub.gui = _user.indGuid;
				}
				else if (_user.compUserGuid != Guid.Empty)
				{
					ub.type = 3; ub.gui = _user.compUserGuid;
				}
				else if (_user.bankUserGuid != Guid.Empty)
				{
					ub.type = 2; ub.gui = _user.bankUserGuid;
				}
				else
				{
					ub.type = 0; ub.gui = Guid.Empty;
				}
				return ub;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			//  return null;
		}
		public async Task<string> GetBankUserSysId(Guid id)
		{
			return (await _context.Users.FirstOrDefaultAsync(v => v.bankUserGuid == id)).Id;
		}

        //public async Task<bool>CallMailService(string email,string message,string subject,string cc,string bcc)
        //{
        //    try
        //    {
        //        var obj2 = new DbOperations.MailerJson()
        //        {
        //            bcc=bcc,
        //            Message=message,
        //            cc=cc,
        //            EMail=email,
        //            Subject=subject
        //        };

        //        /// Log in Tables
        //        var qq = await PostMailRequest(obj2);
        //        if (qq.Status.Trim().Equals("1000"))
        //        {
        //          //  err = "Merchant reference " + tbApplications.CRBGuid.ToString() + " already exists.";

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
		public async Task<bool> LogAndSendMail(string ToEmail, string Subj, string Message, string cc = "", string bcc = "")
		{
            bool sent = false;
            //Code Below will Invoke Email Service
            //try
            //{
            //    var obj2 = new DbOperations.MailerJson()
            //    {
            //        bcc = bcc,
            //        Message = Message,
            //        cc = cc,
            //        EMail = ToEmail,
            //        Subject = Subj
            //    };

            //    /// Log in Tables
            //    var qq = await PostMailRequest(obj2);
            //    if (qq.Code.Trim().Equals("1000"))
            //    {
            //        tbEmailLogs log = new tbEmailLogs()
            //        {
            //            to = ToEmail,
            //            from = "System ",
            //            subject = Subj,
            //            cc = cc,
            //            bcc = bcc,
            //            message = Message,
            //            date = DateTime.Now,
            //            status = qq.Success ? 1 : 2
            //        };
            //        _context.TbEmailLogs.Add(log);
            //        await _context.SaveChangesAsync();
            //        sent = true;
            //    }
            //    return sent;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            try
            {
                var j = await _emailSender.SendMail(ToEmail, Subj, Message, cc, bcc);

                tbEmailLogs log = new tbEmailLogs()
                {
                    to = ToEmail,
                    from = "System ",
                    subject = Subj,
                    cc = cc,
                    bcc = bcc,
                    message = Message,
                    date = DateTime.Now,
                    status = j ? 1 : 2
                };
                _context.TbEmailLogs.Add(log);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _databaseErrorLogger.logError("Log and Send Email", "Sending Email to " + ToEmail, "", ex.Message, object.ReferenceEquals(ex.InnerException, null) ? "" : ex.InnerException.ToString());
                return false;
            }

        }


		public async Task<bool> LogandSendSMS(string msisdn, string message,string userName,string apiKey,string From)
		{
			try
			{
                //var d = _sMSSender.Send_Sms(msisdn, message);
                //Get details from sysparam
                userName = _context.TbSysConfigs.FirstOrDefault(dd => dd.code == "SMS USERNAME").Value;
                apiKey = _context.TbSysConfigs.FirstOrDefault(dd => dd.code == "SMS API KEY").Value;
                From = _context.TbSysConfigs.FirstOrDefault(dd => dd.code == "SMS SENDER").Value;
				var d = SendSMS.Send_Sms(msisdn, message,userName,apiKey,From);
				var sms = new tbSMSLogs()
				{
					toPhone = msisdn,
					message = message,
					status = d ? 1 : 2,
					sentDate = DateTime.Now
				};
				_context.TbSMSLogs.Add(sms);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("logSMS", "Log Outgoing SMS to " + msisdn, message, ex.Message.ToString(), object.ReferenceEquals(ex.InnerException, null) ? "N/A" : ex.InnerException.ToString());
			}
			return false;
		}

		public async Task<Response> PostRequest(object _obj,bool Mpesa)
		{
			try
			{
                if (Mpesa == false)
                {
                    string url = object.ReferenceEquals(await _systemParameters.GetSysParameter("Kenswitch Checkout URL"), null) ? "http://apps.kenswitch.com:9090/onlinePayments/api/postPayment" : (await _systemParameters.GetSysParameter("Kenswitch Checkout URL")).Value.Trim();
                    WebRequest tRequest = WebRequest.Create(url); // MAin Req URL
                                                                  //WebRequest tRequest = WebRequest.Create("https://basiletu-78a75.firebaseio.com/.json");
                    tRequest.Method = "POST";
                    tRequest.ContentType = "application/json";
                    string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(_obj);

                    Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
                    //tRequest.Headers.Add(string.Format("auth: key={0}", key));
                    //tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                    tRequest.ContentLength = byteArray.Length;
                    tRequest.ContentType = "application/json";
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);

                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    String responseFromFirebaseServer = tReader.ReadToEnd();

                                    return Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseFromFirebaseServer);
                                }
                            }

                        }
                    }
                }
                else
                {
                    string url = object.ReferenceEquals(await _systemParameters.GetSysParameter("Mpesa Checkout URL"), null) ? "http://localhost:50915/api/LipaNaMpesa" : (await _systemParameters.GetSysParameter("Mpesa Checkout URL")).Value.Trim();
                    WebRequest tRequest = WebRequest.Create(url); // MAin Req URL
                                                                  //WebRequest tRequest = WebRequest.Create("https://basiletu-78a75.firebaseio.com/.json");
                    tRequest.Method = "POST";
                    tRequest.ContentType = "application/json";
                    string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(_obj);

                    Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
                    //tRequest.Headers.Add(string.Format("auth: key={0}", key));
                    //tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                    tRequest.ContentLength = byteArray.Length;
                    tRequest.ContentType = "application/json";
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);

                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    String responseFromFirebaseServer = tReader.ReadToEnd();

                                    return Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseFromFirebaseServer);
                                }
                            }

                        }
                    }

                }
			
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("Payment Request", "Log payment request to " + _obj, "", ex.Message.ToString(), object.ReferenceEquals(ex.InnerException, null) ? "N/A" : ex.InnerException.ToString());
			}
			return null;
		}

        public async Task<MpesaResponse> PostLipaNaMpesaRequest(object _obj, bool Mpesa)
        {
            try
            {
                if (Mpesa == true)
                {
                    string url = object.ReferenceEquals(await _systemParameters.GetSysParameter("Mpesa Checkout URL"), null) ? "http://localhost:50915/api/LipaNaMpesa" : (await _systemParameters.GetSysParameter("Mpesa Checkout URL")).Value.Trim();
                    WebRequest tRequest = WebRequest.Create(url); // MAin Req URL
                                                                  //WebRequest tRequest = WebRequest.Create("https://basiletu-78a75.firebaseio.com/.json");
                    tRequest.Method = "POST";
                    tRequest.ContentType = "application/json";
                    string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(_obj);

                    Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
                    //tRequest.Headers.Add(string.Format("auth: key={0}", key));
                    //tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                    tRequest.ContentLength = byteArray.Length;
                    tRequest.ContentType = "application/json";
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);

                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    String responseFromMpesaSPgW = tReader.ReadToEnd();

                                    return Newtonsoft.Json.JsonConvert.DeserializeObject<MpesaResponse>(responseFromMpesaSPgW);
                                }
                            }

                        }
                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                await _databaseErrorLogger.logError("Payment Request", "Log payment request to " + _obj, "", ex.Message.ToString(), object.ReferenceEquals(ex.InnerException, null) ? "N/A" : ex.InnerException.ToString());
            }
            return null;
        }

        public async Task<MpesaStatusResponse> PostLipaNaMpesaStatus(object _obj, bool Mpesa)
        {
            try
            {
                if (Mpesa == true)
                {
                    string url = object.ReferenceEquals(await _systemParameters.GetSysParameter("Mpesa StatusQuery URL"), null) ? "http://localhost:50915/api/LipaNaMpesaAccStatus" : (await _systemParameters.GetSysParameter("Mpesa StatusQuery URL")).Value.Trim();
                    WebRequest tRequest = WebRequest.Create(url); // MAin Req URL
                                                                  //WebRequest tRequest = WebRequest.Create("https://basiletu-78a75.firebaseio.com/.json");
                    tRequest.Method = "POST";
                    tRequest.ContentType = "application/json";
                    string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(_obj);

                    Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
                    //tRequest.Headers.Add(string.Format("auth: key={0}", key));
                    //tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                    tRequest.ContentLength = byteArray.Length;
                    tRequest.ContentType = "application/json";
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);

                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    String responseFromMpesaSPgW = tReader.ReadToEnd();

                                    return Newtonsoft.Json.JsonConvert.DeserializeObject<MpesaStatusResponse>(responseFromMpesaSPgW);
                                }
                            }

                        }
                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                await _databaseErrorLogger.logError("Payment Request", "Log payment request to " + _obj, "", ex.Message.ToString(), object.ReferenceEquals(ex.InnerException, null) ? "N/A" : ex.InnerException.ToString());
            }
            return null;
        }
        public async Task<MailerResponse> PostMailRequest(object _obj)
        {
            try
            {
                string url = _context.TbSysConfigs.FirstOrDefault(dd => dd.code == "MAILER URL").Value;
                WebRequest tRequest = WebRequest.Create(url);
                tRequest.Method = "POST";
                tRequest.ContentType = "application/json";
                string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(_obj);

                Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
                //tRequest.Headers.Add(string.Format("auth: key={0}", key));
                //tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;
                tRequest.ContentType = "application/json";
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String responseFromFirebaseServer = tReader.ReadToEnd();

                                return Newtonsoft.Json.JsonConvert.DeserializeObject<MailerResponse>(responseFromFirebaseServer);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                await _databaseErrorLogger.logError("Mail sending Request", "Log Mail Reuest to " + _obj, "", ex.Message.ToString(), object.ReferenceEquals(ex.InnerException, null) ? "N/A" : ex.InnerException.ToString());
            }
            return null;
        }



        public async Task<IPRSTokenResponse> IPRSTokenRequest(object _obj)
		{
			try
			{
				string url = object.ReferenceEquals(await _systemParameters.GetSysParameter("IPRS Token URL"), null) ? "http://apps.kenswitch.com:9090/RAPI/api/Solid/SubmitRequest" : (await _systemParameters.GetSysParameter("IPRS Token URL")).Value.Trim();
				WebRequest tRequest = WebRequest.Create(url);

				tRequest.Method = "POST";
				tRequest.ContentType = "application/json";
				string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(_obj);

				Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);

				tRequest.ContentLength = byteArray.Length;
				//tRequest.ContentType = "application/json";
				using (Stream dataStream = tRequest.GetRequestStream())
				{
					dataStream.Write(byteArray, 0, byteArray.Length);

					using (HttpWebResponse resp = (HttpWebResponse)tRequest.GetResponse())
					{
						using (Stream dataStreamResponse = resp.GetResponseStream())
						{
							using (StreamReader tReader = new StreamReader(dataStreamResponse))
							{
								String responseFromFirebaseServer = tReader.ReadToEnd();

								return Newtonsoft.Json.JsonConvert.DeserializeObject<IPRSTokenResponse>(responseFromFirebaseServer);
							}
						}

					}
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("IPRS Token Request", "Log IPRS Token to " + _obj, "", ex.Message.ToString(), object.ReferenceEquals(ex.InnerException, null) ? "N/A" : ex.InnerException.ToString());
			}
			return null;
		}

		public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

		public string Between(string value, string a, string b)
		{
			// T.Auma This function is to get a list of strings between 2 strings
			// Get positions for both string arguments.
			int posA = value.IndexOf(a);
			int posB = value.LastIndexOf(b);
			if (posA == -1)
				return "";
			if (posB == -1)
				return "";

			int adjustedPosA = posA + a.Length;
			if (adjustedPosA >= posB)
				return "";

			// Get the substring between the two positions.
			return value.Substring(adjustedPosA, posB - adjustedPosA);
		}


		#region individual search in CRB 
		public string CallWebService(string idno, string idtype)
		{
			try
			{
                var CrbUserName = _context.TbSysConfigs.FirstOrDefault(x => x.code == "CRB USERNAME").Value;
                var CrbPassWord = _context.TbSysConfigs.FirstOrDefault(x => x.code == "CRB PASSWORD").Value;
                var CrbUrl = _context.TbSysConfigs.FirstOrDefault(x => x.code == "CRB URL").Value;
                var CrbAction = _context.TbSysConfigs.FirstOrDefault(x => x.code == "CRB INDIV ACTION").Value;
                //https://wstest.creditinfo.co.ke/WsReport/v5.59/service.svc
               // var _url = "https://wstest.creditinfo.co.ke/WsReport/v5.46/service.svc";
              //  var _url = "https://wstest.creditinfo.co.ke/WsReport/v5.59/service.svc";
			//	var _action = "http://creditinfo.com/CB5/IReportPublicServiceBase/SearchIndividual";

				XmlDocument soapEnvelopeXml = CreateIndividualSoapEnvelope(idno, idtype);
				HttpWebRequest webRequest = CreateWebRequest(CrbUrl, CrbAction, CrbUserName, CrbPassWord);

				ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
				InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

				// begin async call to web request.
				IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

				// suspend this thread until call is complete. You might want to
				// do something usefull here like update your UI.
				asyncResult.AsyncWaitHandle.WaitOne();

				// get the response from the completed web request.
				string soapResult;
				using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
				{
					using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
					{
						soapResult = rd.ReadToEnd();
					}

					Console.Write(soapResult);
				}
				//<a:Status>SubjectNotFound</a:Status>



				// string mmm = exMessage; // "<?xml version='1.0' encoding='UTF-8'?><ns0:errorResponse xmlns:ns0='http://www.ericson.com/lwac' errorcode='TARGET_NOT_FOUND'><arguments name='fri' value='FRI:1375685/MM'/></ns0:errorResponse>"
				string res = Between(soapResult, "<a:Status>", "</a:Status>");

				return res;
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}

		private static HttpWebRequest CreateWebRequest(string url, string action,string uName,string pw)
		{
			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
			webRequest.Headers.Add("SOAPAction", action);
			webRequest.ContentType = "text/xml;charset=\"utf-8\"";
			webRequest.Accept = "text/xml";
			webRequest.Method = "POST";
			webRequest.Credentials = new NetworkCredential("fintech", pw);

			return webRequest;
		}

		private static XmlDocument CreateIndividualSoapEnvelope(string idno, string idtype)
		{
			XmlDocument soapEnvelopeDocument = new XmlDocument();

			soapEnvelopeDocument.LoadXml(@"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:cb5='http://creditinfo.com/CB5' xmlns:sear='http://creditinfo.com/CB5/v5.46/Search'><soapenv:Header/><soapenv:Body><cb5:SearchIndividual><cb5:query><sear:Parameters><sear:IdNumber>" + idno + "</sear:IdNumber><sear:IdNumberType>" + idtype + "</sear:IdNumberType></sear:Parameters></cb5:query></cb5:SearchIndividual></soapenv:Body></soapenv:Envelope>");


			return soapEnvelopeDocument;
		}

		private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
		{
			using (Stream stream = webRequest.GetRequestStream())
			{
				soapEnvelopeXml.Save(stream);
			}
		}


		#endregion individual search in CRB 

		#region Company search in CRB 


		public string CallCompanyWebService(string Consent, string IDNumber, string IDNumberType, string InquiryReason, string ReportDate, string ScoringReport, string SubjectType)
		{
			try
			{
                var CrbUserName = _context.TbSysConfigs.FirstOrDefault(x => x.code == "CRB USERNAME").Value;
                var CrbPassWord = _context.TbSysConfigs.FirstOrDefault(x => x.code == "CRB PASSWORD").Value;
                var CrbUrl = _context.TbSysConfigs.FirstOrDefault(x => x.code == "CRB URL").Value;
                var CrbAction = _context.TbSysConfigs.FirstOrDefault(x => x.code == "CRB ACTION").Value;

                var _url = "https://wstest.creditinfo.co.ke/WsReport/v5.59/service.svc";
                var _action = "http://creditinfo.com/CB5/IReportPublicServiceBase/GetCustomReport";
                XmlDocument soapEnvelopeXml = CreateCompanySoapEnvelope(Consent, IDNumber, IDNumberType, InquiryReason, ReportDate, ScoringReport, SubjectType);
				HttpWebRequest webRequest = CreateWebRequest(_url, _action, CrbUserName, CrbPassWord);

				ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
				InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

				// begin async call to web request.
				IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

				// suspend this thread until call is complete. You might want to
				// do something usefull here like update your UI.
				asyncResult.AsyncWaitHandle.WaitOne();

				// get the response from the completed web request.
				string soapResult;
				using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
				{
					using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
					{
						soapResult = rd.ReadToEnd();
					}

					Console.Write(soapResult);
				}

				string res = Between(soapResult, "<b:CIP>", "</b:CIP>");

				string res1 = Between(soapResult, "<b:Description>S", "</b:Description>");

				string CompDetails = Between(soapResult, "<b:General>", "</b:General>");

				string PinDetails = Between(soapResult, "<b:Identifications>", "</b:Identifications>");

				string AddressDetails = Between(soapResult, "<b:MainAddress>", "<b:SecondaryAddress>");

				string LinkedPesonDetails = Between(soapResult, "<b:RelatedParty>", "</b:RelatedParty>");

				string response = res + res1 + CompDetails + PinDetails + AddressDetails + LinkedPesonDetails;

				return response;
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}

		private static XmlDocument CreateCompanySoapEnvelope(string Consent, string IDNumber, string IDNumberType, string InquiryReason, string ReportDate, string ScoringReport, string SubjectType)
		{
			try
			{
				XmlDocument soapEnvelopeDocument = new XmlDocument();

                soapEnvelopeDocument.LoadXml(@"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:cb5='http://creditinfo.com/CB5' xmlns:cus='http://creditinfo.com/CB5/v5.59/CustomReport' xmlns:arr='http://schemas.microsoft.com/2003/10/Serialization/Arrays'><soapenv:Header/><soapenv:Body><cb5:GetCustomReport><cb5:parameters><cus:Consent>" + Consent + "</cus:Consent><cus:IDNumber>" + IDNumber + "</cus:IDNumber><cus:IDNumberType>" + IDNumberType + "</cus:IDNumberType><cus:InquiryReason>" + InquiryReason + "</cus:InquiryReason><cus:InquiryReasonText></cus:InquiryReasonText><cus:ReportDate>" + ReportDate + "</cus:ReportDate><cus:Sections><arr:string>" + ScoringReport + "</arr:string></cus:Sections ><cus:SubjectType>" + SubjectType + "</cus:SubjectType></cb5:parameters></cb5:GetCustomReport></soapenv:Body></soapenv:Envelope>");

                //soapEnvelopeDocument.LoadXml(@"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:cb5='http://creditinfo.com/CB5' xmlns:cus='http://creditinfo.com/CB5/v5.46/CustomReport' xmlns:arr='http://schemas.microsoft.com/2003/10/Serialization/Arrays'><soapenv:Header/><soapenv:Body><cb5:GetCustomReport><cb5:parameters><cus:Consent>" + Consent + "</cus:Consent><cus:IDNumber>" + IDNumber + "</cus:IDNumber><cus:IDNumberType>" + IDNumberType + "</cus:IDNumberType><cus:InquiryReason>" + InquiryReason + "</cus:InquiryReason><cus:InquiryReasonText></cus:InquiryReasonText><cus:ReportDate>" + ReportDate + "</cus:ReportDate><cus:Sections><arr:string>" + ScoringReport + "</arr:string></cus:Sections ><cus:SubjectType>" + SubjectType + "</cus:SubjectType></cb5:parameters></cb5:GetCustomReport></soapenv:Body></soapenv:Envelope>");


                return soapEnvelopeDocument;
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}

		public async Task UpdateCheckouStatus(PaymentResponsePost PRPost)
		{
			Guid id = Guid.Parse(PRPost.merchantreference);
			var application = await _context.TbApplications.FirstOrDefaultAsync(j => j.CRBGuid == id && j.status == 3);
			if(application != null)
			{
				application.PayRefrence = PRPost.transactionID;
				application.PayDate = DateTime.UtcNow;
				application.status = PRPost.statusCode == "00" ? 6 : 8;
				_context.TbApplications.Update(application);
				await _context.SaveChangesAsync();
				//TODO 
				// Notify paid to Bank Users and admin
				//Notify user payment received 
			}
		}

        public async Task<(bool,string)> AddDirector(tbDirectors directorDetails)
        {
            try
            {
                var directorDetailsExists = _context.TbDirectors.AsNoTracking().FirstOrDefault(d => d.CompanyId == directorDetails.CompanyId);
                if (directorDetailsExists != null)
                {
                    if (!string.IsNullOrWhiteSpace(directorDetailsExists.Email))
                    {
                        return (false, "A director with similar Email is already added");
                    }
                    //  var directorIdExists = _context.TbDirectors.FirstOrDefault(d => d.TelephoneNumber == directorDetails.IdNumber && d.CompanyId == directorDetails.CompanyId);

                    if (!string.IsNullOrWhiteSpace(directorDetailsExists.TelephoneNumber))
                    {
                        return (false, "A director with similar Phone Number is already added");
                    }
                    //   var directorPhoneExists = _context.TbDirectors.FirstOrDefault(d => d.IdNumber == directorDetails.IdNumber && d.CompanyId == directorDetails.CompanyId);
                    if (!string.IsNullOrWhiteSpace(directorDetailsExists.IdNumber))
                    {
                        return (false, "A director with similar Id Number is already added");
                    }
                }
              
                //call the constructors here 
                // var add = tbDirectors.AddDirector();

                var tbldirectors = new tbDirectors()
                {
                    Checker = Guid.Empty,
                    Maker = directorDetails.Maker,
                    CheckerComments = "",
                    checkerDate = null,
                    CompanyId = directorDetails.CompanyId,
                    Dob = directorDetails.Dob,
                    Email = directorDetails.Email,
                    FirstName = directorDetails.FirstName,
                    Id = Guid.NewGuid(),
                    IdNumber = directorDetails.IdNumber,
                    IdType = directorDetails.IdType,
                    LastName = directorDetails.LastName,
                    TelephoneNumber = directorDetails.TelephoneNumber,
                    Verified = false,
                    OtpVerified=false

                };
                _context.TbDirectors.Add(tbldirectors);
               var saved= await _context.SaveChangesAsync();
                var company = _context.TbCompanies.FirstOrDefault(c => c.compGuid == tbldirectors.CompanyId).compName;
                var Otp = RandomPassword();

                SaveDirectorOtp(tbldirectors.Id, Otp);
               await LogandSendSMS(tbldirectors.TelephoneNumber, "Dear"+" "+ tbldirectors .FirstName+", You have been registered as a company director for "+ company+" "+ "Please use below OTP for further approvals,"+" OTP: "+ Otp, "", "", "");
               await LogAndSendMail(tbldirectors.Email,"TradePawa - Director Registration" ,"Dear"+" "+ tbldirectors .FirstName+", You have been registered as a company director for "+ company+" "+ "Please use below OTP for further approvals,"+" OTP: "+ Otp, "", "");

                return (true, "Success");
            }
            catch (Exception ex)
            {
                await _databaseErrorLogger.logError("add company director", "add director with telNo = " + directorDetails.TelephoneNumber + " Type " + "", "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
            }
            return (false, "Failed to Add Director");
        }
        public bool SaveDirectorOtp(Guid userId,string MyOtp)
        {
            try
            {
                var newOtp = new tbOtpVerify
                {
                    Id = Guid.NewGuid(),
                    Otp = MyOtp,
                    TimeLogged = DateTime.Now,
                    Used = false,
                    UserId = userId
                };
                _context.Otp.Add(newOtp);
                var saved = _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
           
        }
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public int OtpGen(int min, int max)
        {

            Random random = new Random();
            return random.Next(min, max);
        }
        public string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(1, true));
            builder.Append(OtpGen(1000, 9999));
            builder.Append(RandomString(1, false));
            return builder.ToString();
        }
        public Task<bool> VerifyDirector(tbDirectors directorDetails)
        {
            throw new NotImplementedException();
        }

        public Task<tbDirectors> GetDirector(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> RegisterCompany(tbCompanies companyDetails)
        {
            try
            {
                tbCompanies comp = await _context.TbCompanies.SingleOrDefaultAsync(m => m.compName == companyDetails.compName
                && m.contact == companyDetails.contact && m.email == companyDetails.email);

                if (comp != null)
                {
                    return "This company already exists";
                    //ModelState.AddModelError(string.Empty, "This company already exists");
                    //return View(tbCompanies);
                }
                else
                {
                    var CompRegistrar = _context.TbIndivuduals.FirstOrDefault(c => c.indGuid.ToString() == companyDetails.registeredBy);

                    var newCompany = new tbCompanies()
                    {
                        compGuid = Guid.NewGuid(),
                        compName = companyDetails.compName,
                        email = companyDetails.email,
                        contact = companyDetails.contact,
                        PinNo = companyDetails.PinNo,
                        postalAddress = companyDetails.postalAddress,
                        pysicalLoc = companyDetails.pysicalLoc,
                        regDate = DateTime.Now,
                        registeredBy = CompRegistrar.indGuid.ToString(),
                        status = 0,
                        RegCertNo = companyDetails.RegCertNo,
                    };
                  
                    _context.Add(newCompany);

                    await _context.SaveChangesAsync();
                    await LogAndSendMail(CompRegistrar.email, "Company Registration", "Dear " + CompRegistrar.SirName + " Thank you for registering your company with us. You will receive an email notification once your details have been verified");

                    await AuditOperation(CompRegistrar.indGuid.ToString(), "Companies/Create", "Added a new company " + newCompany.compGuid.ToString(), "", "Companies");
                    return "Success";
                }

            }
            catch (Exception ex)
            {
                await LogError("Companies/Create", "Add new company", "", ex.Message.ToString(), ex.InnerException is null ? "" : ex.InnerException.ToString());
                // return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return "Failed";
        }

        public async Task<bool> AutoApprove(tbApplications application)
        {
            //Log Notification

            return false;
        }

        public async Task<bool> AddCompanyRole(tbCompanyUserRoles companyUserRole)
        {
            try
            {
                var newCompanyRole = tbCompanyUserRoles.AddCompanyRole(companyUserRole.RoleName, companyUserRole.CompanyId);
               
                _context.tbCompanyUserRoles.Add(newCompanyRole);
                var saved = await _context.SaveChangesAsync();
                return true;
            }
            catch (TradePowerExceptions ex)
            {
                await _databaseErrorLogger.logError("add CompanyUser Role", "add Company Role with name" + companyUserRole.RoleName + " Type " + "", "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
            }
            return false;
        }

        public async Task<bool> AddBankRole(tbBankUserRoles bankUserRole)
        {
            try
            {
                var newBankRole = tbBankUserRoles.AddBankRole(bankUserRole.RoleName, bankUserRole.BankId);

                _context.tbBankUserRoles.Add(newBankRole);
                var saved = await _context.SaveChangesAsync();
                return true;
            }
            catch (TradePowerExceptions ex)
            {
                await _databaseErrorLogger.logError("add Bank Role", "add Bank Role with name" + bankUserRole.RoleName + " Type " + "", "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
            }
            return false;
        }

        public async Task<bool> AddCompanyAcessRight(tbCompanyUserAccessRights companyUserAccessRight)
        {
            try
            {
                var newCompanyRoleRight = tbCompanyUserAccessRights.AddCompanyUserAccessRight(companyUserAccessRight.MenuId, companyUserAccessRight.RoleId, companyUserAccessRight.CompanyId);

                _context.tbCompanyUserAccessRights.Add(newCompanyRoleRight);
                var saved = await _context.SaveChangesAsync();
                return true;
            }
            catch (TradePowerExceptions ex)
            {
                await _databaseErrorLogger.logError("add Company Role Access Right", "add Company with Id" + companyUserAccessRight.CompanyId + " Type " + "", "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
            }
            return false;
        }

        public async Task<bool> AddBankAcessRight(tbBankUserAccessRights bankUserAccessRight)
        {
            try
            {
                var newBankRoleRight = tbBankUserAccessRights.AddBankUserAccessRight(bankUserAccessRight.MenuId, bankUserAccessRight.RoleId, bankUserAccessRight.BankId);

                _context.tbBankUserAccessRights.Add(newBankRoleRight);
                var saved = await _context.SaveChangesAsync();
                return true;
            }
            catch (TradePowerExceptions ex)
            {
                await _databaseErrorLogger.logError("add Bank Role Access Right", "add Bank with Id" + bankUserAccessRight.BankId + " Type " + "", "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
            }
            return false;
        }

        public async Task<BeneficiaryRegistrarDetails> GetBeneficiaryRegistrarDetails(tbBeneficiaries beneficiaries)
        {
            var who = new BeneficiaryRegistrarDetails();
            try
            {
                if (!object.ReferenceEquals(beneficiaries, null))
                {
                    var a = await _context.TbBeneficiaryEmployees.FirstOrDefaultAsync(x => x.institutionGuid == beneficiaries.institutionGuid);
                    who.sirname = a.SirName;
                    who.contact = a.contact;
                    who.email = a.email;

                    return who;
                }
            }
            catch (Exception ex)
            {
                await _databaseErrorLogger.logError("getWhoApplied", "get User Who Applied for = " + beneficiaries.institutionGuid.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
            }
            return null;
        }

        public async Task<decimal> GetBankCommisionAmount(decimal amount, Guid Bank, string curr, string Newperiod)
        {
            try
            {
                //var flat
                //var fixed
                //var quartely

                int n = int.Parse(Newperiod);
                bool FirstQuater = false;

                bool SecondQuater = false;
                bool ThirdQuater = false;
                bool FourthQuater = false;

                if (n > 0 && n <= 90)
                {
                    FirstQuater = true;
                }
                if (n > 90 && n <= 180)
                {
                    SecondQuater = true;
                }
                if (n > 180 && n <= 270)
                {
                    ThirdQuater = true;
                }
                if (n > 270 && n <= 360)
                {
                    FourthQuater = true;
                }



                //  var matrix = _context.TbComMatrices.Where(j => j.SystemBanksGuid == Bank && j.currency == curr);//OOriginal
                var matrix = _context.TbComMatrices.AsNoTracking().Where(j => j.currency == curr && j.SystemBanksGuid== Bank);

                var flat = matrix.FirstOrDefault().FlatRate;



                var percentageComm = matrix.FirstOrDefault().perCom;


                var PayablePercentageValue = (percentageComm * amount) / 100;

                decimal QuaterValue = 0M;

                if (FirstQuater == true)
                {
                    QuaterValue = QuarterComputer(amount, 1, percentageComm);
                }

                if (SecondQuater == true)
                {
                    QuaterValue = QuarterComputer(amount, 2, percentageComm);
                }
                if (ThirdQuater == true)
                {
                    QuaterValue = QuarterComputer(amount, 3, percentageComm);
                }
                if (FourthQuater == true)
                {
                    QuaterValue = QuarterComputer(amount, 4, percentageComm);
                }

                var per = matrix.FirstOrDefault().period;

                if (matrix.Count() > 0)
                {
                    var toReturn = Max(flat, QuaterValue, PayablePercentageValue);

                    return toReturn;
                }
            }
            catch (Exception ex)
            {
                await _databaseErrorLogger.logError("getBankCommisionAmount", "get Commision Amount = " + amount.ToString() + " Bank " + Bank.ToString() + " Currency " + curr, "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
            }
            return -1;
        }

        public async Task<decimal> GetPostAmmendCommisionAmount(decimal amount, Guid Bank, string curr, string Newperiod)
        {
            //TradePawaMatrix
            try
            {
                //var flat
                //var fixed
                //var quartely

                int n = int.Parse(Newperiod);
                bool FirstQuater = false;

                bool SecondQuater = false;
                bool ThirdQuater = false;
                bool FourthQuater = false;

                if (n > 0 && n <= 90)
                {
                    FirstQuater = true;
                }
                if (n > 90 && n <= 180)
                {
                    SecondQuater = true;
                }
                if (n > 180 && n <= 270)
                {
                    ThirdQuater = true;
                }
                if (n > 270 && n <= 360)
                {
                    FourthQuater = true;
                }



                //  var matrix = _context.TbComMatrices.Where(j => j.SystemBanksGuid == Bank && j.currency == curr);//OOriginal
                var matrix = _context.PostAmmendMentMatrix.AsNoTracking().Where(j => j.currency == curr);

                var flat = matrix.FirstOrDefault(d => d.to >= Convert.ToDecimal(amount)).FlatRate;


                var AmtTo = matrix.FirstOrDefault(d => d.to >= Convert.ToDecimal(amount)).to;


                var percentageComm = matrix.FirstOrDefault(d => d.to >= Convert.ToDecimal(amount)).perCom;


                var PayablePercentageValue = (percentageComm * amount) / 100;

                decimal QuaterValue = 0M;

                if (FirstQuater == true)
                {
                    QuaterValue = QuarterComputer(amount, 1, percentageComm);
                }

                if (SecondQuater == true)
                {
                    QuaterValue = QuarterComputer(amount, 2, percentageComm);
                }
                if (ThirdQuater == true)
                {
                    QuaterValue = QuarterComputer(amount, 3, percentageComm);
                }
                if (FourthQuater == true)
                {
                    QuaterValue = QuarterComputer(amount, 4, percentageComm);
                }

                var per = matrix.FirstOrDefault(d => d.to >= Convert.ToDecimal(amount)).period;

                if (matrix.Count() > 0)
                {
                    var toReturn = Max(flat, QuaterValue, PayablePercentageValue);

                    return toReturn;
                }
            }
            catch (Exception ex)
            {
                await _databaseErrorLogger.logError("getCommisionAmount", "get Commision Amount = " + amount.ToString() + " Bank " + Bank.ToString() + " Currency " + curr, "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
            }
            return -1;
        }

        public async Task<decimal> GetBankPostAmmendCommisionAmount(decimal amount, Guid Bank, string curr, string Newperiod)
        {
            try
            {
                //var flat
                //var fixed
                //var quartely

                int n = int.Parse(Newperiod);
                bool FirstQuater = false;

                bool SecondQuater = false;
                bool ThirdQuater = false;
                bool FourthQuater = false;

                if (n > 0 && n <= 90)
                {
                    FirstQuater = true;
                }
                if (n > 90 && n <= 180)
                {
                    SecondQuater = true;
                }
                if (n > 180 && n <= 270)
                {
                    ThirdQuater = true;
                }
                if (n > 270 && n <= 360)
                {
                    FourthQuater = true;
                }



                //  var matrix = _context.TbComMatrices.Where(j => j.SystemBanksGuid == Bank && j.currency == curr);//OOriginal
                var matrix = _context.BankAmmendmentMatrices.AsNoTracking().Where(j => j.currency == curr && j.SystemBanksGuid == Bank);

                var flat = matrix.FirstOrDefault().FlatRate;



                var percentageComm = matrix.FirstOrDefault().perCom;


                var PayablePercentageValue = (percentageComm * amount) / 100;

                decimal QuaterValue = 0M;

                if (FirstQuater == true)
                {
                    QuaterValue = QuarterComputer(amount, 1, percentageComm);
                }

                if (SecondQuater == true)
                {
                    QuaterValue = QuarterComputer(amount, 2, percentageComm);
                }
                if (ThirdQuater == true)
                {
                    QuaterValue = QuarterComputer(amount, 3, percentageComm);
                }
                if (FourthQuater == true)
                {
                    QuaterValue = QuarterComputer(amount, 4, percentageComm);
                }

                var per = matrix.FirstOrDefault().period;

                if (matrix.Count() > 0)
                {
                    var toReturn = Max(flat, QuaterValue, PayablePercentageValue);

                    return toReturn;
                }
            }
            catch (Exception ex)
            {
                await _databaseErrorLogger.logError("getBankPostAmmendmentCommisionAmount", "get PostAmmendmentCommisionAmount = " + amount.ToString() + " Bank " + Bank.ToString() + " Currency " + curr, "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
            }
            return -1;
        }

        public async Task<bool> LogMpesaPayment(MpesaPayments mpesaPayments)
        {
            try
            {
                var newMpesaPayment = new MpesaPayments//papa access there via constructors,,check validations.....
                {
                    AccountStatusDescription = mpesaPayments.AccountStatusDescription,
                    ApplicationId = mpesaPayments.ApplicationId,
                    CustomerMessage = mpesaPayments.CustomerMessage,
                    ErrorCode = mpesaPayments.ErrorCode,
                    ErrorMessage = mpesaPayments.ErrorMessage,
                    Id = Guid.NewGuid(),
                    LogDate = DateTime.Now,
                    MerchantRequestID = mpesaPayments.MerchantRequestID,
                    Paid = false,
                    ResponseCode = mpesaPayments.ResponseCode,
                    CheckoutRequestID = mpesaPayments.CheckoutRequestID,
                    ResponseDescription = mpesaPayments.ResponseDescription,
                    AccountStatusRespCode = ""
                };

                _context.MpesaPayments.Add(newMpesaPayment);
                var saved = await _context.SaveChangesAsync();
                return true;
            }
            catch (TradePowerExceptions ex)
            {
                await _databaseErrorLogger.logError("Log Mpesa Transaction", "Log transaction for application" + mpesaPayments.ApplicationId + " Type " + "", "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
                return false;
            }
            
        }

        public async Task<bool> UpdatePaymentstatus(MpesaPayments mpesaPayments)
        {
            try
            {
                var appId = _context.MpesaPayments.FirstOrDefault(c => c.CheckoutRequestID == mpesaPayments.CheckoutRequestID).ApplicationId;
                var updateAppTable = _context.TbApplications.FirstOrDefault(c => c.CRBGuid == appId);
                if (mpesaPayments.Paid == true)
                {
                    updateAppTable.status = 10;
                }
                updateAppTable.PayDate = DateTime.Now;
                updateAppTable.PayRefrence = mpesaPayments.CheckoutRequestID;
                _context.TbApplications.Update(updateAppTable);
                _context.MpesaPayments.Update(mpesaPayments);
                var saved = await _context.SaveChangesAsync();
                return true;
            }
            catch (TradePowerExceptions ex)
            {
                await _databaseErrorLogger.logError("Log Mpesa Transaction", "Log transaction for application" + mpesaPayments.ApplicationId + " Type " + "", "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
                return false;
            }
        }

        public async Task<bool> LogCrm(CrmLogs crmDetails)
        {
            try
            {
                var entityId = Guid.NewGuid();
                var userEmail = "";
                var UserPhoneNumber = "";

                //pick userid
                //check user role
                //if bank check bankid and log it
                //if company check company id and log it
                



                //call the constructors here 
                // var add = tbDirectors.AddDirector();

                var newcase = new CrmLogs()
                {
                    Id = Guid.NewGuid(),
                    CategoryCode=crmDetails.CategoryCode,
                    DateLogged=DateTime.Now,
                    DateResolved=DateTime.Now,
                    Description=crmDetails.Description,
                    EntityCategoryCode=crmDetails.EntityCategoryCode,
                    EntityId= crmDetails.EntityId,
                    Status=0,
                    UserEmail= crmDetails.UserEmail,
                    UserId=crmDetails.UserId,
                    UserPhoneNumber= crmDetails.UserPhoneNumber,

                };
                _context.CrmLogs.Add(newcase);
                var saved = await _context.SaveChangesAsync();


                //log to mail

                //



                //

                //var company = _context.TbCompanies.FirstOrDefault(c => c.compGuid == tbldirectors.CompanyId).compName;
                //var Otp = RandomPassword();

                //SaveDirectorOtp(tbldirectors.Id, Otp);
                //await LogandSendSMS(tbldirectors.TelephoneNumber, "Dear" + " " + tbldirectors.FirstName + ", You have been registered as a company director for " + company + " " + "Please use below OTP for further approvals," + " OTP: " + Otp, "", "", "");

                return true;
            }
            catch (Exception ex)
            {
                await _databaseErrorLogger.logError("Log Crm Case", "Loging Crm Case for user with email" + crmDetails.UserEmail + " Type " + "", "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
            }
            return false;
        }

        public async Task<ScanResponse> ValidateBarCode(string BarCode)
        {

            ScanResponse response = new ScanResponse();
            try
            {
                var valid = _context.TbApplications.AsNoTracking().FirstOrDefault(p => p.QrCode == BarCode);
               
                if (valid != null)
                {
                    var benef = _context.TbBeneficialies.AsNoTracking().FirstOrDefault(p => p.benGuid.ToString() == valid.Purchaser).FirstName;
                    var bank = _context.TbSystemBanks.AsNoTracking().FirstOrDefault(p => p.SystemBanksGuid == valid.SystemBanksGuid).bankName;
                    var company = _context.TbCompanies.AsNoTracking().FirstOrDefault(p => p.compGuid == valid.compGuid).compName;
                    //
                    if (valid.expireDate > DateTime.Now)
                    {
                        response.ResponseCode = 0;
                        response.ResponseDescription = "Valid BidBond";
                        response.Valid = true;
                        response.AppDetails = valid.Details;
                        response.BondAmount = valid.amount;
                        response.CoreBankingReference = valid.CoreBankingReferenceNumber;
                        response.TenderPeriod = valid.TenderPeriod;
                        response.TenderNo = valid.tenderNo;
                        response.DateApplied = valid.appDate;
                        response.ApplicantCompany = company;
                        response.Beneficiary = benef;
                        response.Bank = bank;
                        response.ExpiryDate = valid.expireDate;
                        //valid
                    }
                    else
                    {
                        response.ResponseCode = 2;
                        response.ResponseDescription = "Expired BidBond";
                        response.Valid = false;
                        response.AppDetails = valid.Details;
                        response.BondAmount = valid.approvedAmount;
                        response.CoreBankingReference = valid.CoreBankingReferenceNumber;
                        response.TenderPeriod = valid.TenderPeriod;
                        response.TenderNo = valid.tenderNo;
                        response.DateApplied = valid.appDate;
                        response.ApplicantCompany = valid.Details;
                        response.Beneficiary = valid.Details;
                        response.Bank = valid.Details;
                        response.ExpiryDate = valid.expireDate;
                        
                        //expired
                    }
                }
                else
                {
                    response.ResponseCode = 1;
                    response.ResponseDescription = "Invalid BidBond";
                    response.Valid = false;

                }
                return response;

            }
            catch (Exception ex)
            {
;
                await _databaseErrorLogger.logError("Validate BidBond", "Validating bidbond with barcode" + BarCode + " Type " + "", "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
                response.ResponseCode = 3;
                response.ResponseDescription = "Error Found During Validation,please contact System Admin";
                response.Valid = false;
                return response;
            }

        }

        
        public async Task<SendMailResponse> SendMailMobileApp(string BarCode, string Email)
        {
            SendMailResponse res = new SendMailResponse();
            try
            {
                var Det = _context.TbApplications.AsNoTracking().FirstOrDefault(p => p.QrCode == BarCode);
                var DetailsSection = "APPLICATION SUMMARY DETAILS";
                DetailsSection = DetailsSection.ToUpper();
                var messageBody = "Dear Sir/Madam," + Environment.NewLine + "The scanned Bid Bond matches with the following details;" +
                    Environment.NewLine+
                    Environment.NewLine + "Bid Bond Amount : Kes " + Det.amount +
                    Environment.NewLine + "Tender Number : " + Det.tenderNo +
                    Environment.NewLine + "Tenor : " + Det.TenderPeriod +
                    Environment.NewLine + "Expiry Date : " + Det.expireDate +
                    Environment.NewLine + "BidBond Reference Number : " + Det.CoreBankingReferenceNumber +
                    Environment.NewLine + "Date of Application : " + Det.appDate +
                    Environment.NewLine+
                    Environment.NewLine+
                    Environment.NewLine+
                    Environment.NewLine+
                    Environment.NewLine+
                    Environment.NewLine + "For  further clarification kindly get in touch with us through the following contact details;" +
                    Environment.NewLine + 
                    Environment.NewLine + "Email : info@tradepawa.com"+
                    Environment.NewLine + "Phone : (+254) 722 205426 "+
                    Environment.NewLine + "Website : www.tradepawa.com";

                var mailsent = await _emailSender.SendMail(Email,"BidBond Validation", messageBody, "","", Det.BidBondPath);
                // await LogAndSendMail(Email, "Gichuhi To Define Message", "BidBod Validation"); //This calls external mailer...No attachments implemented yet

                if (mailsent == true)
                {
                    res.ResponseCode = 0;
                    res.ResponseDescription = "Email Sent Successfully";
                    res.Sent = true;
                }
                else
                {

                    res.ResponseCode = 1;
                    res.ResponseDescription = "Email Sending Failed";
                    res.Sent = false;
                }
                return res;
            }
            catch (Exception ex)
            {
                await _databaseErrorLogger.logError("Send Mail From Mobile App", "Sending mail for document with barcode" + BarCode + " Type " + "", "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
                res.ResponseCode = 3;
                res.ResponseDescription = "Email Sending Error Found,Contact System Admin";
                res.Sent = false;
                return res;
            }
           

        }

        public async Task<SpaRegistrarDetails> GetSpaRegistrarDetails(SpaDetails spa)
        {
            var who = new SpaRegistrarDetails();
            try
            {
                if (!object.ReferenceEquals(spa, null))
                {
                    var a = await _context.SpaUsers.FirstOrDefaultAsync(x => x.spaGuid == spa.spaGuid);
                    who.sirname = string.Concat(a.FirstName, " ", a.LastName);
                    who.contact = a.contact;
                    who.email = a.email;

                    return who;
                }
            }
            catch (Exception ex)
            {
                await _databaseErrorLogger.logError("getWhoApplied", "get User Who Applied for = " + spa.spaGuid.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
            }
            return null;
        }

        public async Task<string> GetSpaUserRole(Guid guid, int userType)
        {
            try
            {
                Guid spaId = Guid.Empty;
                switch (userType)
                {
                    case 1:
                        {
                            spaId = _context.SpaUsers.FirstOrDefault(h => h.spaUserGuid == guid).spaGuid;
                            break;
                        }
                    case 2:
                        {
                            //userId = _context.Users.FirstOrDefault(h => h.bankUserGuid == guid).Id;
                            break;
                        }
                    case 3:
                        {
                           // userId = _context.Users.FirstOrDefault(h => h.userGuid == guid).Id;
                            break;
                        }
                    case 4:
                        {
                           // userId = _context.Users.FirstOrDefault(h => h.spaUserGuid == guid).Id;
                            break;
                        }
                }
                if (spaId != null)
                {
                    var role = _context.SpaRoles.FirstOrDefault(h => h.SpaDetailsId == spaId);
                    if (!object.ReferenceEquals(role, null))
                    {
                        return role.RoleName;
                    }
                }
            }
            catch (Exception ex)
            {
                await _databaseErrorLogger.logError("getUserRole", "get User Role for = " + guid.ToString() + " Type " + userType.ToString(), "", ex.Message.ToString(), ex.InnerException is null ? "N /A" : ex.InnerException.ToString());
            }

            return null;
        }
        #endregion

        public class UserBase
		{
			/// <summary>
			/// 0 = Master,
			/// 1 = Individual,
			/// 2 = Bank,
			/// 3 = Company
			/// </summary>
			public int type { get; set; }
			public Guid gui { get; set; }
		}

        public class MailerResponse
        {
            public bool Success { get; set; }
            public string Description { get; set; }
            public string Code { get; set; }

        }
        public class MpesaStatusResponse
        {
            public string MerchantRequestID { get; set; }
            public string CheckoutRequestID { get; set; }
            public string ResponseCode { get; set; }
            public string ResultDesc { get; set; }
            public string ResponseDescription { get; set; }
            public string ResultCode { get; set; }
            public string requestId { get; set; }
            public string errorCode { get; set; }
            public string errorMessage { get; set; }

        }
        public class MpesaResponse
        {
            public string requestId { get; set; }

            public string errorCode { get; set; }

            public string errorMessage { get; set; }

            public string ResponseDescription { get; set; }

            public string CustomerMessage { get; set; }
            public string MerchantRequestID { get; set; }

            public string CheckoutRequestID { get; set; }

            public string ResponseCode { get; set; }
            public string StatusDescription { get; set; }
            public string status { get; set; }
            public bool isCompleted { get; set; }
            public bool isCompletedSuccessfully { get; set; }
            public MpesaResult result { get; set; }

    }
    public class MpesaResult
    {
        public string requestId { get; set; }

        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public string responseDescription { get; set; }
        public string customerMessage { get; set; }
        public string merchantRequestID { get; set; }
        public string checkoutRequestID { get; set; }
        public string responseCode { get; set; }
    }
    public class Response
		{
			public string Status { get; set; }

			public string StatusDescription { get; set; }

			public Result Result { get; set; }

		}
		public class Result
		{
			public string TransactionID { get; set; }

			public string URL { get; set; }
		}
       
    public class CheckOutJson
		{
			public string username { get; set; }

			public string merchantToken { get; set; }

			public string msisdn { get; set; }

			public string merchantreference { get; set; }

			public string firstname { get; set; }

			public string lastname { get; set; }

			public string address { get; set; }

			public string currency { get; set; }

			public string email { get; set; }

			public string ordersummary { get; set; }

			public double amount { get; set; }

			public string merchantURL { get; set; }

			public string accountNumber { get; set; }

			public string extraData { get; set; }
			public string ServiceID { get; set; }
			public string PromoCode { get; set; }
			public string Discount { get; set; }
		}
        public class MpesaCheckOutJson
        {
            public string businessShortCode { get; set; }

            public string timestamp { get; set; }

            public string transactionType { get; set; }

            public string amount { get; set; }

            public string partyA { get; set; }

            public string partyB { get; set; }

            public string phoneNumber { get; set; }

            public string callBackURL { get; set; }

            public string accountReference { get; set; }

            public string transactionDesc { get; set; }

            public string passkey { get; set; }

            public string consumerSecret { get; set; }

            public string consumerKey { get; set; }
            public MpesaCheckOutJson () { }

            //public MpesaCheckOutJson(string businessShortCode, string timestamp, string transactionType, string amount, string partyA, string partyB, string phoneNumber, string callBackURL, string accountReference, string transactionDesc, string passkey, string consumerSecret, string consumerKey)
            //{
            //    this.accountReference = accountReference;
            //    this.amount = amount;
            //    this.businessShortCode = businessShortCode;
            //    this.consumerSecret = consumerSecret;
            //    this.consumerKey = consumerKey;
            //    this.callBackURL = callBackURL;
            //    this.partyA = partyA;
            //    this.partyB = partyB;
            //    this.phoneNumber = phoneNumber;
            //    this.transactionDesc = transactionDesc;
            //    this.transactionType = transactionType;
            //    this.passkey = passkey;
            //    this.timestamp=timestamp;
            //}

        }
        public class LipaNaMpesaStatusRequest
        {
            public string businessShortCode { get; set; }
            public string passkey { get; set; }
            public string timestamp { get; set; }
            public string checkoutRequestID { get; set; }
            public string consumerSecret { get; set; }
            public string consumerKey { get; set; }
        }
        public class InitiateMpesaRequest
        {
            public MpesaCheckOutJson b2CRequest { get; set; }
        }

        public class InitiateLipaNaMpesaStatusRequest
        {
            public LipaNaMpesaStatusRequest b2CRequest { get; set; }
        }
        public class MailerJson
        {
            public string EMail { get; set; }
            public string Message { get; set; }
            public string Subject { get; set; }
            public string cc { get; set; }
            public string bcc { get; set; }

        }
        public class DetailOfWhoApplied
		{
			public string firstName { get; set; }
			public string lastName { get; set; }
			public string msisdn { get; set; }
			public string email { get; set; }
			public string address { get; set; }
			public string CompanyAddress { get; set; }

		}

        public class BeneficiaryRegistrarDetails
        {
            public string sirname { get; set; }
            public string contact { get; set; }
            public string email { get; set; }
        }
        public class CompanyRegistrarDetails
		{
			public string sirname { get; set; }
			public string contact { get; set; }
			public string email { get; set; }
		}
        public class SpaRegistrarDetails
        {
            public string sirname { get; set; }
            public string contact { get; set; }
            public string email { get; set; }
        }

        public class DetailBeneficiary
		{
			public string BenefName { get; set; }
			public string lastName { get; set; }
			public string email { get; set; }
			public string address { get; set; }
		}
		// Start of get token functions 
		public class IPRSToken
		{
			public Message_validation message_validation { get; set; }
			public Message_route message_route { get; set; }
		}
		public class Message_validation
		{
			public string api_user { get; set; }
			public string api_password { get; set; }
		}
		public class Message_route
		{
			public string @interface { get; set; }

		}

		public class IPRSTokenResponse
		{
			public string error_code { get; set; }

			public Error_desc error_Desc { get; set; }

		}

		public class Error_desc
		{
			public string token { get; set; }

			public DateTime expiry { get; set; }
		}

		// End of get token functions   

	}
}
