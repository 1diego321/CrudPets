using ApiCrudPets.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.DAL.UnitOfWork.Abstractions
{
    public interface IUnitOfWork
    {
        public IOwnerRepository Owner { get; }
        public IPetRepository Pet { get; }

        Task<int> SaveChangesAsync();
    }
}
