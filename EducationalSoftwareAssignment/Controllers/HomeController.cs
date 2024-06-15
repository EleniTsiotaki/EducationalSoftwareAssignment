using Microsoft.AspNetCore.Mvc;

namespace LearnJava.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Modules()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Introduction()
        {
            return View();
        }

        public IActionResult BasicConcepts()
        {
            return View();
        }

        public IActionResult AdvancedTechniques()
        {
            return View();
        }
    }
}