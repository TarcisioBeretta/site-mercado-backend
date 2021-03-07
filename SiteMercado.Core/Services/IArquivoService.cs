using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SiteMercado.Core.Services
{
    public interface IArquivoService
    {
        public Task<string> Save(IFormFile file);
        public void Delete(string fileName);
        public string GetExternalPath(string fileName);
    }
}
