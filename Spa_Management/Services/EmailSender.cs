using Spa_Management.Interfaces;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Spa_Management.Services
{
	public class EmailSender : IEmailSender
	{
		private readonly ISystemParameters _systemParameters;
		private readonly IDatabaseErrorLogger _databaseErrorLogger;
		public EmailSender(ISystemParameters systemParameters, IDatabaseErrorLogger databaseErrorLogger)
		{
			_systemParameters = systemParameters;
			_databaseErrorLogger = databaseErrorLogger;
		}
		public async Task<bool> SendMail(string ToEmail, string Subj, string Message, string cc = "", string bcc = "", string fileName = "")
		{
			try
			{
				SmtpClient smtp = new SmtpClient();
				MailMessage mailMessage = new MailMessage();
                string email = (await _systemParameters.GetSysParameter("outgoing email address")).Value.Trim() ?? "jerrybrads38@gmail.com";
				string header = (await _systemParameters.GetSysParameter("outgoing email Header")).Value.Trim() ?? "Instant Spa Notifications";
				string pwd = (await _systemParameters.GetSysParameter("outgoing email Password")).Value.Trim() ?? "Wilfrida";
				string port = (await _systemParameters.GetSysParameter("outgoing email Port")).Value.Trim() ?? "587";
				string Timeout = (await _systemParameters.GetSysParameter("outgoing email Timeout")).Value.Trim() ?? "4000";
				mailMessage.From = new MailAddress(email, header);
				mailMessage.Subject = Subj;
				mailMessage.Body = Message;
				mailMessage.IsBodyHtml = false;
				mailMessage.Priority = MailPriority.Normal;
                if (fileName.Length > 0)
                {
                    Attachment attachment;
                    attachment = new Attachment(fileName);
                    mailMessage.Attachments.Add(attachment);
                }
                    if (ToEmail.Length > 0)
				{
					string[] ToMuliId = ToEmail.Split(',');
					foreach (string ToEMailId in ToMuliId)
					{
						mailMessage.To.Add(new MailAddress(ToEMailId)); //adding multiple TO Email Id  
					}
				}
				if (cc.Length > 0)
				{
					string[] CCId = cc.Split(',');
					foreach (string CCEmail in CCId)
					{
						mailMessage.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id  
					}
				}
				if (bcc.Length > 0)
				{
					string[] bccid = bcc.Split(',');
					foreach (string bccEmailId in bccid)
					{
						mailMessage.Bcc.Add(new MailAddress(bccEmailId)); //Adding Multiple BCC email Id  
					}
				}
               

                smtp.EnableSsl = true;
				smtp.Host = "smtp.gmail.com";
				NetworkCredential NetworkCred = new NetworkCredential();
				NetworkCred.UserName = mailMessage.From.Address;
				NetworkCred.Password = pwd;
				//smtp.UseDefaultCredentials = false;
				smtp.Credentials = NetworkCred;
				smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtp.Port =int.Parse(port);
                smtp.Timeout =int.Parse(Timeout);
				smtp.Send(mailMessage);
				return true;

			}
			catch (Exception ex)
			{
			   await _databaseErrorLogger.logError("Send Email", "Sending Email to " + ToEmail, "", ex.Message, object.ReferenceEquals(ex.InnerException, null) ? "" : ex.InnerException.ToString());
                return false;
            }
			
		}
	}
}
