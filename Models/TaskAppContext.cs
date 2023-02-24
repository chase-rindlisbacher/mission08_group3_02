using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace mission08_group3_02.Models
{
    public class TaskAppContext : DbContext
    {
        public TaskAppContext(DbContextOptions<TaskAppContext> options) : base(options)
        {


        }
        public DbSet<TaskResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
                );


            mb.Entity<TaskResponse>().HasData(
            new TaskResponse
            {
                TaskId = 1,
                CategoryId = 1,
                Quadrant = 1,
                Task = "Clean Kitchen",
                DueDate = DateTime.ParseExact("10/12/1999","MM/dd/yyyy",null),
                Completed = false
            },
             new TaskResponse
             {
                 TaskId = 2,
                 CategoryId = 2,
                 Quadrant = 2,
                 Task = "Do Homework",
                 DueDate = DateTime.ParseExact("10/12/2000", "MM/dd/yyyy", null),
                 Completed = false
             },
              new TaskResponse
              {
                  TaskId = 3,
                  CategoryId = 3,
                  Quadrant = 3,
                  Task = "Talk to Boss",
                  DueDate = DateTime.ParseExact("10/12/2001", "MM/dd/yyyy", null),
                  Completed = false
              },
            new TaskResponse
            {
                TaskId = 4,
                CategoryId = 4,
                Quadrant = 4,
                Task = "Church",
                DueDate = DateTime.ParseExact("10/12/2002", "MM/dd/yyyy", null),
                Completed = false
            }


            );
        }

    }
}
