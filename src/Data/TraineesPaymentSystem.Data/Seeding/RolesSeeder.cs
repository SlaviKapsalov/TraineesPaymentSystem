namespace TraineesPaymentSystem.Data.Seeding
{
    using Constants;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(TraineesPaymentSystemDbContext context, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<TraineesPaymentSystemRole>>();

            await this.SeedRoleAsync(roleManager, SeedingConstants.RoleUser);
            await this.SeedRoleAsync(roleManager, SeedingConstants.RoleModerator);
            await this.SeedRoleAsync(roleManager, SeedingConstants.RoleAdministration);
        }

        private async Task SeedRoleAsync(RoleManager<TraineesPaymentSystemRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                var newRole = new TraineesPaymentSystemRole(roleName);
                var result = await roleManager.CreateAsync(newRole);

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
