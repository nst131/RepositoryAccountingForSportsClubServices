using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        private const string tableName = "Subscription";

        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.AmountWorkouts).IsRequired();

            builder.HasMany(x => x.Deals)
                .WithOne(x => x.Subscription)
                .HasForeignKey(x => x.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new Subscription[] { 
                new Subscription(){Id = 1, ServiceId = 1, AmountWorkouts = 1, Name = "Crossfit One", Price = 10},            
                new Subscription(){Id = 2, ServiceId = 1, AmountWorkouts = 4, Name = "Crossfit Four", Price = 35},
                new Subscription(){Id = 3, ServiceId = 1, AmountWorkouts = 8, Name = "Crossfit Eight", Price = 65},

                new Subscription(){Id = 4, ServiceId = 2, AmountWorkouts = 1, Name = "BodyBuilding One", Price = 10},            
                new Subscription(){Id = 5, ServiceId = 2, AmountWorkouts = 4, Name = "BodyBuilding Four", Price = 35},
                new Subscription(){Id = 6, ServiceId = 2, AmountWorkouts = 8, Name = "BodyBuilding Eight", Price = 65},

                new Subscription(){Id = 7, ServiceId = 3, AmountWorkouts = 1, Name = "Yoga One", Price = 9},
                new Subscription(){Id = 8, ServiceId = 3, AmountWorkouts = 4, Name = "Yoga Four", Price = 30},
                new Subscription(){Id = 9, ServiceId = 3, AmountWorkouts = 8, Name = "Yoga Eight", Price = 55},

                new Subscription(){Id = 10, ServiceId = 4, AmountWorkouts = 1, Name = "Stretching One", Price = 9},
                new Subscription(){Id = 11, ServiceId = 4, AmountWorkouts = 4, Name = "Stretching Four", Price = 30},
                new Subscription(){Id = 12, ServiceId = 4, AmountWorkouts = 8, Name = "Stretching Eight", Price = 55},

                new Subscription(){Id = 13, ServiceId = 5, AmountWorkouts = 1, Name = "Karate One", Price = 10},
                new Subscription(){Id = 14, ServiceId = 5, AmountWorkouts = 4, Name = "Karate Four", Price = 35},
                new Subscription(){Id = 15, ServiceId = 5, AmountWorkouts = 8, Name = "Karate Eight", Price = 65},

                new Subscription(){Id = 16, ServiceId = 6, AmountWorkouts = 1, Name = "MMA One", Price = 12},
                new Subscription(){Id = 17, ServiceId = 6, AmountWorkouts = 4, Name = "MMA Four", Price = 40},
                new Subscription(){Id = 18, ServiceId = 6, AmountWorkouts = 8, Name = "MMA Eight", Price = 75},
            });
        }
    }
}
