using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Interfaces
{
    public class Currencies : ICurrencies
    {
        public string FormatCurrency(decimal amount)
        {
            var regionInfo = new RegionInfo("sw-KE");
            var currencySymbol = regionInfo.ISOCurrencySymbol;
            var formattedCurrency = String.Format(new System.Globalization.CultureInfo("sw-KE"), "{0:c}", amount);
            return formattedCurrency;
        }
    }
}
