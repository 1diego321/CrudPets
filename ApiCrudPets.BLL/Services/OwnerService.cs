using ApiCrudPets.BLL.Services.Abstractions;
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
        public OwnerService(IWebHostEnvironment hostEnvironment)
            : base(hostEnvironment)
        {

        }
    }
}
