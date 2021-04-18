using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbCRBChecks
    {
        [Key]
        public Guid CRBGuid { get; set; }

        //[Required]
        public Guid indGuid { get; set; }

        public Guid compGuid { get; set; }

        [Display(Name = "Received Details")]
        public string inComeDetails { get; set; }

        [Required]
        /// <summary>
        /// 0 = Bad,
        /// 10 = Excellent
        /// </summary>
        [Display(Name = "Score")]
        public int score { get; set; }

        public string details { get; set; }


        /// <summary>
        /// 0 = Pending,
        /// 1 = Verified,
        /// 2 = Details not Found
        /// </summary>
        public int status { get; set; }

        [Display(Name = "Date")]
        public DateTime date { get; set; }

        //Linked person to the company details

        [Display(Name = "Individual Name")]
        public string FullName { get; set; }

        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }

        [Display(Name = "ID Type")]
        public string IDNumberType { get; set; }

        [Display(Name = "Relation Type")]
        public string TypeOfRelation { get; set; }

        [Display(Name = "ValidFrom")]
        public DateTime ValidFrom { get; set; }
    }
}
