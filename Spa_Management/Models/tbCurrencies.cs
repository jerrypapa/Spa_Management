using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbCurrencies

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
          
        [Required]
        [Display(Name = "Currency")]
        [MaxLength(25)]
        public string currency { get; set; }


        public virtual List<tbApplications> tbApplications { get; set; }
        //public virtual List<tbComMatrices> tbComMatrices { get; set; }
    }
}
