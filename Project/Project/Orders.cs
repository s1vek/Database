using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Orders : IBaseClass
    {
        private int id;
        private int customer_id;
        private DateTime order_date;
        private int total_price;

        public Orders() { }
        public Orders(int id, int customer_id, DateTime order_date, int total_price)
        {
            Id = id;
            Customer_id = customer_id;
            Order_date = order_date;
            Total_price = total_price;
        }

        public int Id { get => id; set => id = value; }
        public int Customer_id { get => customer_id; set => customer_id = value; }
        public DateTime Order_date { get => order_date; set => order_date = value; }
        public int Total_price { get => total_price; set => total_price = value; }

    }
}
