using EducationalSoftwareAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using static System.Net.Mime.MediaTypeNames;


namespace EducationalSoftwareAssignment.Controllers
{
    [Route("Tests")]
    [ApiController]
    public class TestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // POST: Tests/PostTestResult
        [HttpPost("PostTestResult")]
        public async Task<IActionResult> PostTestResult([FromBody] TestResultModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            // Save the test result in Statistics table
            var statistic = new Statistics
            {
                Test_Id = model.TestId,
                Grade = model.Score,
                Timer = model.ElapsedTime,
                Username = user.UserName,
                Answer1 = model.Answer1,
                Answer2 = model.Answer2,
                Answer3 = model.Answer3,
                Answer4 = model.Answer4,
                Answer5 = model.Answer5,
                IsCorrect = model.IsCorrect
            };

            _context.Statistics.Add(statistic);
            await _context.SaveChangesAsync();

            // Check if the completed test should unlock the next test
            await UnlockNextTest(model.TestId, model.Score, user.UserName);

            return Ok();
        }

        private async Task UnlockNextTest(int testId, double score, string username)
        {
            if (testId == 1 && score >= 2.5)
            {
                // Unlock Test12
                var test12 = await _context.Tests.FindAsync(1);

                if (test12 != null)
                {
                    test12.IsUnlocked = true;  // Set IsUnlocked to true
                    await _context.SaveChangesAsync();
                }
            }
            else if (testId == 2 && score >= 2.5)
            {
                // Unlock Test13
                var test13 = await _context.Tests.FindAsync(2);

                if (test13 != null)
                {
                    test13.IsUnlocked = true;  // Set IsUnlocked to true
                    await _context.SaveChangesAsync();
                }
            }
            else if (testId == 3 && score >= 2.5)
            {
                // Unlock Test14
                var test14 = await _context.Tests.FindAsync(3);

                if (test14 != null)
                {
                    test14.IsUnlocked = true;  // Set IsUnlocked to true
                    await _context.SaveChangesAsync();
                }
            }
            else if (testId == 5 && score >= 2.5)
            {
                // Unlock Test16
                var test22 = await _context.Tests.FindAsync(5);

                if (test22 != null)
                {
                    test22.IsUnlocked = true;  // Set IsUnlocked to true
                    await _context.SaveChangesAsync();
                }
            }
        }

        // GET: Tests/CheckTimerForExercise
        [HttpGet("CheckTimerForExercise")]
        public async Task<IActionResult> CheckTimerForExercise()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            // Fetch all statistics for the user
            var userStatistics = await _context.Statistics
                                               .Where(s => s.Username == user.UserName)
                                               .ToListAsync();

            // Filter in-memory based on the timer >= 30 minutes
            var exerciseToShow = userStatistics
                                 .Where(s => ConvertTimerToMinutes(s.Timer) >= 30)
                                 .Select(s => s.Test_Id)
                                 .FirstOrDefault();

            if (exerciseToShow > 0)
            {
                switch (exerciseToShow)
                {
                    case 1:
                        return RedirectToAction("Exercise1", "Practice");
                    case 2:
                        return RedirectToAction("Exercise2", "Practice");
                    case 3:
                        return RedirectToAction("Exercise3", "Practice");
                    case 4:
                        return RedirectToAction("Exercise4", "Practice");
                    case 5:
                        return RedirectToAction("Exercise5", "Practice");
                    case 6:
                        return RedirectToAction("Exercise6", "Practice");
                    case 7:
                        return RedirectToAction("Exercise7", "Practice");
                    case 8:
                        return RedirectToAction("Exercise8", "Practice");
                    case 9:
                        return RedirectToAction("Exercise9", "Practice");
                    default:
                        break;
                }
            }

            return View("Index");
        }
        private int ConvertTimerToMinutes(string timer)
        {
            var parts = timer.Split(':');
            if (parts.Length == 2)
            {
                int minutes = int.Parse(parts[0]);
                return minutes;
            }
            return 0;
        }

        // GET: Tests/testIds
        [HttpGet("testIds")]
        public async Task<IActionResult> GetTestIdsWithGrade(double grade = 2.5)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            // Retrieve test IDs with grades for the current user
            var testIds = await _context.Statistics
                .Where(s => s.Username == user.UserName && s.Grade >= grade)
                .Select(s => s.Test_Id)
                .ToListAsync();

            return Ok(testIds);
        }

        // GET: Tests/CheckGradeForExercise
        [HttpGet("CheckGradeForExercise")]
        public async Task<IActionResult> CheckGradeForExercise()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var highestGrade = await _context.Statistics
                                              .Where(s => s.Username == user.UserName)
                                              .OrderByDescending(s => s.Grade)
                                              .Select(s => s.Grade)
                                              .FirstOrDefaultAsync();

            if (highestGrade >= 2.5)
            {
                return RedirectToAction("Exercise1", "Practice");
            }

            return View("Index");
        }

        // GET: Tests/Test11
        [HttpGet("Test11")]
        public IActionResult Test11()
        {
            return View();
        }

        // GET: Tests/Test12
        [HttpGet("Test12")]
        public async Task<IActionResult> Test12()
        {
            return View();  // Return the view for Test12
        }

        // GET: Tests/Test13
        [HttpGet("Test13")]
        public IActionResult Test13()
        {
            return View();
        }

        // GET: Tests/Test14
        [HttpGet("Test14")]
        public IActionResult Test14()
        {
            return View();
        }

        // GET: Tests/Test21
        [HttpGet("Test21")]
        public IActionResult Test21()
        {
            return View();
        }

        // GET: Tests/Test22
        [HttpGet("Test22")]
        public IActionResult Test22()
        {
            return View();
        }

        // GET: Tests/Test23
        [HttpGet("Test23")]
        public IActionResult Test23()
        {
            return View();
        }

        // GET: Tests/Test24
        [HttpGet("Test24")]
        public IActionResult Test24()
        {
            return View();
        }

        // GET: Tests/Test31
        [HttpGet("Test31")]
        public IActionResult Test31()
        {
            return View();
        }

        // GET: Tests/Test32
        [HttpGet("Test32")]
        public IActionResult Test32()
        {
            return View();
        }

        // GET: Tests/Test33
        [HttpGet("Test33")]
        public IActionResult Test33()
        {
            return View();
        }

        // GET: Tests/Test34
        [HttpGet("Test34")]
        public IActionResult Test34()
        {
            return View();
        }
    }

    public class TestResultModel
    {
        public int TestId { get; set; }
        public float Score { get; set; }
        public string ElapsedTime { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Answer5 { get; set; }
        public int IsCorrect { get; set; }
    }

}