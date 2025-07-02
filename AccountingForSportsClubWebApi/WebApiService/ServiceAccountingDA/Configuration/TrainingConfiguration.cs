using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        private const string tableName = "Training";

        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.StartTraining).HasColumnType("smalldatetime").IsRequired();
            builder.Property(x => x.FinishTraining).HasColumnType("smalldatetime").IsRequired();
        }
    }
}
