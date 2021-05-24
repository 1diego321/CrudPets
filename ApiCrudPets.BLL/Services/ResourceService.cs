using ApiCrudPets.BLL.Models.App;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.BLL.Services
{
    public class ResourceService
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly FileExtensionContentTypeProvider _contentTypeProvider;

        public ResourceService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _contentTypeProvider = new FileExtensionContentTypeProvider();
        }

        protected async Task<string> CreateImageAsync(IFormFile image)
        {
            string mainRoute = _hostEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            string imgFolderRoute = Path.Combine(mainRoute, "img");
            string imgName = $"img_{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            string imgRoute = Path.Combine(imgFolderRoute, imgName);


            if (!Directory.Exists(imgFolderRoute))
            {
                Directory.CreateDirectory(imgFolderRoute);
            }

            using (var fs = new FileStream(imgRoute, FileMode.Create))
            {
                await image.CopyToAsync(fs);
            }

            return imgName;
        }

        protected void DeleteImage(string imgName)
        {
            string mainRoute = _hostEnvironment.WebRootPath;
            string imgFolderRoute = Path.Combine(mainRoute, "img");
            string imgRoute = Path.Combine(imgFolderRoute, imgName);

            if (File.Exists(imgRoute))
            {
                File.Delete(imgRoute);
            }
        }

        public ImageInfoDTO GetImage(string imgName)
        {
            ImageInfoDTO oImg = null;

            string mainRoute = _hostEnvironment.WebRootPath;
            string imgFolderRoute = Path.Combine(mainRoute, "img");
            string imgRoute = Path.Combine(imgFolderRoute, imgName);

            if (!Directory.Exists(imgFolderRoute))
            {
                Directory.CreateDirectory(imgRoute);
            }

            if (!File.Exists(imgRoute))
            {
                return oImg;
            }

            using (FileStream fs = File.Open(imgRoute, FileMode.Open))
            {
                oImg.Content = fs;
                oImg.ContentType = GetContentType(imgName);

                return oImg;
            }
        }

        private string GetContentType(string fileName)
        {
            string contentType;

            if (!_contentTypeProvider.TryGetContentType(fileName, out contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }
    }
}
