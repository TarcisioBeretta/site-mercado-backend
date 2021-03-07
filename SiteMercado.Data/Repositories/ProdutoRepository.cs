using SiteMercado.Core.Models;
using SiteMercado.Core.Repositories;

namespace SiteMercado.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(SiteMercadoDbContext context) : base(context)
        {
        }
    }
}
