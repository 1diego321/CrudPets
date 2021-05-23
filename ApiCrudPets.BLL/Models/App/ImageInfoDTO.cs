using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.BLL.Models.App
{
    public class ImageInfoDTO
    {
        public Stream Content { get; set; }
        public string ContentType { get; set; }
    }
}
