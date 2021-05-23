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
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(AppDbContext context)
           : base(context)
        {

        }
    }
}
