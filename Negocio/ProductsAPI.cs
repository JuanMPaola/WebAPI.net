﻿using Dapper;
using MySql.Data.MySqlClient;
using Negocio.Models;
using System.ComponentModel;
using System.Text.Json.Nodes;


namespace Negocio
{
    public class ProductsAPI
    {
        string connStr = "Server=db4free.net;Database=lasnieves110424;Uid=lasnieves110424;Pwd=lasnieves110424";
        public List<Product> GetAll()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM `Products`";
                return conn.Query<Product>(sql).ToList();
            };
        }
        public Product Post(Product product)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO Products (Title, Description, Category, Price) VALUES (@Title, @Description, @Category, @Price)";
                return conn.QueryFirstOrDefault<Product>(sql, new
                {
                    Title = product.Title,
                    Description = product.Description,
                    Category = product.Category,
                    Price = product.Price
                });
            }
        }
        public Product GetById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM `Products` WHERE Id = @Id";
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

                    return rowsAffected > 0;
                }
                else
                {
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

        public List<string> GetCategories()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT Category FROM Categories";
                return conn.Query<string>(sql).ToList();
            };
        }

        public int PostCategorie(string category) 
        { 
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO Categories (Category) VALUES (@Category);";
                return conn.Execute(sql, new { Category = category });
            }
        }
    }
}