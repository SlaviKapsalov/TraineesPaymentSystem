namespace TraineesPaymentSystem.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TraineesPaymentSystem.Data.Common.Repository;

    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public EfRepository(TraineesPaymentSystemDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = context.Set<TEntity>();
        }

        protected TraineesPaymentSystemDbContext Context { get; set; }

        protected DbSet<TEntity> DbSet { get; set; }

        public void Dispose() => this.Context.Dispose();

        public IQueryable<TEntity> All() => this.DbSet;

        public IQueryable<TEntity> AllAsNoTracking() => this.DbSet.AsNoTracking();

        public Task AddAsync(TEntity entity) => this.DbSet.AddAsync(entity);

        public void Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void Delete(TEntity entity) => this.DbSet.Remove(entity);

        public Task<int> SaveChangesAsync() => this.Context.SaveChangesAsync();
    }
}