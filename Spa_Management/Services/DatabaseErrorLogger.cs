using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Spa_Management.Services
{
	public class DatabaseErrorLogger : IDatabaseErrorLogger
	{
		private readonly ApplicationDbContext _context;
		public DatabaseErrorLogger(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task logError(string action, string desc, string json, string errMsg, string innerEx, string modelValid = null, string sess = null)
		{
			try
			{
				var errors = new tbErrorLogs()
				{
					sessionId = sess,
					action = action,
					Description = desc,
					json = json,
					OpDate = DateTime.Now,
					errorMessage = errMsg,
					innerExemption = innerEx,
					modelValidation = modelValid,
					attStatus = 0
				};
				_context.TbErrorLogs.Add(errors);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				ErrorLogging(ex);
			}
		}
		private static void ErrorLogging(Exception ex)
		{
			//string filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

			string strPath = @"c:\TEMP\Spa_Managementlogs.txt";//Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ErrorLogs", "Log.txt");
													   // string path = Microsoft.AspNetCore.Http.HttpContext.Current.Server.MapPath(@"");
			if (!File.Exists(strPath))
			{
				File.Create(strPath).Dispose();
			}
			using (StreamWriter sw = File.AppendText(strPath))
			{
				sw.WriteLine("=============Error Logging ===========");
				sw.WriteLine("===========Start============= " + DateTime.Now);
				sw.WriteLine("Error Message: " + ex.Message);
				sw.WriteLine("Stack Trace: " + ex.StackTrace);
				sw.WriteLine("===========End============= " + DateTime.Now);

			}
		}
	}
}
