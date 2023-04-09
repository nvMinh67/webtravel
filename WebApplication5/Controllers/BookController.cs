using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
