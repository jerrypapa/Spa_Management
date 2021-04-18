using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Interfaces
{
	public interface IEmailSender
	{
		Task<bool> SendMail(string ToEmail, string Subj, string Message, string cc = "", string bcc = "", string fileName = "");
	}
}
