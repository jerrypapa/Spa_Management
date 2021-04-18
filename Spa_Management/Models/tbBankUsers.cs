using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbBankUsers
    {
        [Key]
        public Guid bankUserGuid { get; set; }

        [Required]
        public Guid SystemBanksGuid { get; set; }

        [Required]
        [Display(Name = "Surname")]
        [StringLength(25, ErrorMessage = "Surname cannot be longer than 25 characters or less than 1 Characters", MinimumLength = 1)]
        public string SirName { get; set; }

        [Required]

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
        [Display(Name = "Email")]
        public string email { get; set; }

        //[Required]
        [Display(Name = "Gender")]
        [MaxLength(25)]
        public string gender { get; set; }

        //[Required]
        [Display(Name = "DOB")]
        public DateTime dob { get; set; }

        //[Required]
        [Display(Name = "ID Type")]
        public string idType { get; set; }

        [Required]
        [Display(Name = "ID NO")]
        [MaxLength(50, ErrorMessage = "ID NO cannot be longer than 50 characters")]
        public string idNumber { get; set; }

        [Display(Name = "Reg Date")]
        public DateTime regDate { get; set; }
        /// <summary>
        /// 0 = Active/ Checked,
        /// 1 = Discontinued,
        /// 2 = Added,
        /// 3 = Checker Rejected
        /// </summary>
        [Required]
        public int status { get; set; }

        [Display(Name = "Added by")]
        public Guid addedBy { get; set; }

        [Display(Name = "Checked by")]
        public Guid checkedBy { get; set; }

        [Display(Name = "Comments")]
        [MaxLength(500)]
        public string checkerComments { get; set; }

        [Display(Name = "Checker Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:MM\/dd\/yyyy}")]
        public DateTime? checkerDate { get; set; }

        //public tbSuffixes tbSuffixes { get; set; }
        //public tbIdTypes tbIdTypes { get; set; }
        public tbNationalities tbNationalities { get; set; }
        //public tbMaritalStatus tbMaritalStatus { get; set; }
        //public tbGender tbGender { get; set; }

        public tbSystemBanks tbSystemBanks { get; set; }

        [Display(Name = "Nationality")]
        [StringLength(5, MinimumLength = 2)]
        public string NationCode { get; set; }

        [Display(Name = "Marital Status")]
        public string maritalStatus { get; set; }

        [Display(Name = "Physical Location")]
        public string pysicalLoc { get; set; }
        public Guid RoleId { get; set; }
    }
}
