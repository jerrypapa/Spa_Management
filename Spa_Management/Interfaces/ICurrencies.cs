using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Interfaces
{
    public interface ICurrencies
    {
        string FormatCurrency(decimal amount);
    }
}
