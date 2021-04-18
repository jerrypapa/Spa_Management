using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class SpaServices
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public Guid SpaDetailsId { get; set; }
        public SpaDetails SpaDetails{ get; set; }
        public virtual List<Appointments> Appointments { get; set; }
    }
}
