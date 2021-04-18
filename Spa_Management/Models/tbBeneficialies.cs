using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbBeneficialies
    {
        [Key]
        public Guid benGuid { get; set; }

        // [Required]
        //[]
        public Guid? indGuid { get; set; }

        public Guid compUserGuid { get; set; }
        public Guid adminUserGuid { get; set; }

        [Required]
        [Display(Name = "Beneficiary Name")]
       // [StringLength(100, ErrorMessage = "Name cannot be longer than 25 characters or less than 1 Characters", MinimumLength = 1)]
        public string SirName { get; set; }

        //[Required]
        [Display(Name = "First Name")]
       // [StringLength(25, ErrorMessage = "First Name cannot be longer than 25 characters or less than 1 Characters", MinimumLength = 1)]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        //[StringLength(25, ErrorMessage = "Last Name cannot be longer than 25 characters or less than 1 Characters", MinimumLength = 1)]
        public string LastName { get; set; }

        [NotMapped]
        public string Name
        {
            get { return string.Format("{0} {1} {2}", SirName, FirstName, LastName); }
        }

       // [Required]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^[0-9*+]+$")]
        [StringLength(15, ErrorMessage = "Phone Number cannot be longer than 15 characters or less than 9 Characters", MinimumLength = 9)]
        public string contact { get; set; }

       // [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Physical Location")]
        [MaxLength(100)]
        public string physicalLoc { get; set; }

        [Display(Name = "Address")]
        [MaxLength(100)]
        public string adrress { get; set; }

      //  public tbIndivuduals tbIndivuduals { get; set; }
    }
}
