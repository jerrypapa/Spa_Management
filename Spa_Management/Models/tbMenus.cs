using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbMenus
    {
        public Guid Id { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
      
       // public virtual IEnumerable<tbBankUserAccessRights> tbBankUserAccessRights { get; set; }
        //public virtual IEnumerable<tbCompanyUserAccessRights> tbCompanyUserAccessRights { get; set; }
        public tbMenus() { }
        public tbMenus(string name,string url) {
            Id = Guid.NewGuid();
            MenuName = name;
            MenuUrl = url;     
        }
    }
}
