using Spa_Management.Models;
using System.Threading.Tasks;

namespace Spa_Management.Interfaces
{
	public interface ISystemParameters
	{
		Task<tbSysConfigs> GetSysParameter(string code);
	}
}
