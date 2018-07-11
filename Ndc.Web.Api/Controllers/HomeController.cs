using Microsoft.AspNetCore.Mvc;
using Ndc.Web.Api.Models;

namespace Ndc.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class HomeController : Controller
    {
        private readonly string _key = string.Empty;
        private readonly NdcContext _context;

        public HomeController(NdcContext context)
        {
            _context = context;
        }

        public string Home(string encrypted)
        {
            var request = Library.RequestResponse.Request.GetRequest(encrypted, _key);
            return string.Empty;
        }
    }
}