using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbIndivuduals
    {
        [Key]
        public Guid indGuid { get; set; }

        [Display(Name = "Suffix")]
        public string suffix { get; set; }

       // [Required]
        [Display(Name = "Surname")]
        [StringLength(25, ErrorMessage = "Surname cannot be longer than 25 characters or less than 1 Characters", MinimumLength = 1)]
        public string SirName { get; set; }

       // [Required]

        [Display(Name = "First Name")]
        [StringLength(25, ErrorMessage = "First Name cannot be longer than 25 characters or less than 1 Characters", MinimumLength = 1)]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [StringLength(25, ErrorMessage = "Last Name cannot be longer than 25 characters or less than 1 Characters", MinimumLength = 1)]
        public string LastName { get; set; }

        [NotMapped]
        public string Name
        {
            get { return string.Format("{0} {1} {2}", SirName, FirstName, LastName); }
        }

        [Required]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^[0-9*+]+$")]
        [StringLength(15, ErrorMessage = "Phone Number cannot be longer than 15 characters or less than 9 Characters", MinimumLength = 9)]
        public string contact { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [StringLength(100,ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string email { get; set; }

        //[Required]
        [Display(Name = "Gender")]
        [MaxLength(25)]
        public string gender { get; set; }

        //[Required]
        [Display(Name = "DOB")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}")]
        public DateTime dob { get; set; }

        //[Required]
        [Display(Name ="Nationality")]
        [StringLength(5, MinimumLength = 2)]
        public string NationCode { get; set; }

        [Required]
        [Display(Name = "ID Type")]
        public string idType { get; set; }

        [Required]
        [Display(Name = "ID NO")]
        [MaxLength(50,ErrorMessage ="ID NO cannot be longer than 50 characters")]
        public string idNumber { get; set; }

        //[Required]
        [Display(Name = "Marital Status")]
        public string maritalStatus { get; set; }

        [Display(Name = "Physical Location")]
        public string pysicalLoc { get; set; }

        [Display(Name = "Bank Code")]
        [MaxLength(50)]
        public string BankCode { get; set; }

        [Display(Name = "Branch Code")]
        [MaxLength(50)]
        public string branchCode { get; set; }

        [Display(Name = "A/C NO")]
        public string accNum { get; set; }

        [Display(Name = "Reg Date")]
        public DateTime regDate { get; set; }

       


        /// <summary>
        /// 0 = Active,
        /// 1 = discon
        /// </summary>
        [Required]
        public int status { get; set; }

        // Many Here
        public tbSuffixes tbSuffixes { get; set; }
        public tbIdTypes tbIdTypes { get; set; }
        public tbNationalities tbNationalities { get; set; }
        public tbMaritalStatus tbMaritalStatus { get; set; }
        public tbGender tbGender { get; set; }

        //public tbBanks tbBanks { get; set; }
        //public tbBranches tbBranches { get; set; }

        //Many There
        public virtual List<tbIPQRSChecks> tbIPQRSChecks { get; set; }
       // public virtual List<tbCRBChecks> tbCRBChecks { get; set; }
        //public virtual List<tbApplications> tbApplications { get; set; }
       // public virtual List<tbBeneficialies> tbBeneficialies { get; set; }
    }
}
