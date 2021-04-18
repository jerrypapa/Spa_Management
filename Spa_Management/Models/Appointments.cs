using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class Appointments
    {
        public Guid Id { get; set; }
        public Guid SpaCustomersId { get; set; }
        public SpaCustomer SpaCustomers { get; set; }
        public Guid SpaDetailsId { get; set; }
        public  SpaDetails SpaDetails { get; set; }
        public int Status { get; set; }
        public DateTime ReservationDate { get; set; }
        public Guid SpaServicesId { get; set; }
        public  SpaServices SpaServices { get; set; }
        public virtual List<CompletedJobs> CompletedJobs { get; set; }
    }
}
