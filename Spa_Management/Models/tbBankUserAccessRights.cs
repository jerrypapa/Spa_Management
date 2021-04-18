using Spa_Management.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbBankUserAccessRights
    {
        public Guid Id { get; private set; }
      
        public Guid BankId { get; private set; }
        public Guid MenuId { get; private set; }
      //  public virtual IEnumerable<tbMenus> Menus { get; set; }
        public Guid RoleId { get; private set; }
       // public virtual IEnumerable<tbCompanyUserRoles> CompanyUserRoles { get; set; }
      
        public tbBankUserAccessRights(Guid menuId, Guid roleId,Guid bankId)
        {
            Id = Guid.NewGuid();
            MenuId = menuId;
            RoleId = roleId;
            BankId = bankId;
            // RoleId = roleId;
            // PageUrl = !string.IsNullOrWhiteSpace(pageUrl) ? pageUrl : throw new TradePowerExceptions(nameof(pageUrl)); ;
        }
        public static tbBankUserAccessRights AddBankUserAccessRight(Guid menuId, Guid roleId, Guid bankId)
        {
            return new tbBankUserAccessRights(menuId, roleId,bankId);
        }
          public tbBankUserAccessRights() { }
    }
}
