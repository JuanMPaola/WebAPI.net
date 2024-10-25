using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Models
{
    public class Product
    {
        public int Id { get; set; }

        [SwaggerSchema(Description = "The title of the product.", Example = "Sample Product")]
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
