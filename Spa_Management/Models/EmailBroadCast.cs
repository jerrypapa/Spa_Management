using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class EmailBroadCast
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public bool Sent { get; set; }
        public string RecipientEmail { get; set; }
        public Guid ApplicationId { get; set; }
        public DateTime DateLogged { get; set; }
        public DateTime DateSent { get; set; }
    }
}
