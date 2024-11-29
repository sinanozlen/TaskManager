using Microsoft.AspNetCore.Identity;

public class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        string[] roleNames = { "Admin", "User", "Guest" };

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var user = await userManager.FindByNameAsync("admin@admin.com");
        if (user == null)
        {
            user = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com", FullName = "Admin User" };
            await userManager.CreateAsync(user, "Admin123!");
        }

        await userManager.AddToRoleAsync(user, "Admin");
    }
}
