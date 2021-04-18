using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbBankBranches
    {
        [Key]
        public Guid BranchGuid { get; set; }

        [Required]
        public Guid SystemBanksGuid { get; set; }


        [Required]
        [Display(Name = "Branch Code")]
        public string branchCode { get; set; }

        [Required]
        [Display(Name = "Branch Name")]
        public string branchName { get; set; }

        [Display(Name = "Reg Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:dd/MM/yyyy}")]
        public DateTime regDate { get; set; }

        [Display(Name = "Physical Location")]
        [MaxLength(100)]
        public string physicalLoc { get; set; }

        [Required]
        [Display(Name = "Address")]
        [MaxLength(100)]
        public string adrress { get; set; }
        [Display(Name = "Bank's Collection Account")]
        public string BankCollectionAccount { get; set; }

        /// <summary>
        /// 0 = Active,
        /// 1 = Verified
        /// </summary>
        public int status { get; set; }

        public tbSystemBanks tbSystemBanks { get; set; }
    //    public virtual List<tbApplications> tbApplications { get; set; }

    }
}
