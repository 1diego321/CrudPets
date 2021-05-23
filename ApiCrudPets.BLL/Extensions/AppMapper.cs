using ApiCrudPets.BLL.Models.Pet.DTO;
using ApiCrudPets.DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.BLL.Extensions
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<Pet, PetDTO>()
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner.Name))
                .ReverseMap();

            CreateMap<Pet, PetCreateOrUpdateDTO>().ReverseMap();
        }
    }
}
