using Microsoft.AspNetCore.Mvc;

namespace mvcTutorial.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int ID = 1)
        {
            string message = $"Hello {name}! Your ID is {ID}";

            ViewData["Message"] = message;
            ViewData["ID"] = ID;

            return View();
        }
    }
}
