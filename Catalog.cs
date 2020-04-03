using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web
{
    // ICatalog interface do catálogo
    public class Catalog : ICatalog
    {
        public List<Book> GetBooks()
        {
            var books = new List<Book>();
            books.Add(new Book("001", "Quem mexeu na minha Query?", 12.99m));
            books.Add(new Book("002", "Fique rico com C#", 30.99m));
            books.Add(new Book("003", "Java para baixinhos", 25.99m));
            return books;
        }
    }
}
