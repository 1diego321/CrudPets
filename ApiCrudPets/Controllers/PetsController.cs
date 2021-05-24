using ApiCrudPets.BLL.Models.App;
using ApiCrudPets.BLL.Models.Pet.DTO;
using ApiCrudPets.BLL.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudPets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _service;

        public PetsController(IPetService service)
        {
            _service = service;
        }

        [HttpGet(Name = nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            ApiResponseDTO oRes = new();

            oRes.Data = await _service.GetAllAsync();
            oRes.Success = true;

            return Ok(oRes);
        }

        [HttpGet("GetGenders")]
        public IActionResult GetGenders()
        {
            ApiResponseDTO oRes = new();

            oRes.Data = new List<string>
            {
                "Macho" ,
                "Hembra"
            };

            oRes.Success = true;
            
            return Ok(oRes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]PetCreateOrUpdateDTO model)
        {
            ApiResponseDTO oRes = new();

            if (!ModelState.IsValid)
            {
                oRes.HasModelErrors = true;
                oRes.Data = GetModelErrors(ModelState);
                return BadRequest(oRes);
            }

            if(await _service.CreateAsync(model))
            {
                oRes.Success = true;
                oRes.Message = "Se creó correctamente!";

                return Created(nameof(GetAll), oRes);
            }
            else
            {
                oRes.Message = "Hubo un problema, no se guardó la mascota";

                return StatusCode(StatusCodes.Status500InternalServerError, oRes);
            }
        }

        #region UTILITY METHODS
        private List<string> GetModelErrors(ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(e => e.Errors.Select(e => e.ErrorMessage)).ToList();
        }
        #endregion
    }
}
