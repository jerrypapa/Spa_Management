using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class MpesaPayments
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public DateTime LogDate { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public string ResponseDescription { get; set; }
        public string AccountStatusRespCode { get; set; }

        public string CustomerMessage { get; set; }
        public string MerchantRequestID { get; set; }

        public string CheckoutRequestID { get; set; }

        public string ResponseCode { get; set; }
        public bool Paid { get; set; }
        public string AccountStatusDescription { get; set; }
        public MpesaPayments() { }
    }
}
