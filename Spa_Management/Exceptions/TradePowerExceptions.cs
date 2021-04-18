using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Exceptions
{
    public class TradePowerExceptions: Exception
    {
        public TradePowerExceptions()
        { }

        public TradePowerExceptions(string message)
            : base(message)
        { }

        public TradePowerExceptions(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
