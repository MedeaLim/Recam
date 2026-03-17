using Microsoft.AspNetCore.Identity;
using Recam.Models.Entities;

namespace Recam.API.Data;

public static class UserSeeder
{
    public static async Task SeedUsersAsync(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        // 1️⃣ 确保角色存在（双保险）
        string[] roles = { "Admin", "Agent" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // 2️⃣ Seed Admin
        var adminEmail = "admin@recam.com";

        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            var newAdmin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(newAdmin, "Admin123123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(newAdmin, "Admin");
            }
        }

        // 3️⃣ Seed Agent
        var agentEmail = "agent@recam.com";

        var agentUser = await userManager.FindByEmailAsync(agentEmail);

        if (agentUser == null)
        {
            var newAgent = new ApplicationUser
            {
                UserName = agentEmail,
                Email = agentEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(newAgent, "Agent123123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(newAgent, "Agent");
            }
        }
    }
}