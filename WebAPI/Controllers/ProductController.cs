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
            var products = api.getAll();
            return products;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return api.getById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public Product Post([FromBody] Product producto)
        {
            return api.post(producto);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
