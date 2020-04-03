using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace web
{
    public interface IReport
    {
        Task Print(HttpContext context);
    }
}