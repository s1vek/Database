using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Customer : IBaseClass //Represents Customer table 
    {
        private int id;
        private string first_name;
        private string last_name;
        private string email;

        public Customer() { }

        public Customer(int id, string first_name, string last_name, string email) {
            Id = id;
            First_name = first_name;
            Last_name = last_name;
            Email = email;
        }

        public int Id { get => id; set => id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public string Email { get => email; set => email = value; }

    }
}
