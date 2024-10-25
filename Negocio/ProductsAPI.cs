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
                string query = "SELECT Id, Name, Price FROM `Products`";
                return conn.Query<Product>(query).ToList();
            };
        }
        public Product Post(Product product)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";
                conn.Execute(query, new { Name = product.Name, Price = product.Price });
                return product;
            };
        }
        public Product GetById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Id, Name, Price FROM `Products` WHERE Id = @Id";
                return conn.QueryFirstOrDefault<Product>(query, new { Id = id });
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
                    string query = "DELETE FROM `Products` WHERE Id = @Id";
                    int rowsAffected = conn.Execute(query, new { Id = id });

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
        public Product Put(Product product)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id";
                conn.Execute(query, new {Id = product.Id, Name = product.Name, Price = product.Price });
                return product;
            };
        }
    }
}