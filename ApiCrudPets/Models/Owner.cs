using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudPets.Models
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [StringLength(100)]
        public string ImageName { get; set; }

        public int AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        public IEnumerable<Pet> Pet { get; set; }
    }
}
