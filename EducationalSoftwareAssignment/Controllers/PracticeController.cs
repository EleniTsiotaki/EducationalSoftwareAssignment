using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducationalSoftwareAssignment.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalSoftwareAssignment.Controllers
{
    public class PracticeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PracticeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _context.Users.FirstOrDefaultAsync(); // Get the currently logged in user

            // Initialize Exercise visibility to false by default
            ViewBag.ExerciseVisible = false;

            // Check if the condition with the timer is met
            var exerciseVisible = await _context.Statistics
                .Where(s => s.Username == user.UserName && s.Test_Id == 1 && s.Timer == "0:10")
                .AnyAsync();

            // Update ViewBag.ExerciseVisible if the condition is true
            if (exerciseVisible)
            {
                ViewBag.ExerciseVisible = true;
            }

            return View();
        }
        public IActionResult Exercise1()
        {
            return View();
        }

        public IActionResult Exercise2()
        {
            return View();
        }

        public IActionResult Exercise3()
        {
            return View();
        }
        public IActionResult Exercise4()
        {
            return View();
        }
        public IActionResult Exercise5()
        {
            return View();
        }
        public IActionResult Exercise6()
        {
            return View();
        }
        public IActionResult Exercise7()
        {
            return View();
        }
        public IActionResult Exercise8()
        {
            return View();
        }
    }
}