using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Interfaces
{
    public interface IRouter
    {
        Task<(Guid?,string, Guid?,string,string)> ToRoute(decimal bondValue,string CustomerToPrint);
        Task<bool> ReduceOveralLimit(Guid bankId,decimal AmountToReduce);
    }
}
