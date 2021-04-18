using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbMaritalStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

     
        [Required]
        [Display(Name = "Marital Status")]
        [MaxLength(25,ErrorMessage ="Marital Status cannot be more than 25 characters")]
        public string maritalStatus { get; set; }

        public virtual List<tbIndivuduals> tbIndivuduals { get; set; }
    }
}
