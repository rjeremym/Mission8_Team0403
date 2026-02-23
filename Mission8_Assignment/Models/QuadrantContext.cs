using Microsoft.EntityFrameworkCore;
namespace Mission8_Assignment.Models
{
    public class QuadrantContext : DbContext
    {
        public QuadrantContext(DbContextOptions<QuadrantContext> options) : base(options)
        {
        }

        public DbSet<Quadrant> Quadrants { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Work" },
                new Category { CategoryId = 2, CategoryName = "Personal" },
                new Category { CategoryId = 3, CategoryName = "Health" }
            );

            modelBuilder.Entity<Quadrant>().HasData(
                new Quadrant { TaskId = 1, task = "Finish report", dueDate = "2026-03-01", quadrant = 1, CategoryId = 1, completed = false },
                new Quadrant { TaskId = 2, task = "Call doctor", dueDate = "2026-03-05", quadrant = 2, CategoryId = 3, completed = false },
                new Quadrant { TaskId = 3, task = "Buy groceries", dueDate = "2026-02-25", quadrant = 3, CategoryId = 2, completed = true }
            );
        }
    }
}