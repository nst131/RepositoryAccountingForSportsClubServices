using Microsoft.EntityFrameworkCore;
using ServiceAccountingDA.Configuration;
using ServiceAccountingDA.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingDA.Context
{
    public class ServiceAccountingContext : DbContext, IServiceAccountingContext
    {
        public ServiceAccountingContext(DbContextOptions<ServiceAccountingContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server =.\\SQLEXPRESS; Database = ServiceAccountingDatabase; Trusted_Connection = True; MultipleActiveResultSets = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ClientCardConfiguration());
            modelBuilder.ApplyConfiguration(new ClubCardConfiguration());
            modelBuilder.ApplyConfiguration(new DealConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceConfiguration());
            modelBuilder.ApplyConfiguration(new ResponsibleConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new TrainerConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingConfiguration());
            modelBuilder.ApplyConfiguration(new TypeOfSexConfiguration());
            modelBuilder.ApplyConfiguration(new VisitConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionToClientConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingToClientConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
            .Where(x => x.Entity is BaseEntity && (x.State is EntityState.Added or EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}
