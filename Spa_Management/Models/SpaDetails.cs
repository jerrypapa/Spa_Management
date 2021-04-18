using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class SpaDetails
    {
            [Key]
            public Guid spaGuid { get; set; }

            [Required]
            [Display(Name = "Registered By")]
            public string registeredBy { get; set; }

            [Required]
            [Display(Name = "Business Name")]
            [MaxLength(250)]
            public string spaName { get; set; }

            // [Required]
            [EmailAddress]
            [Display(Name = "Business Email")]
            public string email { get; set; }

            [Required]
            [Display(Name = "Physical Address")]
            public string pysicalLoc { get; set; }

            [Required]
            [Display(Name = "Postal Address")]
            public string postalAddress { get; set; }

            public string PostalCode { get; set; }

            [Required]
            [Display(Name = "KRA Pin Number")]
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
            [Display(Name = "Inc Num")]
            public string incNum { get; set; }

            [Display(Name = "Reg Date")]
            public DateTime regDate { get; set; }

            /// <summary>
            /// 0 = Unverified
            /// 1 = Verified
            /// 2 = Rejected
            /// </summary>
            public int status { get; set; }

            public virtual List<SpaUsers> SpaUsers { get; set; }
            public virtual List<SpaRoles> SpaRoles { get; set; }
        public virtual List<Appointments> Appointments { get; set; }
        public virtual List<SpaServices> SpaServices { get; set; }

        public SpaDetails() { }
        public SpaDetails(string registeredBy,string spaName,string email,string pysicalLoc,string postalAddress,string PostalCode,string PinNo,string RegCertNo,string contact, string incNum)
        {
            this.spaGuid = Guid.NewGuid();
            this.status = 0;
            this.registeredBy = !(string.IsNullOrWhiteSpace(registeredBy)) ? registeredBy : "";
            this.spaName = !(string.IsNullOrWhiteSpace(spaName)) ? spaName : throw new ArgumentNullException(nameof(spaName));
            this.pysicalLoc = !(string.IsNullOrWhiteSpace(pysicalLoc)) ? pysicalLoc : throw new ArgumentNullException(nameof(pysicalLoc));
            this.postalAddress = !(string.IsNullOrWhiteSpace(postalAddress)) ? postalAddress : throw new ArgumentNullException(nameof(postalAddress));
            this.PostalCode = !(string.IsNullOrWhiteSpace(PostalCode)) ? PostalCode : throw new ArgumentNullException(nameof(PostalCode));
            this.RegCertNo = !(string.IsNullOrWhiteSpace(RegCertNo)) ? RegCertNo : throw new ArgumentNullException(nameof(RegCertNo));
            this.contact = !(string.IsNullOrWhiteSpace(contact)) ? contact : throw new ArgumentNullException(nameof(contact));
            this.PinNo = !(string.IsNullOrWhiteSpace(PinNo)) ? PinNo : throw new ArgumentNullException(nameof(PinNo));
            this.incNum = !(string.IsNullOrWhiteSpace(incNum)) ? incNum : "";
            this.regDate = DateTime.Now;
            this.email = !(string.IsNullOrWhiteSpace(email)) ? email : "";
        }
        public static SpaDetails AddNewSpa(string registeredBy, string spaName, string email, string pysicalLoc, string postalAddress, string PostalCode, string PinNo, string RegCertNo, string contact, string incNum)
        {
            return new SpaDetails( registeredBy,  spaName,  email,  pysicalLoc,  postalAddress,  PostalCode,  PinNo,  RegCertNo,  contact,  incNum);
        }
    }
}
