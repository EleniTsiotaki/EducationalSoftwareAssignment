using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EducationalSoftwareAssignment.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _configuration;
        public DbSet<Test> Tests { get; set; }
        public DbSet<Statistics> Statistics { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Test>().HasData(
            new Test { Id = 1, Level = "Beginner", IsUnlocked = false},
            new Test { Id = 2, Level = "Beginner", IsUnlocked = false },
            new Test { Id = 3, Level = "Beginner", IsUnlocked = false },
            new Test { Id = 4, Level = "Beginner", IsUnlocked = false },
            new Test { Id = 5, Level = "Intermediate", IsUnlocked = false },
            new Test { Id = 6, Level = "Intermediate", IsUnlocked = false },
            new Test { Id = 7, Level = "Intermediate", IsUnlocked = false },
            new Test { Id = 8, Level = "Intermediate", IsUnlocked = false },
            new Test { Id = 9, Level = "Advanced", IsUnlocked = false },
            new Test { Id = 10, Level = "Advanced", IsUnlocked = false },
            new Test { Id = 11, Level = "Advanced", IsUnlocked = false },
            new Test { Id = 12, Level = "Advanced", IsUnlocked = false }
        );

            modelBuilder.Entity<Statistics>()
            .HasOne(s => s.Test)
            .WithMany()
            .HasForeignKey(s => s.Test_Id);
        }

    }
}
