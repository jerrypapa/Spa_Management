using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbDocTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        [MaxLength(100)]
        public string Extensions { get; set; }

        /// <summary>
        /// 0 = Active,
        /// 1 = In active
        /// </summary>
        public int status { get; set; }

        public virtual List<tbDocUploadReq> tbDocUploadReq { get; set; }
    }
}
