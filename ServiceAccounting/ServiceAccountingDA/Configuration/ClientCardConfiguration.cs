using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class ClientCardConfiguration : IEntityTypeConfiguration<ClientCard>
    {
        private const string tableName = "ClientCard";

        public void Configure(EntityTypeBuilder<ClientCard> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.DateActivation).HasColumnType("smalldatetime").IsRequired();
            builder.Property(x => x.DateExpiration).HasColumnType("smalldatetime").IsRequired();
        }
    }
}
