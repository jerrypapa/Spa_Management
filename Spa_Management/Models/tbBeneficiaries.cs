using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbBeneficiaries
    {
        [Key]
        public Guid institutionGuid { get; set; }

        [Required]
        [Display(Name = "Registered By")]
        public string registeredBy { get; set; }

        [Required]
        [Display(Name = "Institution Name")]
        [MaxLength(250)]
        public string InstitutionName { get; set; }

        // [Required]
        [EmailAddress]
        [Display(Name = "Institution Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Physical Address")]
        public string pysicalLoc { get; set; }

        [Required]
        [Display(Name = "Postal Address")]
        public string postalAddress { get; set; }

        //[Required]
        //[Display(Name = "Pin Number")]
        //public string PinNo { get; set; }

        //[Required]
        //[Display(Name = "Registration Number")]
        //public string RegCertNo { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        [RegularExpression(@"^[0-9*+]+$")]
        [StringLength(15, ErrorMessage = "Phone Number cannot be longer than 15 characters or less than 9 Characters", MinimumLength = 9)]
        public string contact { get; set; }

        //[Required]
        //[Display(Name = "Company Documents")]
        //[MaxLength(800)]
        //public string CompanyDocs { get; set; }
        [Display(Name = "Reg Date")]
        public DateTime regDate { get; set; }

        /// <summary>
        /// 0 = Unverified
        /// 1 = Verified
        /// 2 = Rejected
        /// </summary>
        public int status { get; set; }


        //public tbBanks tbBanks { get; set; }
        //public tbBranches tbBranches { get; set; }
        //Many There
        //public virtual List<tbApplications> tbApplications { get; set; }
        public virtual List<tbBeneficiaryEmployees> TbBeneficiaryEmployees { get; set; }
    }
}
