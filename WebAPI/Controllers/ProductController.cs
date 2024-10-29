using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Models;
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
        List<string> _categories = new List<string>();

        // GET: api/<ValuesController>
        [HttpGet()]
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
                if (_product != null)
                {
                    return Ok(_product);
                }
                else
                {
                    return Ok(new { Message = $"No product with id {id} was found." });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
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
            }
            catch (Exception ex)
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
                    return Ok(new { Message = $"Could not delete product with id {id}." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        [HttpGet("Categories")]
        public IActionResult GetCategories()
        {
            try
            {
                _categories = api.GetCategories();
                return Ok(_productsList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        // POST api/<ValuesController>
        [HttpPost("Categories")]
        public IActionResult Post([FromBody] string category)
        {
            try
            {
                api.PostCategorie(category);
                return StatusCode(201, category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }
    }
}
