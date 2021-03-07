using Microsoft.AspNetCore.Http;
using SiteMercado.Core;
using SiteMercado.Core.Models;
using SiteMercado.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteMercado.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArquivoService _arquivoService;

        public ProdutoService(
            IUnitOfWork unitOfWork,
            IArquivoService arquivoService
        )
        {
            _unitOfWork = unitOfWork;
            _arquivoService = arquivoService;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _unitOfWork.Produtos.GetAll();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _unitOfWork.Produtos.GetById(id);
        }

        public async Task<Produto> GetByIdWithExternalImageUrl(int id)
        {
            var produto = await _unitOfWork.Produtos.GetById(id);
            produto.Imagem = _arquivoService.GetExternalPath(produto.Imagem);
            return produto;
        }

        public async Task<Produto> Create(Produto newProduto, IFormFile imagem)
        {
            newProduto.Imagem = await _arquivoService.Save(imagem);
            await _unitOfWork.Produtos.Create(newProduto);
            await _unitOfWork.Commit();
            return newProduto;
        }

        public async Task<Produto> Update(Produto produtoToBeUpdated, Produto produto, IFormFile imagem)
        {
            if (imagem != null)
            {
                _arquivoService.Delete(produtoToBeUpdated.Imagem);
                produtoToBeUpdated.Imagem = await _arquivoService.Save(imagem);
            }

            produtoToBeUpdated.Nome = produto.Nome;
            produtoToBeUpdated.Valor = produto.Valor;
            await _unitOfWork.Commit();
            return produtoToBeUpdated;
        }

        public async Task Delete(Produto produto)
        {
            _arquivoService.Delete(produto.Imagem);
            _unitOfWork.Produtos.Delete(produto);
            await _unitOfWork.Commit();
        }
    }
}
