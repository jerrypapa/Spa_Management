using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbFeedBacks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name ="Name")]
        public string name { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [MaxLength(15)]
        [Display(Name = "Phone No")]
        [RegularExpression(@"^[0-9*+]+$")]
        [StringLength(15, ErrorMessage = "Phone Number cannot be longer than 15 characters or less than 9 Characters", MinimumLength = 9)]
        public string phone { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Mesaage")]
        public string message { get; set; }

        [Display(Name ="Time")]
        [DataType(DataType.Date)]
        public  DateTime time { get; set; }

        /// <summary>
        /// 0 = Sent,
        /// 1 = Failed
        /// </summary>
        [Display(Name = "Status")]
        [Required]
        public int status { get; set; }
    }
}
