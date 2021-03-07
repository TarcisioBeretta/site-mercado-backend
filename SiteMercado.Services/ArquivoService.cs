using Microsoft.AspNetCore.Http;
using SiteMercado.Core.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SiteMercado.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly string PATH = "Imagens";

        public async Task<string> Save(IFormFile file)
        {
            var dir = GetDirectory();
            var fileName = GenerateFileName(file);
            var filePath = Path.Combine(dir, fileName);

            using FileStream filestream = File.Create(filePath);
            await file.CopyToAsync(filestream);
            filestream.Flush();
            return fileName;
        }

        public void Delete(string fileName)
        {
            var dir = GetDirectory();
            var filePath = Path.Combine(dir, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string GetExternalPath(string fileName)
        {
            return Path.Combine(PATH, fileName);
        }

        private string GetDirectory()
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", PATH);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        private string GenerateFileName(IFormFile file)
        {
            var fileName = Guid.NewGuid().ToString();
            var fileExtension = Path.GetExtension(file.FileName);
            return fileName + fileExtension;
        }
    }
}
