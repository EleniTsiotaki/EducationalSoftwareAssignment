using EducationalSoftwareAssignment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EducationalSoftwareAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        public IActionResult Progress(Progress model)
        {
           var username = User.Identity.Name;

            
            // Retrieve or create progress record for the current user
            var progress = _context.Progress
                .FirstOrDefault(p => p.Username == username);

            // Retrieve statistics for the current user
            var userStats = _context.Statistics
            .Where(s => s.Username == username)
            .GroupBy(s => s.Test_Id) // Group by TestId to handle multiple attempts
            .Select(g => g
                .OrderByDescending(s => s.Grade) // Highest grade first
                .ThenBy(s => s.Timer) // Smallest time if grades are the same
                .FirstOrDefault())
            .ToList();

            if (userStats.Count == 0)
            {
                progress = new Progress
                {
                    Username = username,
                    TotalGrade = 0,
                    AverageGrade = 0,
                    SucceededTests = 0,
                    FailedTests = 0,
                    BeginnerTests = 0,
                    IntermediateTests = 0,
                    AdvancedTests = 0,
                    BeginnerAverage = 0,
                    IntermediateAverage = 0,
                    AdvancedAverage = 0,
                    TotalTime = 0,
                    DateTime = DateTime.Now
                };
                _context.Progress.Add(progress);
                _context.SaveChanges(); // Save changes to the progress record
                                        // Handle case where no statistics are found (optional)
                                        // You might want to return a different view or handle this differently
                return View(progress); // Example redirection
            }

            var userStatsWithLevel = userStats
                .Join(_context.Tests,
                      stat => stat.Test_Id,
                      test => test.Id,
                      (stat, test) => new
                      {
                          TestId = stat.Test_Id,
                          Grade = stat.Grade,
                          Level = test.Level
                          // Add more properties from Tests table as needed
                      })
                .ToList();

            // Calculate total grade, tests taken, and average grade
            float totalGrade = userStats.Sum(s => s.Grade );
            int testsTaken = userStats.Count;
            decimal averageGrade = testsTaken > 0 ? (decimal)totalGrade / testsTaken : 0;
            int beginnerTests = userStatsWithLevel.Where(s => s.Level == "Beginner").Any() ? userStatsWithLevel.Count(s => s.Level == "Beginner") : 0;
            int intermediateTests = userStatsWithLevel.Where(s => s.Level == "Intermediate").Any() ? userStatsWithLevel.Count(s => s.Level == "Intermediate") : 0;
            int advancedTests = userStatsWithLevel.Where(s => s.Level == "Advanced").Any() ? userStatsWithLevel.Count(s => s.Level == "Advanced") : 0;
            double beginnerAverage = userStatsWithLevel.Where(s => s.Level == "Beginner").Any() ? userStatsWithLevel.Where(s => s.Level == "Beginner").Average(s => s.Grade) : 0;
            double intermediateAverage = userStatsWithLevel.Where(s => s.Level == "Intermediate").Any() ? userStatsWithLevel.Where(s => s.Level == "Intermediate").Average(s => s.Grade) : 0;
            double advancedAverage = userStatsWithLevel.Where(s => s.Level == "Advanced").Any() ? userStatsWithLevel.Where(s => s.Level == "Advanced").Average(s => s.Grade) : 0;
            var succeededTests = userStats.Count(s => s.IsCorrect == 1);
            var failedTests = userStats.Count(s => s.IsCorrect == 0);
            double time = 0;

            //double time = userStats.Sum(s => double.Parse(s.Timer));


            if (progress == null)
            {
                progress = new Progress
                {
                    Username = username,
                    TotalGrade = totalGrade,
                    AverageGrade = averageGrade,
                    SucceededTests = succeededTests,
                    FailedTests = failedTests,
                    TotalTime = time,
                    BeginnerTests = beginnerTests,
                    IntermediateTests = intermediateTests,
                    AdvancedTests = advancedTests,
                    BeginnerAverage = beginnerAverage,
                    IntermediateAverage = intermediateAverage,
                    AdvancedAverage = advancedAverage,
                    DateTime = DateTime.Now
                };

                _context.Progress.Add(progress);
            }
            else
            {
                progress.TotalGrade = totalGrade;
                progress.AverageGrade = averageGrade;
                progress.SucceededTests = succeededTests;
                progress.FailedTests = failedTests;
                progress.TotalTime = time;
                progress.IntermediateTests = intermediateTests;
                progress.AdvancedTests = advancedTests;
                progress.BeginnerTests = beginnerTests;
                progress.BeginnerAverage = beginnerAverage;
                progress.IntermediateTests = intermediateTests;
                progress.AdvancedTests = advancedTests;
                progress.DateTime = DateTime.Now;

                _context.Progress.Update(progress);
            }

            _context.SaveChanges(); // Save changes to the progress record

            return View(progress);
        }


    }
}