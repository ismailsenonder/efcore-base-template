using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

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

        //Table sample. include Foo model in your models folder.
        public virtual DbSet<Foo> Foo { get; set; }

        //For models that doesn't exist in your database as it is
        //but retrieved with an SQL query or SP.
        //include FooFromQuery model in your models folder.
        //this is how you can use in your repository:
        //dbContext.FooFromQuery.FromSqlRaw("SELECT Foo1, Foo2 FROM FooTable").ToList();
        [NotMapped]
        public virtual DbSet<FooFromQuery> FooFromQuery { get; set; }

        //View sample. Include FooView model in your models folder
        public virtual DbQuery<FooView> FooView { get; set; }

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
            modelBuilder.Query<FooView>().HasNoKey().ToView("FooView");

            //add if you use notmapped models
            modelBuilder.Entity<FooFromQuery>().HasNoKey();

        }
    }
}
