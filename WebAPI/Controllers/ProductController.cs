using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductsAPI api = new ProductsAPI();
        
        // GET: api/<ValuesController>
        [HttpGet]
        public List<Product> Get()
        {
            return api.GetAll();
            
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return api.GetById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public Product Post([FromBody] Product producto)
        {
            return api.Post(producto);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public Product Put([FromBody] Product product)
        {
            return api.Put(product);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public Product Delete(int id)
        {
            return api.Delete(id);
        }
    }
}
