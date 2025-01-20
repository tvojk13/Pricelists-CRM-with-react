using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pricelists.DataAccess.Entites;

namespace Pricelists.DataAccess.Configurations
{
    public class PricelistConfiguration : IEntityTypeConfiguration<PricelistEntity>
    {
        public void Configure(EntityTypeBuilder<PricelistEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Title)
                .IsRequired();
        }
    }
}
