using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbNotifications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string systemID { get; set; }

        /// <summary>
        /// 0 = General,
        /// 1 = Applications,
        /// 2 = System (pwd),
        /// 3 = Fails,
        /// 4 = CRB
        /// </summary>
        [Required]
        [Display(Name ="Type")]
        public int type { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string message { get; set; }
        
        [Display(Name = "Date")]
        public DateTime logDate { get; set; }

        /// <summary>
        /// 0 = New,
        /// 1 = Read
        /// </summary>
        [Display(Name = "Status")]
        public int status { get; set; }
    }
}
