using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class OrderDetails : IBaseClass //Represents OrderDetails table 
    {

        private int id;
        private int order_id;
        private int product_id;
        private int amount;

        public OrderDetails() { }

        public OrderDetails (int id, int order_id, int product_id, int amount)
        {
            Id = id;
            Order_id = order_id;
            Product_id = product_id;
            Amount = amount;

        }

        public int Id { get => id; set => id = value; }
        public int Order_id { get => order_id; set => order_id = value; }
        public int Product_id { get => product_id; set => product_id = value; }
        public int Amount { get => amount; set => amount = value; }

        public override string ToString ()
        {
            return "Product ID: " + product_id + " amount: " + amount;
        }

    }
}
