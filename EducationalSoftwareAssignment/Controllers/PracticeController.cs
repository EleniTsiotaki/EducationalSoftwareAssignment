using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducationalSoftwareAssignment.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

namespace EducationalSoftwareAssignment.Controllers
{
    public class PracticeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PracticeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager; // Add UserManager

        public PracticeController(ApplicationDbContext context, ILogger<PracticeController> logger, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index action invoked.");

            // Get the current user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                _logger.LogError("No user found.");
                return Unauthorized();
            }

            _logger.LogInformation($"User found: {user.UserName}");

            // Initialize Exercise visibility to false by default
            bool[] exerciseVisibility = new bool[8]; // Assuming there are 8 exercises
            for (int i = 0; i < exerciseVisibility.Length; i++)
            {
                exerciseVisibility[i] = false;
            }

            // Query completed exercises for the current user
            var completedExercises = await _context.Statistics
                .Where(s => s.Username == user.UserName && s.Timer == "0:10")
                .Select(s => s.Test_Id)
                .ToListAsync();

            _logger.LogInformation($"Exercises completed by user {user.UserName}: {string.Join(", ", completedExercises)}");

            // Update exercise visibility based on the completed exercises
            foreach (var testId in completedExercises)
            {
                if (testId >= 1 && testId <= 8)
                {
                    exerciseVisibility[testId - 1] = true; // Set corresponding exercise visibility to true
                    _logger.LogInformation($"Exercise {testId} set to visible.");
                }
                else
                {
                    _logger.LogWarning($"Invalid Test_Id {testId} found for user {user.UserName}.");
                }
            }

            // Pass the visibility array to the view
            ViewBag.ExerciseVisibility = exerciseVisibility;

            _logger.LogInformation("Returning view with exercise visibility settings.");

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