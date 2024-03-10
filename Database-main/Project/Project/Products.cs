using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Products : IBaseClass //Represents Product table 
    {
        private int id;
        private string product_name;
        private decimal price;
        private bool is_available;

        public Products() { }

        public Products(int id, string product_name, decimal price, bool is_available)
        {
            Id = id;
            Product_name = product_name;
            Price = price;
            Is_available = is_available;
        }

        public int Id { get => id; set => id = value; }
        public string Product_name { get => product_name; set => product_name = value; }
        public decimal Price { get => price; set => price = value; }
        public bool Is_available { get => is_available; set => is_available = value; }

        public override string? ToString()
        {
            return id + " " + product_name;
        }
    }


}
