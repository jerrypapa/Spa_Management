using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbSystemBanks
    {
        [Key]
        public Guid SystemBanksGuid { get; set; }

        [Required]
        [Display(Name = "Bank Code")]
        public string bankCode { get; set; }

        [Required]
        [Display(Name = "Bank Name")]
        public string bankName { get; set; }

        [Display(Name = "Reg Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:dd/MM/yyyy}")]
        public DateTime regDate { get; set; }

        [Required]
        [Display(Name = "Allow Client BidBond Generation")]
        public string AllowAutoGene { get; set; }


        [Required]
        [Display(Name = "Processing Days")]
        public int BondProcessDays { get; set; }
        [Required]
        [Display(Name = "Maximum Securing Limit")]
        public decimal MaximumSecurityLimit { get; set; }

        [Required]
        [Display(Name = "Overal Securing Limit")]
        public decimal OveralSecuringLimit { get; set; }
        [Display(Name = "Limit Balance")]
        public decimal LimitBalance { get; set; }
        /// <summary>
        /// 0 = Active,
        /// 1 = Verified
        /// </summary>
        public int status { get; set; }



        public virtual List<tbApplications> tbApplications { get; set; }
        public virtual List<tbComMatrices> tbComMatrices { get; set; }
        public virtual List<BankAmmendmentMatrices> BankAmmendmentMatrices { get; set; }

        public virtual List<tbBankUsers> tbBankUsers { get; set; }


        public virtual List<tbDocUploadReq> tbDocUploadReq { get; set; }

        public virtual List<tbBankBranches> tbBankBranches { get; set; }
    }
}
