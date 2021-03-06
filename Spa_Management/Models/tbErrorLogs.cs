using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbErrorLogs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Session Id")]
        public string sessionId { get; set; }

        [Required]
        [StringLength(50)]
        public string action { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public string json { get; set; }

        [Required]
        public DateTime OpDate { get; set; }

        [Required]
        public string errorMessage { get; set; }

        public string innerExemption { get; set; }

        public string modelValidation { get; set; }

        /// <summary>
        /// 0 = Unattended
        /// 1 = Attended
        /// </summary>
        [Required]
        public int attStatus { get; set; }
    }
}
