using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbDesignations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
              
        [Required]
        [Display(Name = "Designation")]
        [MaxLength(50)]
        public string designation { get; set; }

        public virtual List<tbCompanyUsers> tbCompanyUsers { get; set; }
    }
}
