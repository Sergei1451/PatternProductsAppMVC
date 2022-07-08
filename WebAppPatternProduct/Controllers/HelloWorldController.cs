using Microsoft.AspNetCore.Mvc;

namespace WebAppPatternProduct.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(int numtimes, string name)
        {
            ViewData["Message"] = "Hello" + name;
            ViewData["NumTimes"] = numtimes;
            return View();
        }
    }
}
