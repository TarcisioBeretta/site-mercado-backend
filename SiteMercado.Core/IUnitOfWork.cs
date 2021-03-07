using SiteMercado.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace SiteMercado.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProdutoRepository Produtos { get; }
        Task<int> Commit();
    }
}