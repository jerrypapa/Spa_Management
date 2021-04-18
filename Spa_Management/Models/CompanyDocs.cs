using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class CompanyDocs
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid ApplicantId { get; set; }
        public int Status { get; set; }
        [Required]
        [Display(Name = "BoardResolution (.pdf)")]
        [MaxLength(800)]
        public string BoardResolution { get; set; }

        [Required]
        [Display(Name = "PinCertificate (.pdf) ")]
        [MaxLength(800)]
        public string PinCertificate { get; set; }

        [Required]
        [Display(Name = "RegistrationCertificate (.pdf)")]
        [MaxLength(800)]
        public string RegistrationCertificate { get; set; }
        [Display(Name = "Feedback Comment")]
        public string AdminComments { get; set; }
        [Required]
        [Display(Name = "Cr12 (.Pdf)")]
        [MaxLength(800)]
        public string Cr12 { get; set; }
        public bool Verified { get; set; }
    }
}
