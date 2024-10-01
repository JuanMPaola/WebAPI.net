using Negocio.Models;
using System.ComponentModel;
using System.Text.Json.Nodes;


namespace Negocio
{
    public class ProductsAPI
    {
        public List<Product> GetAll()
        {
            return Datos.productsList.OrderBy(item => item.id).ToList();
        }
        public Product Post(Product producto)
        {
            Datos.productsList.Add(producto);
            return producto;
        }
        public Product GetById(int id)
        {
            return Datos.productsList.Where(item => item.id == id).First();
        }
        public Product Delete(int id)
        {
            Datos.productsList.RemoveAll(item => item.id == id);
            return Datos.productsList.Where(item => item.id == id).First();
        }
        public Product Put(Product prod)
        {
            var product = Datos.productsList.Where(item => item.id == prod.id).First();
            Datos.productsList.Remove(product);
            Datos.productsList.Add(prod);
            return product;
        }
    }
}