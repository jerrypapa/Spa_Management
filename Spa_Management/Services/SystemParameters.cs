using System;
using System.Threading.Tasks;
using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Spa_Management.Services
{
	public class SystemParameters : ISystemParameters
	{
		private readonly IDatabaseErrorLogger _databaseErrorLogger;
		private readonly ApplicationDbContext _context;
		public SystemParameters(IDatabaseErrorLogger databaseErrorLogger, ApplicationDbContext context)
		{
			_databaseErrorLogger = databaseErrorLogger;
			_context = context;
		}
		public async Task<tbSysConfigs> GetSysParameter(string code)
		{
			try
			{
				var config = await _context.TbSysConfigs.FirstOrDefaultAsync(t => t.code.Trim() == code.Trim().ToUpper() && t.status == 0);
				if (!object.ReferenceEquals(config, null))
				{
					return config;
				}
			}
			catch (Exception ex)
			{
				await _databaseErrorLogger.logError("getSysParameter", "get Sys Parameter For " + code, "N/A", ex.Message, object.ReferenceEquals(ex.InnerException, null) ? "N/A" : ex.InnerException.ToString());
			}
			return null;
		}
	}
}
