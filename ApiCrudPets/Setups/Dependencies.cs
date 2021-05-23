using ApiCrudPets.BLL.Extensions;
using ApiCrudPets.DAL.Data;
using ApiCrudPets.DAL.Repositories;
using ApiCrudPets.DAL.Repositories.Abstractions;
using ApiCrudPets.DAL.UnitOfWork;
using ApiCrudPets.DAL.UnitOfWork.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudPets.Setups
{
    public static class Dependencies
    {
        public static void SetupDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //DbContext
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            //AutoMapper
            services.AddAutoMapper(typeof(AppMapper));

            //Repositories
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();

            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
