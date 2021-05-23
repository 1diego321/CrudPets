using ApiCrudPets.BLL.Models.App;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.BLL.Services.Abstractions
{
    public interface IOwnerService
    {
        public ImageInfoDTO GetImage(string imgName);
        Task<string> CreateImageAsync(IFormFile image);
    }
}
