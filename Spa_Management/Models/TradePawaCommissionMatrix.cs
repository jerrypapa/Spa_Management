using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class TradePawaCommissionMatrix
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MakerId { get; set; }
        public Guid CheckerId { get; set; }

        [Display(Name = "From")]
        public decimal from { get; set; }

        [Display(Name = "To")]
        public decimal to { get; set; }

        [Display(Name = "% Comission")]
        public decimal perCom { get; set; }

        [Required]
        [Display(Name = "Currency")]
        [MaxLength(25)]
        public string currency { get; set; }

        [Display(Name = "Fixed Commission")]
        public decimal FlatRate { get; set; }


        [Display(Name = "Quater")]
        public string period { get; set; }

        /// <summary>
        /// 0 = Active,
        /// 1 = Disc,
        /// </summary>
        [Display(Name = "Status")]
        public int status { get; set; }
    }
}
