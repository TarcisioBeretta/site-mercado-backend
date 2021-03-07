using Microsoft.AspNetCore.Http;
using SiteMercado.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteMercado.Core.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetById(int id);
        Task<Produto> GetByIdWithExternalImageUrl(int id);
        Task<Produto> Create(Produto newProduto, IFormFile imagem);
        Task<Produto> Update(Produto produtoToBeUpdated, Produto produto, IFormFile imagem);
        Task Delete(Produto produto);
    }
}
