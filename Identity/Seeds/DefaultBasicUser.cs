﻿using Application.Enums;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //seed Default Admin User
            var defaultUser = new ApplicationUser
            {
                UserName = "userBasic",
                Email = "userBasic@mail.com",
                Nombre = "Pedro",
                Apellido = "Ossa",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Basic$123");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }
            }

        }
    }
}
