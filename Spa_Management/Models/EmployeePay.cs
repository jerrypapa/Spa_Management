using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class EmployeePay
    {
        public Guid Id { get; set; }
        public Guid SpaUsersId { get; set; }
        public  SpaUsers SpaUsers { get; set; }
        public decimal GrossPay { get; set; }
        public decimal CommisionPerJob { get; set; }
        public int Status { get; set; }
    }
}
