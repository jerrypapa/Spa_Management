using Spa_Management.Interfaces;
using System;
using System.Threading.Tasks;

namespace Spa_Management.Services
{
	public class SMSSender : ISMSSender
	{
		public Task<bool> Send_Sms(string fonNumber, string mess)
		{
			throw new NotImplementedException();
		}
	}
}
