using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFProject.Data.Models
{
    public class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        //Table example. include Student model in your models folder
        public virtual DbSet<Student> Student { get; set; }
        //View example. include StudentClassroomView model in your models folder
        public virtual DbQuery<StudentClassroomView> StudentClassroomView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=db;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
            //add if you use views
            modelBuilder.Query<StudentClassroomView>().ToView("StudentClassroomView");
        }
    }
}
