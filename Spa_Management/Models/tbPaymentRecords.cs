using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbPaymentRecords
    {
        public Guid Id { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal Spa_ManagementShare { get; set; }
        public decimal BankShare { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid BankId { get; set; }
        /// <summary>
        /// 0 Normal
        /// 1 Major Ammendments
        /// 2 Minor Ammendments
        /// </summary>
        public int CommisionType { get; set; }
    }
}
