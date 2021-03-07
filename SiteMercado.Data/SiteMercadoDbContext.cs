using Microsoft.EntityFrameworkCore;
using SiteMercado.Core.Models;
using SiteMercado.Data.Configurations;

namespace SiteMercado.Data
{
    public class SiteMercadoDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public SiteMercadoDbContext(DbContextOptions<SiteMercadoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProdutoConfiguration());
        }
    }
}
