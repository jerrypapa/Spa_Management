using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class SpaRoles
    {
        public Guid Id { get; set; }
        public Guid SpaDetailsId { get; set; }
        public SpaDetails SpaDetails { get; set; }
        public int Status { get; set; }
        public string RoleName { get; set; }
        public virtual List<SpaUsers> SpaUsers { get; set; }
    }
}
