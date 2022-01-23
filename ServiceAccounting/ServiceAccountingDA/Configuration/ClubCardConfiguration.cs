using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class ClubCardConfiguration : IEntityTypeConfiguration<ClubCard>
    {
        private const string tableName = "ClubCard";

        public void Configure(EntityTypeBuilder<ClubCard> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.DurationInDays).IsRequired();

            builder.HasMany(x => x.ClientCards)
                .WithOne(x => x.ClubCard)
                .HasForeignKey(x => x.ClubCardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Deals)
                .WithOne(x => x.ClubCard)
                .HasForeignKey(x => x.ClubCardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new ClubCard[] { 
                new ClubCard(){ Id = 1, Name="BeFit", ServiceId = 1, DurationInDays = 180, Price = 400},
                new ClubCard(){ Id = 2, Name="BeFlexibleInLife", ServiceId = 4, DurationInDays = 180, Price = 380},
                new ClubCard(){ Id = 3, Name="PathOfTheFighter", ServiceId = 6, DurationInDays = 120, Price = 300}
            });
        }
    }
}
