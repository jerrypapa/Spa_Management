using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbCompanies
    {
        [Key]
        public Guid compGuid { get; set; }

        [Required]
        [Display(Name = "Registered By")]
        public string registeredBy { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        [MaxLength(250)]
        public string compName { get; set; }       

       // [Required]
        [EmailAddress]
        [Display(Name = "Company Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Physical Address")]
        public string pysicalLoc { get; set; }

        [Required]
        [Display(Name = "Postal Address")]
        public string postalAddress { get; set; }

        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Pin Number")]
        public string PinNo { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        public string RegCertNo { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        [RegularExpression(@"^[0-9*+]+$")]
        [StringLength(15, ErrorMessage = "Phone Number cannot be longer than 15 characters or less than 9 Characters", MinimumLength = 9)]
        public string contact { get; set; }

        //[Required]
        //[Display(Name = "Company Documents")]
        //[MaxLength(800)]
        //public string CompanyDocs { get; set; }


        [Display(Name = "Inc Date")]
        public DateTime? incDate { get; set; }

        //[Required]
        [Display(Name = "Inc Num")]
        public string incNum { get; set; }

        [Display(Name = "Reg Date")]
        public DateTime regDate { get; set; }

        [Display(Name = "Bank Code")]
        [MaxLength(50)]
        public string BankCode { get; set; }

        [Display(Name = "Branch Code")]
        [MaxLength(50)]
        public string branchCode { get; set; }

        [Display(Name = "A/C NO")]
        public string accNum { get; set; }

        public bool FirstTimeUse { get; set; }


        /// <summary>
        /// 0 = Unverified
        /// 1 = Verified
        /// 2 = Rejected
        /// 4=setup Director or users
        /// 5=Documents Uploaded
        /// 6=Directors Verified
        /// 7=Documents Verified
        /// 8=Crb Verified
        /// 9=Fully Verified
        /// 
        /// 
        /// </summary>
        public int status { get; set; }


        //public tbBanks tbBanks { get; set; }
        //public tbBranches tbBranches { get; set; }
        //Many There
        //public virtual List<tbApplications> tbApplications { get; set; }
        public virtual List<tbCompanyUsers> tbCompanyUsers { get; set; }

        //public virtual List<tbCRBChecks> tbCRBChecks { get; set; }
    }
}
