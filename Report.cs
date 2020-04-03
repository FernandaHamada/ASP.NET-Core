using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web
{
    // IReport interface de Relatório
    public class Report : IReport
    {
        private readonly ICatalog catalog;

        public Report(ICatalog catalog)
        {
            this.catalog = catalog;
        }

        public async Task Print(HttpContext context)
        {
            foreach (var book in  catalog.GetBooks())
            {
                await context.Response.WriteAsync($"<p>{book.Code,-10}{book.Name,-40}{book.Price.ToString("C"),10}</p>");
            }

        }
    }
}
