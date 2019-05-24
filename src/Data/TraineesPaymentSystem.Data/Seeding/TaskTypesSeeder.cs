using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraineesPaymentSystem.Data.Models;
using TraineesPaymentSystem.Data.Seeding.Constants;

namespace TraineesPaymentSystem.Data.Seeding
{
    public class TaskTypesSeeder : ISeeder
    {
        public async Task SeedAsync(TraineesPaymentSystemDbContext context, IServiceProvider serviceProvider)
        {
            var taskTypes = SeedingConstants.TaskTypes;

            foreach (var type in taskTypes)
            {
                await this.SeedTaskTypeAsync(context, type.Key, type.Value);
            }
        }

        private async Task SeedTaskTypeAsync(TraineesPaymentSystemDbContext context, string name, decimal price)
        {
            var type = await context.TaskTypes.SingleOrDefaultAsync(t => t.Name == name);

            if (type == null)
            {
                type = new TaskType
                {
                    Name = name,
                    PricePerHour = price
                };

                await context.TaskTypes.AddAsync(type);
            }
        }
    }
}