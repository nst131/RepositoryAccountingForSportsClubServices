using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        private const string tableName = "Service";

        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.DurationInMinutes).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasOne(x => x.Place)
                .WithMany(x => x.Services)
                .HasForeignKey(x => x.PlaceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Trainers)
                .WithOne(x => x.Service)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Trainings)
                .WithOne(x => x.Service)
                .HasForeignKey(x => x.ServicesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Visits)
                .WithOne(x => x.Service)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ClubCards)
                .WithOne(x => x.Service)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Subscriptions)
                .WithOne(x => x.Service)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ClientCards)
                .WithOne(x => x.Service)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new Service[] { 
                new Service(){Id = 1, Name = "Crossfit", Price = 10, DurationInMinutes = 60 ,PlaceId = 1},
                new Service(){Id = 2, Name = "BodyBuilding", Price = 10, DurationInMinutes = 60 , PlaceId = 1},
                new Service(){Id = 3, Name = "Yoga", Price = 9, DurationInMinutes = 60 , PlaceId = 2},
                new Service(){Id = 4, Name = "Stretching", Price = 9, DurationInMinutes = 60 , PlaceId = 2},
                new Service(){Id = 5, Name = "Karate", Price = 10, DurationInMinutes = 60 , PlaceId = 3},
                new Service(){Id = 6, Name = "MMA", Price = 12, DurationInMinutes = 60 , PlaceId = 3},
            });
        }
    }
}
