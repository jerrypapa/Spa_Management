using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbOtpVerify
    {
        [Key]
        public Guid Id { get; set; }
        public string Otp { get; set; }
        public DateTime TimeLogged { get; set; }
        public bool Used { get; set; }
        public Guid UserId { get; set; }
    }
}
