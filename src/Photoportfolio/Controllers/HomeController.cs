using Microsoft.AspNetCore.Mvc;

namespace Photoportfolio.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
