using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models.AccountViewModels
{
    public class AppLoginResponse
    {
        /// <summary>
        /// 000 Success
        /// 0001 Fail
        /// 0002 Locked Out
        /// 0003 Confirm Email
        /// </summary>
        public string Code { get; set; }
        public string Description { get; set; }
        public string InstitutionName { get; set; }
    }
}
