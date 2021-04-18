using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbNationalities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        [StringLength(5, MinimumLength = 2)]
        public string NationCode { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        public virtual List<tbIndivuduals> tbIndivuduals { get; set; }
    }
}
