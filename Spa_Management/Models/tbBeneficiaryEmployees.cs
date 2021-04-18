using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbBeneficiaryEmployees
    {
        [Key]
        public Guid userGuid { get; set; }

        [Required]
        public Guid institutionGuid { get; set; }
        public Guid RoleId { get; set; }

        //[Required]
        [Display(Name = "Designation")]
        [MaxLength(50)]
        public string designation { get; set; }

        [Required]
        [Display(Name = "Surname")]
        [StringLength(25, ErrorMessage = "Surname cannot be longer than 25 characters or less than 1 Characters", MinimumLength = 1)]
        public string SirName { get; set; }

        [Required]

        [Display(Name = "First Name")]
        [StringLength(25, ErrorMessage = "First Name cannot be longer than 25 characters or less than 1 Characters", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(25, ErrorMessage = "First Name cannot be longer than 25 characters or less than 1 Characters", MinimumLength = 1)]
        public string MiddleName { get; set; }


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

        [Display(Name = "Nationality")]
        [StringLength(15, MinimumLength = 2)]
        public string NationCode { get; set; }

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

        /// <summary>
        /// 0 = Active
        /// 1 = In Active 
        /// </summary>
        public int status { get; set; }

        public DateTime regDate { get; set; }
        public tbBeneficiaries tbBeneficiaries { get; set; }

        public tbNationalities tbNationalities { get; set; }

    }
}
