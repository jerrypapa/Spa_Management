using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbSysConfigs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Code")]
        [MaxLength(500)]
        public string code { get; set; }
        [Required]
        [MaxLength(500)]
        public string Value { get; set; }

        /// <summary>
        /// 0 = Active,
        /// 1 = In Active
        /// </summary>
        [Required]
        public int status { get; set; }
    }
}
