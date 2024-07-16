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
        public IActionResult Course11()
        {
            return View();
        }

        public IActionResult Course12()
        {
            return View();
        }

        public IActionResult Course13()
        {
            return View();
        }

        public IActionResult Course21()
        {
            return View();
        }

        public IActionResult Course22()
        {
            return View();
        }

        public IActionResult Course23()
        {
            return View();
        }

        public IActionResult Course31()
        {
            return View();
        }

        public IActionResult Course32()
        {
            return View();
        }

        public IActionResult Course33()
        {
            return View();
        }
    }
}
