using ApiCrudPets.DAL.Data;
using ApiCrudPets.DAL.Entities;
using ApiCrudPets.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.DAL.Repositories
{
    public class PetRepository : GenericRepository<Pet> ,IPetRepository
    {
        public PetRepository(AppDbContext context)
            : base(context)
        {

        }
    }
}
