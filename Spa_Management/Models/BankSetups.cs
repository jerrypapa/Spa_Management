using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class BankSetups
    {
        public Guid Id { get; set; }
        public Guid BankId { get; set; }
        [Required]
        [Display(Name = "LetterHead")]
        [MaxLength(800)]
        public string letterHead { get; set; }

        [Required]
        [Display(Name = "Signature")]
        [MaxLength(800)]
        public string Signature { get; set; }

        [Required]
        [Display(Name = "Logo")]
        [MaxLength(800)]
        public string Logo { get; set; }

        [Required]
        [Display(Name = "Stamp")]
        [MaxLength(800)]
        public string Stamp { get; set; }
        public int Status { get; set; }
    }
}
