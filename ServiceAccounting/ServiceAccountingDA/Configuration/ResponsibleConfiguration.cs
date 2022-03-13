using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class ResponsibleConfiguration : IEntityTypeConfiguration<Responsible>
    {
        private const string tableName = "Responsible";

        public void Configure(EntityTypeBuilder<Responsible> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.SerName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Telephone).IsRequired();

            builder.HasMany(x => x.Deals)
                .WithOne(x => x.Responsible)
                .HasForeignKey(x => x.ResponsibleId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasData(new Responsible[]
            //{
            //    new Responsible(){Id = 1, Name = "Safia", SerName = "Mirinina",Email = "saf@mail.ru", Telephone = "44 786-12-12"},
            //    new Responsible(){Id = 2, Name = "Lera", SerName = "Shablovskai",Email = "lerka@mail.ru", Telephone = "33 514-17-21"}
            //});
        }
    }
}
