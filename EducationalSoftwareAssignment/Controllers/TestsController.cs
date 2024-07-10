using EducationalSoftwareAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


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

            var statistic = new Statistics
            {
                Test_Id = model.TestId,
                Grade = model.Score,
                Timer = model.ElapsedTime,
                Username = user.UserName
            };

            _context.Statistics.Add(statistic);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // GET: Tests/GetTestIdsWithGrade
        [HttpGet("testIds")]
        public async Task<IActionResult> GetTestIdsWithGrade(double grade = 2.5)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var testIds = await _context.Statistics
            .Where(s => s.Username == user.UserName && s.Grade == grade)
            .Select(s => s.Test_Id)
            .ToListAsync();

            return Ok(testIds);
        }

        // GET: Tests/Test11
        [HttpGet("Test11")]
        public IActionResult Test11()
        {
            return View();
        }

        // GET: Tests/Test12
        [HttpGet("Test12")]
        public IActionResult Test12()
        {
            return View();
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
    }

}