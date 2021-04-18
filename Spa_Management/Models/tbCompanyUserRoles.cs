using Spa_Management.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbCompanyUserRoles
    {
        public Guid Id { get; private set; }
        public string RoleName { get; private set; }
        public DateTime DateAdded { get; private set; }
        public Guid CompanyId { get; private set; }
      //  public virtual IEnumerable<tbCompanyUserAccessRights> tbCompanyUserAccessRights { get; set; }
        public tbCompanyUserRoles() { }
        public tbCompanyUserRoles(string role,Guid compId)
        {
            Id = Guid.NewGuid();
            DateAdded = DateTime.Now;
            RoleName = !string.IsNullOrWhiteSpace(role) ? role : throw new TradePowerExceptions(nameof(role)); 
            CompanyId = compId;
        }
        public static tbCompanyUserRoles AddCompanyRole(string role,Guid compGuid)
        {
            return new tbCompanyUserRoles(role,compGuid);
        }
    }
}
