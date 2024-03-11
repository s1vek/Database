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
        private string reviewtext;

        public Review () { }

        public Review(int id, string reviewtext)
        {
            Id = id;
            Reviewtext = reviewtext;
        }

        public int Id { get => id; set => id = value; }
        public string Reviewtext { get => reviewtext; set => reviewtext = value; }



}
}
