using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.BLL.Models.Pet.DTO
{
    public class PetCreateOrUpdateDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(25, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres.")]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres.")]
        [Display(Name = "Género")]
        public string Gender { get; set; }

        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Dueño")]
        public int OwnerId { get; set; }
    }
}
