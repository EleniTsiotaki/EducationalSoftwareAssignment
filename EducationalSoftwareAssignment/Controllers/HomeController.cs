using EducationalSoftwareAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace EducationalSoftwareAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Courses()
        {
            var username = User.Identity.Name; // Get the username of the logged-in user
            if (username == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect if not authenticated
            }

            // Fetch grades for the logged-in user from Statistics table
            var userTests = _context.Statistics
                                   .Where(t => t.Username == username)
                                   .ToList();
            return View("Courses", userTests); // Pass userTests data to Courses.cshtml view
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test(int id)
        {
            ViewData["TestId"] = id;
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

        public IActionResult Exercises()
        {
            return View();
        }
        public IActionResult Progress()
        {
            return View();
        }
    }
}