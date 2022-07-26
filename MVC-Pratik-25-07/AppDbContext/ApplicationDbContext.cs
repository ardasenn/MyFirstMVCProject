using Microsoft.EntityFrameworkCore;
using MVC_Pratik_25_07.Entities.Concrete;

namespace MVC_Pratik_25_07.AppDbContext
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) :base(options)
        {

        }

        public DbSet<Student>  Students{get; set;}
        public DbSet<Lesson> Lessons{get; set;}
        public DbSet<School> Schools{get; set;}
    }
}
