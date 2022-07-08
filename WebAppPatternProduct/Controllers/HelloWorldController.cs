using Microsoft.AspNetCore.Mvc;

namespace WebAppPatternProduct.Controllers
{
    public class HelloWorldController : Controller
    {
        public string Index()
        {
            return "This is my Default Action";
        }
        public string Welcome(int ID, string name)
        {
            return $"Hello {name}, ID = {ID}";
        }
    }
}
