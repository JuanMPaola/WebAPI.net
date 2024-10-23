using Dapper;
using MySql.Data.MySqlClient;
using Negocio.Models;
using System.ComponentModel;
using System.Text.Json.Nodes;


namespace Negocio
{
    public class ProductsAPI
    {
        string connStr = "Server=sql10.freemysqlhosting.net;Database=sql10739703;Uid=sql10739703;Pwd=d4q6qAjJg6;";
        public List<Product> GetAll()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT Id, Name, Price FROM `Products`";
                return conn.Query<Product>(sql).ToList();
            };
        }
        public Product Post(Product producto)
        {
            Datos.productsList.Add(producto);
            return producto;
        }
        public Product GetById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT Id, Name, Price FROM `Products` WHERE Id = @Id";
                return conn.QueryFirstOrDefault<Product>(sql, new { Id = id });
            }
        }
        public bool Delete(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                Product prod = GetById(id);

                if (prod != null)
                {
                    string sql = "DELETE FROM `Products` WHERE Id = @Id";
                    int rowsAffected = conn.Execute(sql, new { Id = id });

                    // Devuelve `true` si el producto fue eliminado
                    return rowsAffected > 0;
                }
                else
                {
                    // No se encontró el producto, por lo tanto no se eliminó nada
                    return false;
                }
            }
        }
        public Product Put(Product prod)
        {
            var product = Datos.productsList.Where(item => item.Id == prod.Id).First();
            Datos.productsList.Remove(product);
            Datos.productsList.Add(prod);
            return product;
        }
    }
}