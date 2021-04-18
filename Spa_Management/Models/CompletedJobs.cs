using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class CompletedJobs
    {
        public Guid Id { get; set; }
        public Guid AppointmentsId { get; set; }
        public Appointments Appointments{ get; set; }
        public string PaymentReference { get; set; }
        public decimal EmployeeShare { get; set; }
        public decimal BusinessRetainedShare { get; set; }
        public string CustomerFeedback { get; set; }
        public int CustomerRating { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
