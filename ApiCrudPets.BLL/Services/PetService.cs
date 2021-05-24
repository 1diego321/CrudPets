using ApiCrudPets.BLL.Models.Pet.DTO;
using ApiCrudPets.BLL.Services.Abstractions;
using ApiCrudPets.DAL.Entities;
using ApiCrudPets.DAL.UnitOfWork.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.BLL.Services
{
    public class PetService : ResourceService, IPetService
    {
        #region DEPENDENCIES
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public PetService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region METHODS
        public async Task<bool> CreateAsync(PetCreateOrUpdateDTO model)
        {
            Pet oPet = _mapper.Map<Pet>(model);

            if (model.Image != null)
            {
                oPet.ImageName = await CreateImageAsync(model.Image);
            }

            await _unitOfWork.Pet.CreateAsync(oPet);

            return await SaveAsync();
        }

        public async Task<bool> UpdateAsync(PetCreateOrUpdateDTO model, int id)
        {
            var oPet = await _unitOfWork.Pet.GetByIdAsync(id);

            if (oPet == null)
                return false;

            if (model.Image != null)
            {
                DeleteImage(oPet.ImageName);
                oPet.ImageName = await CreateImageAsync(model.Image);
            }

            oPet.Color = model.Color;
            oPet.Gender = model.Gender;
            oPet.Name = model.Name;
            oPet.OwnerId = model.OwnerId;

            _unitOfWork.Pet.Update(oPet);

            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var oPet = await _unitOfWork.Pet.GetByIdAsync(id);

            if (oPet == null)
                return false;

            string imgName = oPet.ImageName;

            _unitOfWork.Pet.Delete(oPet);

            var ok = await SaveAsync();

            if (ok)
            {
                if (imgName != null)
                    DeleteImage(imgName);
            }

            return ok;
        }

        public async Task<IEnumerable<PetDTO>> GetAllAsync()
        {
            return (await _unitOfWork.Pet.GetAllAsync(includeProperties: "Owner"))
                    .Select(x => _mapper.Map<PetDTO>(x));
        }

        public async Task<PetDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<PetDTO>(await _unitOfWork.Pet.GetByIdAsync(id));
        }
        #endregion

        #region UTILITY METHODS
        private async Task<bool> SaveAsync()
        {
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
