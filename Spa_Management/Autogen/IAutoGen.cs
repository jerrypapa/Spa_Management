using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Autogen
{
    public interface IAutoGen
    {
        Task<(bool,string,string,string)> AutoGenerateBond(Guid applicationId, bool bankAccess);
        Task<(bool,string,string,string)> AutoGenerateBondFamily(Guid applicationId, bool bankAccess);
        string GetProdCode();
    }
}
