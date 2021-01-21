using Connector.Backend.Domain.Entities.Consumo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicCrud.Infra.Context.Builders
{
    public class CustomerTypeConfiguration : IEntityTypeConfiguration<Consumo>
    {
        public void Configure(EntityTypeBuilder<Consumo> builder)
        {
            builder.ToTable("Consumo");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Ativo).IsRequired();
        }
    }
}