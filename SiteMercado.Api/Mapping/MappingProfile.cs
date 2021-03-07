using AutoMapper;
using SiteMercado.Api.Resources.Produto;
using SiteMercado.Core.Models;

namespace Dotz.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoResource>();
            CreateMap<CreateProdutoResource, Produto>();
            CreateMap<UpdateProdutoResource, Produto>();
        }
    }
}
