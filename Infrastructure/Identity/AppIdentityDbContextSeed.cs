using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager){
            if(!userManager.Users.Any()){
                var user = new AppUser{
                    DisplayName = "girogi",
                    Email = "giorgi@gmail.com",
                    UserName = "giorgi",
                    Address = new Address{
                        FirstName = "Gio",
                        LastName = "Chikovani",
                        Street = "55 of fighters",
                        City = "Tbilisi",
                        Country = "Georgia",
                        ZipCode = "0182"
                    }
                };
                await userManager.CreateAsync(user,"GioChkviani_1!");
            }
        }
    }
}