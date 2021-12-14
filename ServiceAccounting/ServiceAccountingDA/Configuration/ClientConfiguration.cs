using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        private const string tableName = "Client";
        private const string tableClientsToSubscriptions = "ClientToSubscriptions";
        private const string tableClientsToTrainings = "ClientsToTrainings";

        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.SerName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Telephone).IsRequired();

            builder.HasOne(x => x.ClientCard)
                .WithOne(x => x.Client)
                .HasForeignKey<ClientCard>(x => x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.TypeSex)
                .WithMany(x => x.Clients)
                .HasForeignKey(x => x.TypeSexId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Visits)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Deals)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Subscriptions)
                .WithMany(x => x.Clients)
                .UsingEntity(x => x.ToTable(tableClientsToSubscriptions));

            builder.HasMany(x => x.Trainings)
                .WithMany(x => x.Clients)
                .UsingEntity(x => x.ToTable(tableClientsToTrainings));

            builder.HasData(new Client[]
            {
                new Client(){Id = 1, Name = "Alexander", SerName = "Nikylskiy", Telephone = "29 613-89-57", TypeSexId = 1},
                new Client(){Id = 2, Name = "Vitaliy", SerName = "Romanovskiy", Telephone = "29 713-80-90", TypeSexId = 1},
                new Client(){Id = 3, Name = "Maria", SerName = "Gavrilova", Telephone = "29 786-13-44", TypeSexId = 2}
            });
        }
    }
}
