using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Operations
{
    //public class ApplicationDetails
    //{
    //    public string AppDetails { get; set; }
    //    public DateTime DateApplied { get; set; }
    //    public string Bank { get; set; }
    //    public string Beneficiary { get; set; }
    //    public DateTime ExpiryDate { get; set; }
    //    public string TenderPeriod { get; set; }
    //    public string CoreBankingReference { get; set; }
    //    public decimal BondAmount { get; set; }
    //    public string ApplicantCompany { get; set; }
    //    public string TenderNo { get; set; }
    //}
    public class ScanResponse
    {
        public bool Valid { get; set; }
        /// <summary>
        /// 0 Valid
        /// 1 Invalid
        /// 2 Expired
        /// 3 SystemError
        /// </summary>
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string AppDetails { get; set; }
        public DateTime DateApplied { get; set; }
        public string Bank { get; set; }
        public string Beneficiary { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string TenderPeriod { get; set; }
        public string CoreBankingReference { get; set; }
        public decimal BondAmount { get; set; }
        public string ApplicantCompany { get; set; }
        public string TenderNo { get; set; }
    }
    public class SendMailResponse{

        public bool Sent { get; set; }
        /// <summary>
        /// 0 Sent
        /// 1 Failed
        /// 2 Queud
        ///  3 SystemError
        /// </summary>
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
    }
}
