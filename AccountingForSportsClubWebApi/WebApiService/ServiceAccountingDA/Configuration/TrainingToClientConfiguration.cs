using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class TrainingToClientConfiguration : IEntityTypeConfiguration<TrainingToClient>
    {
        public void Configure(EntityTypeBuilder<TrainingToClient> builder)
        {
            builder.HasKey(bc => new { bc.ClientId, bc.TrainingId });

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Trainings)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Training)
                .WithMany(x => x.Clients)
                .HasForeignKey(x => x.TrainingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
