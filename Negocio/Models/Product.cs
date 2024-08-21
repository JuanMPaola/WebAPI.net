using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Models
{
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; }
        public int price { get; set; }
        public Product(int _id, string _title, int _price)
        {
            this.id = _id;
            this.title = _title;
            this.price = _price;
        }
    }
}
