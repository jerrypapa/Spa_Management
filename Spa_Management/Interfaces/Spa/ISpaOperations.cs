using Spa_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Interfaces.Spa
{
    public interface ISpaOperations
    {
        Task<(bool, string)> RegisterSpa(SpaDetails spaDetails,SpaUsers spaUsers);
       // Task<(bool, string)> RegisterSpaUser(SpaUsers spaUsers);
    }
}
