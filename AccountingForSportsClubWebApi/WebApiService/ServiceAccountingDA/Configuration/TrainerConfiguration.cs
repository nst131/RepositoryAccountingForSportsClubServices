using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        private const string tableName = "Trainer";

        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.SerName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Telephone).IsRequired();

            builder.HasMany(x => x.Trainings)
                .WithOne(x => x.Trainer)
                .HasForeignKey(x => x.TrainerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.TypeSex)
                .WithMany(x => x.Trainers)
                .HasForeignKey(x => x.TypeSexId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasData(new Trainer[]
            //{
            //    new Trainer(){Id = 1, Name = "Valeriy", SerName = "Petrenko", Telephone = "33 567-13-09", Email = "valer@mail.ru", TypeSexId = 1, ServiceId = 1},
            //    new Trainer(){Id = 2, Name = "Vitaliy", SerName = "Zazyla", Telephone = "33 457-13-31",Email = "vital@mail.ru", TypeSexId = 1, ServiceId = 2},
            //    new Trainer(){Id = 3, Name = "Nastya", SerName = "Nesterenko", Telephone = "33 187-20-93",Email = "nast@mail.ru", TypeSexId = 2, ServiceId = 3},
            //    new Trainer(){Id = 4, Name = "Olga", SerName = "Bogdan", Telephone = "44 782-67-96",Email = "olya@mail.ru", TypeSexId = 2, ServiceId = 4},
            //    new Trainer(){Id = 5, Name = "Alexey", SerName = "Kikta", Telephone = "29 148-20-90",Email = "alex@mail.ru", TypeSexId = 1, ServiceId = 5},
            //    new Trainer(){Id = 6, Name = "Ivan", SerName = "Mazyrin", Telephone = "29 504-70-29",Email = "ivan@mail.ru", TypeSexId = 1, ServiceId = 6}
            //});
        }
    }
}
