using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.BLL.Models.App
{
    public class ApiResponseDTO
    {
        public bool HasModelErrors { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ApiResponseDTO()
        {
            HasModelErrors = false;
            Success = false;
        }
    }
}
