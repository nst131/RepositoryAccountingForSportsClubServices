using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class DealConfiguration : IEntityTypeConfiguration<Deal>
    {
        private const string tableName = "Deal";

        public void Configure(EntityTypeBuilder<Deal> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.PurchaseDate).HasColumnType("smalldatetime").IsRequired();
        }
    }
}
