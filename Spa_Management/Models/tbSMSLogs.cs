using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbSMSLogs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name ="Phone")]
        [Required]
        [StringLength(15)]
        public string toPhone { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string message { get; set; }

        [Display(Name = "Date")]
        public DateTime sentDate { get; set; }

        /// <summary>
        /// 1 = Sent,
        /// 2 = Failed
        /// </summary>
        public int status { get; set; }
    }
}
