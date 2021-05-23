using ApiCrudPets.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Pet> Pet { get; set; }
    }
}
