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
                return Ok(_product);

            }catch (Exception ex)
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
                _product = api.Delete(id);
                return Ok(_product);
            }catch (Exception ex)
            { 
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }
    }
}
