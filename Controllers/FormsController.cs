using Microsoft.AspNetCore.Mvc;

namespace Paradise.Controllers
{
    public class FormsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
