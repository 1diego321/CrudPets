using ApiCrudPets.BLL.Models.App;
using ApiCrudPets.BLL.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudPets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _service;

        public OwnersController(IOwnerService service)
        {
            _service = service;
        }

        [HttpGet("GetOwners")]
        public async Task<IActionResult> GetOwners()
        {
            ApiResponseDTO oRes = new();

            oRes.Data = await _service.GetForDLL();
            oRes.Success = true;
           
            return Ok(oRes);
        }
    }
}
