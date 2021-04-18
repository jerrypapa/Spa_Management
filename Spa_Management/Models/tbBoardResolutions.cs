using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbBoardResolutions
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        [Required]
        [MaxLength(210)]
        public string docPath { get; set; }
    }
}
