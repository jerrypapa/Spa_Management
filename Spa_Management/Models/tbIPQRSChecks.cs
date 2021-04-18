using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbIPQRSChecks
    {
        [Key]
        public Guid ipqrsGuid { get; set; }

        [Required]
        public Guid indGuid { get; set; }


        [Display(Name ="Received Details")]
        public string inComeDetails { get; set; }

        /// <summary>
        /// 0 = Bad,
        /// 10 = Excellent
        /// </summary>
        [Display(Name = "Score")]
        public int score { get; set; }

        /// <summary>
        /// 0 = Pending,
        /// 1 = Verified,
        /// 2 = Details not Found
        /// </summary>
        public int status { get; set; }

        [Display(Name ="Date")]
        public DateTime date { get; set; }

        public tbIndivuduals tbIndivuduals { get; set; }
    }
}
