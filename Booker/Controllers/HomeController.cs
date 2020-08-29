using Microsoft.AspNetCore.Mvc;

namespace Booker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
