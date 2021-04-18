using System.Threading.Tasks;

namespace Spa_Management.Interfaces
{
	public interface ISMSSender
	{
		Task<bool> Send_Sms(string fonNumber, string mess);
	}
}
