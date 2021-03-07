using SiteMercado.Core;
using SiteMercado.Core.Repositories;
using SiteMercado.Data.Repositories;
using System.Threading.Tasks;

namespace SiteMercado.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SiteMercadoDbContext _context;
        private ProdutoRepository _produtoRepository;

        public UnitOfWork(SiteMercadoDbContext context)
        {
            _context = context;
        }

        public IProdutoRepository Produtos => _produtoRepository ??= new ProdutoRepository(_context);

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
