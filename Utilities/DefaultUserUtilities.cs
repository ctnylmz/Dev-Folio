using Microsoft.AspNetCore.Identity;

namespace Dev_Folio.Utilities
{
    public class DefaultUserUtilities
    {
        public static async Task CreateUser(UserManager<IdentityUser> userManager)
        {
            var Email = "admin@gmail.com";

            if (userManager.FindByEmailAsync(Email).Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = Email,
                    Email = Email,
                    PhoneNumber = Email,
                };

                IdentityResult result = await userManager.CreateAsync(user, "Admin123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
