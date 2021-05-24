using ApiCrudPets.BLL.Models.App;
using ApiCrudPets.BLL.Models.Pet.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.BLL.Services.Abstractions
{
    public interface IPetService
    {
        ImageInfoDTO GetImage(string imgName);   
        //Task<string> CreateImageAsync(IFormFile image);
        Task<bool> UpdateAsync(PetCreateOrUpdateDTO model, int id);
        Task<IEnumerable<PetDTO>> GetAllAsync();
        Task<PetDTO> GetByIdAsync(int id);
        Task<bool> CreateAsync(PetCreateOrUpdateDTO model);
        Task<bool> DeleteAsync(int id);

    }
}
