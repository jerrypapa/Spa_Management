using Spa_Management.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbApplications
    {
        [Key]
        public Guid CRBGuid { get; set; }

        //[Required]
        public Guid indGuid { get; set; }

        //Company
        public Guid compGuid { get; set; }

        //Applied By
        [Required]
        [Display(Name = "Applied By")]
        public string appliedBy { get; set; }

        //Application Time
        [Required]
        [Display(Name = "Application Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:MM\/dd\/yyyy}")]
        public DateTime appDate { get; set; }

        //Bank
        [Required]
        [Display(Name = "Bank")]
        public Guid SystemBanksGuid { get; set; }

       // [Required]
       // [Display(Name = "Branch")]
        public Guid BranchGuid { get; set; }

        //Amount
        [Required]
        [Display(Name = "Amount")]
        public decimal amount { get; set; }

        //Now acts as Bond Amount
        [Display(Name = "Bond Commision")]
        public decimal approvedAmount { get; set; }

        [Display(Name = "Bank Commision")]
        public decimal BankComm { get; set; }

        /// <summary>
        /// 9 = Pending,
        /// 10=paid
        /// 
        /// 11 = Approved One,
        /// 12 = Rejected One,
        /// 13 = Approved Checker,
        /// 14 = Rejected Checker,
        /// 5 = Deleted by Maker,
		/// 6 = Paid inFull
		/// 8 = Payment Failed
        /// 15 = client2Bank Ammended pending payment
        /// 16 = Amend Paid
        /// 17=ammend approved one
        /// 18 =ammend reject one
        /// 19=cheker approved
        /// 20=checker rejected
        /// 
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Status")]
        public int status { get; set; }
        /// <summary>
        /// Generated=200
        /// Edited=300
        /// </summary>
        public int BidBondDocStatus { get; set; }
        public bool ClientPreviewApproved { get; set; }
        public bool ClientPrinted { get; set; }
        public string QrCode { get; set; }
        public string BidBondPath { get; set; }
        [Required]
        [Display(Name = "KRA PIN")]
        public string PIN { get; set; }

        [Required]
        [Display(Name = "Purchaser")]
        public string Purchaser { get; set; }

        //Aproval Date ?
        [Display(Name = "Approval Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:MM\/dd\/yyyy}")]
        public DateTime? approvalDate { get; set; }

        // Bank Approval status
        // Comments
        [Display(Name = "Maker Comments")]
        [MaxLength(500)]
        public string comments { get; set; }

        [Required]
        [Display(Name = "I Agree to terms and Conditions ")]
        public bool AcceptTerms { get; set; }

        [Display(Name = "Terms")]
        public string terms { get; set; }

        [Display(Name = "Expire Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime expireDate { get; set; }

        [Required]
        [Display(Name = "Details")]
        [MaxLength(1500)]
        public string Details { get; set; }

        [Required]
        [Display(Name = "Action")]
        [MaxLength(500)]
        public string ActionCode { get; set; }

        [Required]
        [Display(Name = "Currency")]
        [MaxLength(25)]
        public string currency { get; set; }

       // [Required]
        [Display(Name = "Tender Period")]
        [MaxLength(25)]
        public string TenderPeriod { get; set; }
        [Display(Name = "Bid Bond Access Option")]
        [MaxLength(25)]
        public string PrintCode { get; set; }
        [Required]
        [Display(Name = "Period")]
       // [MaxLength(25)]
        public int Period { get; set; }

        [Required]
        [Display(Name = "Tender No")]
        [MaxLength(250)]
        public string tenderNo { get; set; }

        [Display(Name = "Start Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //[DisplayFormat(DataFormatString = @"{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime bondStartDate { get; set; }

        [Required]
        [Display(Name = "Tender Docs")]
        [MaxLength(800)]
        public string tenderDocs { get; set; }

        //Approved by
        [Display(Name = "Approved by")]
        public Guid approvedBy { get; set; }

        [Display(Name = "Checked by")]
        public Guid checkedBy { get; set; }

        [Display(Name = "Checker Comments")]
        [MaxLength(500)]
        public string checkerComments { get; set; }

        [Display(Name = "Checker Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:MM\/dd\/yyyy}")]
        public DateTime? checkerDate { get; set; }

        [Display(Name = "Core Banking Reference Number")]
        public string CoreBankingReferenceNumber { get; set; }

        public string PayRefrence { get; set; }
		public DateTime?  PayDate { get; set; }

		public tbSystemBanks tbSystemBanks { get; set; }
     

        // public tbBankBranches tbBankBranches { get; set; }
        //public tbIndivuduals tbIndivuduals { get; set; }
        //public tbCompanies tbCompanies { get; set; }
        public tbCurrencies tbCurrencies { get; set; }

        public virtual List<tbApplicationDocs> tbApplicationDocs { get; set; }
    }
}
