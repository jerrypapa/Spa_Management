using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class SpaUsers
    {
        [Key]
        public Guid spaUserGuid { get; set; }

        [Required]
        public Guid spaGuid { get; set; }


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

       // [NotMapped]
        public string FullNames
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
        [Display(Name = "DOB")]
        public DateTime dob { get; set; }

        //[Required]
        [Display(Name = "ID Type")]
        public string idType { get; set; }

        [Required]
        [Display(Name = "ID NO")]
        [MaxLength(50, ErrorMessage = "ID NO cannot be longer than 50 characters")]
        public string idNumber { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string spaRolesId { get; set; }
        public SpaRoles spaRoles{ get; set; }

        /// <summary>
        /// 0 = Active
        /// 1 = In Active 
        /// </summary>
        public int status { get; set; }

        public DateTime regDate { get; set; }

        public SpaDetails SpaDetails { get; set; }
        public virtual List<EmployeePay> EmployeePays { get; set; }

        //[Required]
        [Display(Name = "Physical Address")]
        public string pysicalLoc { get; set; }

        public SpaUsers() { }
        public SpaUsers(Guid spaGuid,string SirName,string FirstName,string MiddleName,string LastName,string contact,string email,DateTime dob,string idType,string idNumber,string pysicalLoc,string FullNames = "")
        {
            this.spaUserGuid = Guid.NewGuid();
            this.spaGuid =!(string.IsNullOrEmpty(spaGuid.ToString()))? spaGuid : throw new ArgumentNullException(nameof(spaGuid));
            this.SirName = !(string.IsNullOrWhiteSpace(SirName)) ? SirName : "";
            this.FirstName = !(string.IsNullOrWhiteSpace(FirstName)) ? FirstName : throw new ArgumentNullException(nameof(FirstName));
            this.MiddleName = !(string.IsNullOrWhiteSpace(MiddleName)) ? MiddleName : "";
            this.LastName = !(string.IsNullOrWhiteSpace(LastName)) ? LastName : throw new ArgumentNullException(nameof(LastName));
            FullNames = string.Format("{0} {1} {2}", SirName, FirstName, LastName);
            this.contact = !(string.IsNullOrWhiteSpace(contact)) ? contact : throw new ArgumentNullException(nameof(contact));
            this.email = !(string.IsNullOrWhiteSpace(email)) ? email : throw new ArgumentNullException(nameof(email));
            this.idType = !(string.IsNullOrWhiteSpace(idType)) ? idType : throw new ArgumentNullException(nameof(idType));
            this.idNumber = !(string.IsNullOrWhiteSpace(idNumber)) ? idNumber : throw new ArgumentNullException(nameof(idNumber));
            this.pysicalLoc = !(string.IsNullOrWhiteSpace(pysicalLoc)) ? pysicalLoc : "NoAddress";
            this.dob = dob;
            this.status = 0;
            this.regDate = DateTime.UtcNow;
        }

        public static SpaUsers AddNewSpaUser( Guid spaGuid, string SirName, string FirstName, string MiddleName, string LastName, string contact, string email, DateTime dob, string idType, string idNumber, string pysicalLoc, string FullNames = "")
        {
            return new SpaUsers(spaGuid,  SirName,  FirstName,  MiddleName,  LastName,  contact,  email,  dob,  idType,  idNumber,  pysicalLoc,  FullNames = "");
        }

    }
}
