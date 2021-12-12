using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceAccountingDA.Models;
using System.Linq;

namespace ServiceAccountingDA.Configuration
{
    internal abstract class EnumerationConfiguration<TEnumeration> : IEntityTypeConfiguration<TEnumeration>
        where TEnumeration : Enumeration
    {
        protected abstract string Table { get; }

        public virtual void Configure(EntityTypeBuilder<TEnumeration> builder)
        {
            builder
                .ToTable(this.Table)
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .Property(x => x.Name)
                .HasMaxLength(Enumeration.GetAll<TEnumeration>().Select(x => x.Name.Length).Max())
                .IsRequired();

            builder.HasData(Enumeration.GetAll<TEnumeration>());
        }
    }
}
