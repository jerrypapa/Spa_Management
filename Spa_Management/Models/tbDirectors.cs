using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbDirectors
    {
        public Guid Id { get; set; }
        [Display(Name = "Company")]
        public Guid CompanyId { get; set; }
        public bool OtpVerified { get; set; }
        public bool Verified { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        [Display(Name = "MiddleName")]
        public string MiddleName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }
        [Display(Name = "Id Number")]
        public string IdNumber { get; set; }
        public Guid Maker { get; set; }

        [Display(Name = "Checked by")]
        public Guid Checker { get; set; }

        [Display(Name = "Comments")]
        [MaxLength(500)]
        public string CheckerComments { get; set; }

        [Display(Name = "Checker Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:MM\/dd\/yyyy}")]
        public DateTime? checkerDate { get; set; }
       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:MM\/dd\/yyyy}")]
        [Display(Name = "DOB")]
        public DateTime Dob { get; set; }
        [Display(Name = "ID Type")]
        public string IdType { get; set; }
        //[Required]
        [Display(Name = "Nationality")]
        [StringLength(15, MinimumLength = 2)]
        public string NationCode { get; set; }
        //  public tbIndivuduals tbIndivuduals { get; set; }

        public tbDirectors() { }
        public tbDirectors(string fname,string lname) {
            Id = Guid.NewGuid();
            FirstName = fname;

        }
        public static tbDirectors AddDirector()
        {
            return new tbDirectors();
        }
    }
}
