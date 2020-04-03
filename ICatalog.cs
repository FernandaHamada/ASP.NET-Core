using System.Collections.Generic;

namespace web
{
    public interface ICatalog
    {
        List<Book> GetBooks();
    }
}