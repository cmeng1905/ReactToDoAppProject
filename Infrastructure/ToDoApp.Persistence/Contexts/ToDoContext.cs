using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entites;

namespace ToDoApp.Persistence.Contexts
{
    public class ToDoContext : DbContext
    {
        //Add-Migration TodoAppDb
        //Update-Database
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Work", Description = "Tasks related to work" },
                new Category { Id = 2, Name = "Personal", Description = "Personal tasks and errands" },
                new Category { Id = 3, Name = "Shopping", Description = "Shopping list and related tasks" },
                new Category { Id = 4, Name = "Others", Description = "Other tasks" }
            );
        }
    }
}
