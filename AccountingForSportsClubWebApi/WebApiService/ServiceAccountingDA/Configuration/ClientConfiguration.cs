using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        private const string tableName = "Client";

        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.SerName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Telephone).IsRequired();

            builder.HasOne(x => x.ClientCard) // Client main enity, ClientCard secondary entity
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

            //builder.HasData(new Client[]
            //{
            //    new Client(){Id = 1, Name = "Alexander", SerName = "Nikylskiy", Telephone = "29 613-89-57", Email = "alexander@mail.ru", TypeSexId = 1},
            //    new Client(){Id = 2, Name = "Vitaliy", SerName = "Romanovskiy", Telephone = "29 713-80-90", Email = "vitaliy@mail.ru", TypeSexId = 1},
            //    new Client(){Id = 3, Name = "Maria", SerName = "Gavrilova", Telephone = "29 786-13-44", Email = "maria@mail.ru", TypeSexId = 2}
            //});
        }
    }
}
