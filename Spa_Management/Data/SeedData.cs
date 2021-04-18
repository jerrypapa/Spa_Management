using Spa_Management.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //if (context.TbSuffixes.Any())
                //{
                //    return;   // DB has been seeded
                //}

                string[] roles = new string[] { "MasterAdmin", "Individual","CompanyAdmin", "CompanyUser", "BankAdmin", "BankUser" };
                foreach (string role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        var _role = new IdentityRole();
                        _role.Name = role;
                        _role.NormalizedName = role.ToUpper();
                        roleStore.CreateAsync(_role);
                    }
                }
                
                
                context.TbSuffixes.AddRange(
                    new tbSuffixes { suffix = "Mr" }, new tbSuffixes { suffix = "Mrs" }, new tbSuffixes { suffix = "Miss" },
                    new tbSuffixes { suffix = "Dr" }, new tbSuffixes { suffix = "Eng" }, new tbSuffixes { suffix = "Pastor" },
                    new tbSuffixes { suffix = "Prof" }
                    );
               
                context.SaveChanges();
            }
        }
    }
}
