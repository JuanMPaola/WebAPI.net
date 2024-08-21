using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class Datos
    {
        static public List<Product> listaProductos = new List<Product>() { };
        static public void agregar(Product producto)
        {
            listaProductos.Add(producto);
        }
    }
}
