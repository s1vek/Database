using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Review : IBaseClass //Represents Review table 
    {

        private int id;
        private int customer_id;
        private string reviewtext;

        public Review () { }

        public Review(int id, int customer_id, string reviewtext)
        {
            Id = id;
            Customer_id = customer_id;
            Reviewtext = reviewtext;
        }

        public int Id { get => id; set => id = value; }
        public int Customer_id { get => customer_id; set => customer_id = value; }
        public string Reviewtext { get => reviewtext; set => reviewtext = value; }



}
}
