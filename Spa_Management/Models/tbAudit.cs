using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string userID { get; set; }

        [Required]
        [StringLength(50)]
        public string action { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public string json { get; set; }

        [StringLength(100)]
        public string page { get; set; }

        [Display(Name = "Time")]
        [Required]
        public DateTime actionTime { get; set; }

        [Display(Name = "Session Id")]
        public string sessionId { get; set; }
    }
}

