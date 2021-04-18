using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Interfaces
{
	public interface IDatabaseErrorLogger
	{
		Task logError(string action, string desc, string json, string errMsg, string innerEx, string modelValid = null, string sess = null);
	}
}
