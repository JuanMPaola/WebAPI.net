using Negocio.Models;
using System.ComponentModel;
using System.Text.Json.Nodes;


namespace Negocio
{
    public class ProductsAPI
    {
        public List<Product> getAll()
        {
            Datos.agregar(new Product(1, "2", 5));
            return Datos.listaProductos;
        }
        public Product getById(int id)
        {
            return new Product(1,"2",3);
        }
        public void update(Product producto){ }
        public void delete(int id) {  }
        public Product post(Product producto)
        {
            Datos.agregar(producto);
            return producto;
        }
    }
}