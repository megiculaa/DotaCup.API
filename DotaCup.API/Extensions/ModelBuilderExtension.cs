using DotaCup.API.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotaCup.API.Extensions;

public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder builder)
    {
        List<IdentityRole> roles = new List<IdentityRole>()
        {
            new IdentityRole {
                    Name = Enums.Roles.Admin.ToString(),
                    NormalizedName = Enums.Roles.Admin.ToString().ToUpper()
            },
            new IdentityRole {
                    Name = Enums.Roles.User.ToString(),
                    NormalizedName = Enums.Roles.User.ToString().ToUpper()
            },
        };

        builder.Entity<IdentityRole>().HasData(roles);

        List<ApplicationUser> users = new List<ApplicationUser>()
            {
                new ApplicationUser
                {
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                },
                new ApplicationUser
                {
                    UserName = "User",
                    NormalizedUserName = "USER",
                    Email = "user@gmail.com",
                    NormalizedEmail = "USER@GMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                }
            };

        var passwordHasher = new PasswordHasher<ApplicationUser>();
        users[0].PasswordHash = passwordHasher.HashPassword(users[0], "vg7oJlYR2$");
        users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Io4CmmS03$");

        builder.Entity<ApplicationUser>().HasData(users);

        List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

        foreach (var item in roles)
        {
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = item.Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = item.Id
            });
        }

        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
    }
}
