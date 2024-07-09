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
            new Test { Id = 1, Level = "Beginner" },
            new Test { Id = 2, Level = "Beginner" },
            new Test { Id = 3, Level = "Beginner" },
            new Test { Id = 4, Level = "Beginner" },
            new Test { Id = 5, Level = "Advanced" },
            new Test { Id = 6, Level = "Advanced" },
            new Test { Id = 7, Level = "Advanced" },
            new Test { Id = 8, Level = "Advanced" },
            new Test { Id = 9, Level = "Intermediate" },
            new Test { Id = 10, Level = "Intermediate" },
            new Test { Id = 11, Level = "Intermediate" },
            new Test { Id = 12, Level = "Intermediate" }
        );

            modelBuilder.Entity<Statistics>()
            .HasOne(s => s.Test)
            .WithMany()
            .HasForeignKey(s => s.Test_Id);
        }

    }
}
