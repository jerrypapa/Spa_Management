using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbCommisionShares
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid SystemBanksGuid { get; set; }


        [Display(Name = "From")]
        public decimal from { get; set; }

        [Display(Name = "To")]
        public decimal to { get; set; }

        [Display(Name = "% Comission")]
        public decimal perCom { get; set; }

        [Display(Name = "Fintech % Comission")]
        public decimal? FintechperCom { get; set; }

        [Display(Name = "Bank % Comission")]
        public decimal? BankperCom { get; set; }

        [Required]
        [Display(Name = "Currency")]
        [MaxLength(25)]
        public string currency { get; set; }

        [Required]
        [Display(Name = "Fintech Bank Account")]
        // [MaxLength(25)]
        public string FintechBankAccount { get; set; }

        [Required]
        [Display(Name = "Primary Bank Account")]
        // [MaxLength(25)]
        public string PrimaryBankAccount { get; set; }

        [Display(Name = "Fixed Commission")]
        public decimal FlatRate { get; set; }


        [Display(Name = "Quater")]
        public string period { get; set; }

        /// <summary>
        /// 0 = Active,
        /// 1 = Disc,
        /// </summary>
        [Display(Name = "Status")]
        public int status { get; set; }

        [Display(Name = "Bank")]
        public tbSystemBanks tbSystemBanks { get; set; }
    }
}
