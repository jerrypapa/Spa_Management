using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbDocUploadReq
    {
        [Key]
        [Required]
        public Guid docReqGuid { get; set; }

        [Required]
        [Display(Name = "Bank")]
        public Guid SystemBanksGuid { get; set; }

        [Required]
        [Display(Name ="Doc Name")]
        [MaxLength(50)]
        public string docName { get; set; }

        /// <summary>
        /// 0 = Active,
        /// 1 = Optional,
        /// 2 = Madatory,
        /// 3 = Deleted
        /// </summary>
        [Required]
        public int Status { get; set; }

        public tbSystemBanks tbSystemBanks { get; set; }

        public tbDocTypes DocTypes { get; set; }

        //public virtual List<tbApplicationDocs> tbApplicationDocs { get; set; }
    }
}
