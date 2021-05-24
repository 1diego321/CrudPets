using ApiCrudPets.BLL.Models.Owner.DTO;
using ApiCrudPets.BLL.Services.Abstractions;
using ApiCrudPets.DAL.UnitOfWork.Abstractions;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.BLL.Services
{
    public class OwnerService : ResourceService, IOwnerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnerService(IWebHostEnvironment hostEnvironment, IUnitOfWork unitOfWork)
            : base(hostEnvironment)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OwnerForDdlDTO>> GetForDLL()
        {
            //Para esto se deberia hacer un metodo en el repo que consulte unicamente el id y el name
            return (await _unitOfWork.Owner.GetAllAsync()).Select(x => new OwnerForDdlDTO(x.Id,x.Name));
        }
    }
}
