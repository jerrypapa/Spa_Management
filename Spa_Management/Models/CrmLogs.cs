using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class CrmLogs
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Issue Description")]
        [MaxLength(4500)]
        public string Description { get; set; }
        public string CategoryCode { get; set; }
        public DateTime DateLogged { get; set; }
        public DateTime DateResolved { get; set; }
        /// <summary>
        /// 0 Active
        /// 1 Closed
        /// </summary>
        public int Status { get; set; }
        public Guid UserId { get; set; }
        public Guid EntityId { get; set; }
        //[Required]
        //[Display(Name = "User Email")]
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string EntityCategoryCode { get; set; }
    }
    public class CrmIssueCategory
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
    }
}
