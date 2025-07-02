using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class VisitConfiguration : IEntityTypeConfiguration<Visit>
    {
        private const string tableName = "Visit";

        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Arrival).HasColumnType("smalldatetime").IsRequired();
        }
    }
}
