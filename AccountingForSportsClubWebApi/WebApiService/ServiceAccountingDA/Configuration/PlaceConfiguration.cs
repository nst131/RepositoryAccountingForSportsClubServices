using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        private const string tableName = "Place";

        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.AmountFreePlace).IsRequired();

            builder.HasData(new Place[]{
                new Place(){Id = 1, Name = "Gym", AmountFreePlace = 15},
                new Place(){Id = 2, Name = "GymnasticHall", AmountFreePlace = 15},
                new Place(){Id = 3, Name = "HallWithTatami", AmountFreePlace = 15}
            });
        }
    }
}
