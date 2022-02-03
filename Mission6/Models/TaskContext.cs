using System;
using Microsoft.EntityFrameworkCore;

namespace Mission6.Models
{
    public class TaskContext : DbContext
    {
        // constructor
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }

        public DbSet<TaskResponse> Responses { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // on Creating a model, seed these data in the database.
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Home"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "School"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Work"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Church"
                }
            );

            mb.Entity<TaskResponse>().HasData(
                new TaskResponse
                {
                    TaskId = 1,
                    Categoryid = 1,
                    TaskName = "Playing with my wife",
                    DueDate = "02/14/2022",
                    Quadrant = 1,
                    Completed = false,
                },
                new TaskResponse
                {
                    TaskId = 2,
                    Categoryid = 2,
                    TaskName = "Playing with my kid",
                    DueDate = "02/14/2022",
                    Quadrant = 2,
                    Completed = false,
                }
            );
        }
    }
}
