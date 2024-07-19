using EducationalSoftwareAssignment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EducationalSoftwareAssignment.Controllers
{
    public class PracticeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PracticeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public PracticeController(ApplicationDbContext context, ILogger<PracticeController> logger, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index action invoked.");

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                _logger.LogError("No user found.");
                return Unauthorized();
            }

            _logger.LogInformation($"User found: {user.UserName}");

            bool[] exerciseVisibility = new bool[9]; // Array size for 9 exercises
            for (int i = 0; i < exerciseVisibility.Length; i++)
            {
                exerciseVisibility[i] = false;
            }

            var userStatistics = await _context.Statistics
                                               .Where(s => s.Username == user.UserName)
                                               .ToListAsync();

            var completedTests = userStatistics
                                 .Where(s => ConvertTimerToSeconds(s.Timer) >= 10)
                                 .Select(s => s.Test_Id)
                                 .ToList();

            _logger.LogInformation($"Tests completed by user {user.UserName}: {string.Join(", ", completedTests)}");

            foreach (var testId in completedTests)
            {
                // Map test IDs to exercises and skip the final tests
                switch (testId)
                {
                    case 1: exerciseVisibility[0] = true; break; // Test 1 -> Exercise 1
                    case 2: exerciseVisibility[1] = true; break; // Test 2 -> Exercise 2
                    case 3: exerciseVisibility[2] = true; break; // Test 3 -> Exercise 3
                    case 5: exerciseVisibility[3] = true; break; // Test 5 -> Exercise 4
                    case 6: exerciseVisibility[4] = true; break; // Test 6 -> Exercise 5
                    case 7: exerciseVisibility[5] = true; break; // Test 7 -> Exercise 6
                    case 9: exerciseVisibility[6] = true; break; // Test 9 -> Exercise 7
                    case 10: exerciseVisibility[7] = true; break; // Test 10 -> Exercise 8
                    case 11: exerciseVisibility[8] = true; break; // Test 11 -> Exercise 9
                }
            }

            ViewBag.ExerciseVisibility = exerciseVisibility;

            _logger.LogInformation("Returning view with exercise visibility settings.");

            return View();
        }

        private int ConvertTimerToSeconds(string timer)
        {
            var parts = timer.Split(':');
            if (parts.Length == 2)
            {
                int minutes = int.Parse(parts[0]);
                int seconds = int.Parse(parts[1]);
                return (minutes * 60) + seconds;
            }
            return 0;
        }

        public IActionResult Exercise1() => View();
        public IActionResult Exercise2() => View();
        public IActionResult Exercise3() => View();
        public IActionResult Exercise4() => View();
        public IActionResult Exercise5() => View();
        public IActionResult Exercise6() => View();
        public IActionResult Exercise7() => View();
        public IActionResult Exercise8() => View();
        public IActionResult Exercise9() => View();
    }
}
