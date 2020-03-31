using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletApp.Data;
using WalletApp.Data.Entities;

namespace WalletApp.Helpers
{
    public class InitialData
    {
        public static async Task Init(IServiceProvider service)
        {
            
            var context = service.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();

            var roleManager = service.GetRequiredService<RoleManager<IdentityRole<int>>>();

            const string requiredRoleName = "User";
            const string requiredUserName1 = "User1@project.com";
            const string requiredUserName2 = "User2@project.com";


            if (!roleManager.Roles.Any())
            {
                var role = new IdentityRole<int>
                {
                    Name = requiredRoleName
                };
                var result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    return;
                }

            }

            if (!userManager.Users.Any(x => x.UserName.Equals(requiredUserName1)))
            {
                var user = new ApplicationUser
                {
                    UserName = requiredUserName1,
                    Email = requiredUserName1,
                    BirthDate = DateTime.Now.AddYears(-18),
                    PhoneNumber = "12345678",
                    FirstName = "User1",
                    LastName = "User",
                    TotalAmount=1000
                };
                var userResult = await userManager.CreateAsync(user, "User1777#");
                var roleResult = await userManager.AddToRoleAsync(user, requiredRoleName);

                if (!userResult.Succeeded||!roleResult.Succeeded)
                {
                    return;
                }
            }


            if (!userManager.Users.Any(x => x.UserName.Equals(requiredUserName2)))
            {
                var user = new ApplicationUser
                {
                    UserName = requiredUserName2,
                    Email = requiredUserName2,
                    BirthDate = DateTime.Now.AddYears(-19),
                    PhoneNumber = "12345678",
                    FirstName = "User2",
                    LastName = "User",
                    TotalAmount = 1000

                };
                var userResult = await userManager.CreateAsync(user, "User2777#");
                var roleResult = await userManager.AddToRoleAsync(user, requiredRoleName);

                if (!userResult.Succeeded || !roleResult.Succeeded)
                {
                    return;
                }
            }

        }
    }
}
