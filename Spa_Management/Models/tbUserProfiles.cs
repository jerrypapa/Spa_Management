using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbUserProfiles
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid profGuid { get; set; }

        [Required]
        public string systemID { get; set; }

        /// <summary>
        /// 0 = Master,
        /// 1 = Individual,
        /// 2 = Bank,
        /// 3 = Company
        /// </summary>
        [Required]
        public int userType { get; set; }

        public Guid userGuid { get; set; }

        public string photoPath { get; set; }

        /// <summary>
        /// 0 = Email,
        /// 1 = SMS,
        /// 2 = Both
        /// </summary>
        public int preferedCommMethod { get; set; }

        /// <summary>
        /// 0 = Active,
        /// 1 = Disc
        /// </summary>
        [Required]
        [Display(Name = "Status")]
        public int status { get; set; }

        public virtual List<tbPayMaster> tbPayMaster { get; set; }
        public virtual List<tbPayPesaLink> tbPayPesaLink { get; set; }
    }


}
