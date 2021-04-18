using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbGender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       
        [Required]
        [Display(Name = "Gender")]
        [MaxLength(25)]
        public string gender { get; set; }

        public virtual List<tbIndivuduals> tbIndivuduals { get; set; }
    }
}
