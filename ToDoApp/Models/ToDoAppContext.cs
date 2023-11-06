using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ToDoApp.Models;


namespace ToDoApp.Models{
    public class ToDoAppContext : DbContext{
        public ToDoAppContext(DbContextOptions<ToDoAppContext> options) : base(options){ }

        public ToDoAppContext(){}

        public virtual DbSet<ToDo> ToDos {get; set;} = null!;
        public virtual DbSet<Category> Categories {get; set;} = null!;

        public virtual DbSet<Status> Statuses {get; set;} = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<Category>().HasData(
            new Category {CategoryId = "work", Name="Work"},
            new Category {CategoryId = "home", Name="Home"},
            new Category {CategoryId = "exercise", Name="Exercise"}
            );

            modelBuilder.Entity<Status>().HasData(
            new Status {StatusId="open", Name="Open"},
            new Status {StatusId="closed", Name="Completed"}
            );

        }

    }
}