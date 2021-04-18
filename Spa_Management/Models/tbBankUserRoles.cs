using Spa_Management.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbBankUserRoles
    {
        public Guid Id { get;private set; }
        public Guid BankId { get;private set; }
        public string RoleName { get;private set; }
        public DateTime DateAdded { get;private set; }
        public virtual IEnumerable<tbBankUserAccessRights> tbBankUserAccessRights { get; set; }
        public tbBankUserRoles() { }
        public tbBankUserRoles(string role,Guid bankId)
        {
            Id = Guid.NewGuid();
            DateAdded = DateTime.Now;
            RoleName = !string.IsNullOrWhiteSpace(role) ? role : throw new TradePowerExceptions(nameof(role)); 
            BankId = bankId;
        }
        public static tbBankUserRoles AddBankRole(string role,Guid bankId)
        {
            return new tbBankUserRoles(role,bankId);
        }
    }
}
