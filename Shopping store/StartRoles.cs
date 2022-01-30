using Microsoft.AspNetCore.Identity;
using Shopping_store.Models;
using System.Threading.Tasks;

namespace Shopping_store
{
    public class StartRoles
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync("Admin") == null)
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            if (await roleManager.FindByNameAsync("Buyer") == null)
                await roleManager.CreateAsync(new IdentityRole("Buyer"));

            string adminEmail = "admin@gmail.com";
            string password = "Secret_Password404";

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User adminUser = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(adminUser, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
