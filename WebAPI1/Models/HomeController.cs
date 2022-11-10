using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Models
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
