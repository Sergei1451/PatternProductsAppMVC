using Microsoft.AspNetCore.Mvc;

namespace WebAppPatternProduct.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string Welcome(int ID, string name)
        {
            return $"Hello {name}, ID = {ID}";
        }
    }
}
