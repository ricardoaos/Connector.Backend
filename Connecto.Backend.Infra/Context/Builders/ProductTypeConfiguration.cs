using Connector.Backend.Domain.Entities.Consumo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connector.Backend.Infra.Context.Builders
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<Consumo>
    {
        public void Configure(EntityTypeBuilder<Consumo> builder)
        {
            builder.ToTable("Consumo");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Codigo).IsRequired();
            builder.Property(p => p.Descricao).IsRequired();
        }
    }
}