using Microsoft.AspNetCore.Identity;

namespace Dev_Folio.Utilities
{
    public class RoleUtilities
    {
        public static async Task EnsureRolesCreated(RoleManager<IdentityRole> roleManager)
        {
            string[] rolesToCreate = {  "Admin"  };

            foreach (var roleName in rolesToCreate)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    var newRole = new IdentityRole { Name = roleName };
                    await roleManager.CreateAsync(newRole);
                }
            }
        }
    }
}
