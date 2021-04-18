using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbBondProcessingActions
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
