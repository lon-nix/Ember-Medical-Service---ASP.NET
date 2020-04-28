using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_Medical_Service
{
    public static class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManage)
        {
            SeedRoles(roleManage);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            var users = userManager.GetUsersInRoleAsync("Staff").Result;
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@lonnix",
                    Email = "admin@lonnix"
                };
                var result = userManager.CreateAsync(user, "P@ssword1").Result;


                if (result.Succeeded)
                {

                    userManager.AddToRoleAsync(user, "Administrator").Wait();


                }
            }
        }

          private static void SeedRoles(RoleManager<IdentityRole> roleManage)
        {
            if (!roleManage.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                var result = roleManage.CreateAsync(role).Result;
            }
            if (!roleManage.RoleExistsAsync("Staff").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Staff"
                };
                var result = roleManage.CreateAsync(role).Result;

            }

        }

    }
}
