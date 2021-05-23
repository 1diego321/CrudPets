using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.BLL.Models.Pet.DTO
{
    public class PetDTO
    {
        [Key]
        public int Id { get; set; }

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

        [StringLength(100)]
        public string ImageName { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Dueño")]
        public string OwnerName { get; set; }

    }
}
