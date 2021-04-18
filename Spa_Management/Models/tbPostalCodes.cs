using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbPostalCodes
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public int Status { get; set; }
        public string RegionName { get; set; }
    }
}
