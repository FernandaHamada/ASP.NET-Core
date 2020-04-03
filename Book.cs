using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web
{
    public class Book
    {
        public Book(string code, string name, decimal price)
        {
            Code = code;
            Name = name;
            Price = price;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
