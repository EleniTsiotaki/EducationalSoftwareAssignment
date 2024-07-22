using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EducationalSoftwareAssignment.Models;


namespace EducationalSoftwareAssignment.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CoursesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var userTests = await _context.Statistics
                                          .Where(t => t.Username == user.UserName)
                                          .ToListAsync();

            return View(userTests);
        }

        public async Task<IActionResult> Course(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test == null || !test.IsUnlocked)
            {
                return Unauthorized();
            }

            return View(test);
        }
        public async Task<IActionResult> Course11()
        {
            await IncrementVisitCount("Course11Visits");

            return View();
        }

        public async Task<IActionResult> Course12()
        {
            await IncrementVisitCount("Course12Visits");

            return View();
        }

        public async Task<IActionResult> Course13()
        {
            await IncrementVisitCount("Course13Visits");

            return View();
        }

        public async Task<IActionResult> Course21()
        {
            await IncrementVisitCount("Course21Visits");

            return View();
        }

        public async Task<IActionResult> Course22()
        {
            await IncrementVisitCount("Course22Visits");

            return View();
        }

        public async Task<IActionResult> Course23()
        {
            await IncrementVisitCount("Course23Visits");

            return View();
        }

        public async Task<IActionResult> Course31()
        {
            await IncrementVisitCount("Course31Visits");

            return View();
        }

        public async Task<IActionResult> Course32()
        {
            await IncrementVisitCount("Course32Visits");

            return View();
        }

        public async Task<IActionResult> Course33()
        {
            await IncrementVisitCount("Course33Visits");

            return View();
        }

        private async Task IncrementVisitCount(string courseVisitProperty)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                RedirectToAction("Login", "Account");
                return;
            }

            var progress = await _context.Progress
                                          .FirstOrDefaultAsync(p => p.Username == user.UserName);

            if (progress == null)
            {
                progress = new Progress
                {
                    Id = Guid.NewGuid(),
                    Username = user.UserName
                    // Initialize other properties as needed
                };
                _context.Progress.Add(progress);
            }

            // Use reflection to set the visit count property dynamically
            var property = progress.GetType().GetProperty(courseVisitProperty);
            if (property != null)
            {
                var currentValue = (int)property.GetValue(progress);
                property.SetValue(progress, currentValue + 1);
            }

            await _context.SaveChangesAsync();
        }
    }
}