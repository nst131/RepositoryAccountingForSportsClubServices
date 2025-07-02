using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class SubscriptionToClientConfiguration : IEntityTypeConfiguration<SubscriptionToClient>
    {
        public void Configure(EntityTypeBuilder<SubscriptionToClient> builder)
        {
            builder.HasKey(bc => new { bc.ClientId, bc.SubscriptionId });

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Subscriptions)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Subscription)
                .WithMany(x => x.Clients)
                .HasForeignKey(x => x.SubscriptionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
