using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbPayMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid profGuid { get; set; }

        [Display(Name ="Card Number")]
        public long cardNumber { get; set; }

        [Range(1,12)]
        public int expireMonth { get; set; }

        public int expireYear { get; set; }

        [Display(Name = "Card Owner")]
        public string nameOnCard { get; set; }

        /// <summary>
        /// 0 = Active,
        /// 1 = Disc
        /// </summary>
        [Required]
        [Display(Name ="Status")]
        public int status { get; set; }

        public tbUserProfiles tbUserProfiles { get; set; }
    }
}
