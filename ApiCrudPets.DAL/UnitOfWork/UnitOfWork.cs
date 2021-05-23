using ApiCrudPets.DAL.Data;
using ApiCrudPets.DAL.Repositories.Abstractions;
using ApiCrudPets.DAL.UnitOfWork.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context,
                          IOwnerRepository owner,
                          IPetRepository pet)
        {
            _context = context;
            Owner = owner;
            Pet = pet;
        }

        public IOwnerRepository Owner { get; private set; }
        public IPetRepository Pet { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
