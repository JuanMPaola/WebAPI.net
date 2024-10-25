using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductsAPI api = new ProductsAPI();
        List<Product> _productsList = new List<Product>();
        Product _product = new Product();

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _productsList = api.GetAll();
                return Ok(_productsList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _product = api.GetById(id);
                if(_product != null)
                {
                    return Ok(_product);
                }
                else
                {
                    //return Ok(new { Message = $"No product with id {id} was found." });
                    return NoContent();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        [SwaggerRequestBody("The product to add", Required = true, Example = typeof(Product))]
        public IActionResult Post([FromBody] Product product)
        {
            try 
            {
                _product = api.Post(product);
                return StatusCode(201, _product);
            }
            catch (Exception ex) 
            { 
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Product product)
        {
            try
            {
                _product = api.Put(product);
                return Ok(_product);
            }catch (Exception ex) 
            { 
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool isDeleted = api.Delete(id);

                if (isDeleted)
                {
                    return Ok($"Product with id {id} was successfully deleted.");
                }
                else
                {
                    //return Ok(new { Message = $"Could not delete product with id {id}." });
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }
    }
}
