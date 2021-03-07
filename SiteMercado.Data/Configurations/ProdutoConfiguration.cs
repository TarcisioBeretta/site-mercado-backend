using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteMercado.Core.Models;

namespace SiteMercado.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Nome)
                .IsRequired();

            builder
                .Property(m => m.Imagem)
                .IsRequired();

            builder
                .Property(m => m.Valor)
                .IsRequired();

            builder
                .ToTable("Produtos");
        }
    }
}
