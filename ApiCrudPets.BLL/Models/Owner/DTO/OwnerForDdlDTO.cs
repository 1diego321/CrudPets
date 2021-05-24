using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudPets.BLL.Models.Owner.DTO
{
    public class OwnerForDdlDTO
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public OwnerForDdlDTO(int key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
