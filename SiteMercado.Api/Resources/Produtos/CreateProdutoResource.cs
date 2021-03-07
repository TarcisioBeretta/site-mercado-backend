using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SiteMercado.Api.Resources.Produto
{
    public class CreateProdutoResource
    {
        [Required(ErrorMessage = "O campo \"Nome\" é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo \"Valor\" é obrigatório", AllowEmptyStrings = false)]
        public float Valor { get; set; }

        [Required(ErrorMessage = "O campo \"Imagem\" é obrigatório", AllowEmptyStrings = false)]
        public IFormFile Imagem { get; set; }
    }
}
