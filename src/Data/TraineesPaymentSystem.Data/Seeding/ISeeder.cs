namespace TraineesPaymentSystem.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(TraineesPaymentSystemDbContext context, IServiceProvider serviceProvider);
    }
}