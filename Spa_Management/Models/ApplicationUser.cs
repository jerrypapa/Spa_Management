using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Spa_Management.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        public Guid indGuid { get; set; }
        public Guid compUserGuid { get; set; }
        public Guid bankUserGuid { get; set; }
        public Guid spaUserGuid { get; set; }
        public Guid userGuid { get; set; }
    }
}
