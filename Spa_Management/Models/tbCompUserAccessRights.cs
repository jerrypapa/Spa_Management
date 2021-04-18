using Spa_Management.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbCompanyUserAccessRights
    {
        public Guid Id { get; private set; }
       
        public Guid CompanyId { get; private set; }
        public Guid MenuId { get; private set; }
       // public virtual IEnumerable<tbMenus> Menus { get; set; }
        public Guid RoleId { get; private set; }
     //   public virtual IEnumerable<tbCompanyUserRoles> CompanyUserRoles { get; set; }
        public tbCompanyUserAccessRights() { }
        public tbCompanyUserAccessRights(Guid menuId,Guid roleId,Guid companyId)
        {
            Id = Guid.NewGuid();
            MenuId = menuId;
            RoleId = roleId;
            CompanyId = companyId;
           // RoleId = roleId;
           // PageUrl = !string.IsNullOrWhiteSpace(pageUrl) ? pageUrl : throw new TradePowerExceptions(nameof(pageUrl)); ;
        }
        public static tbCompanyUserAccessRights AddCompanyUserAccessRight(Guid menuId, Guid roleId, Guid companyId)
        {
            return new tbCompanyUserAccessRights(menuId, roleId,companyId);
        }
    }
}
