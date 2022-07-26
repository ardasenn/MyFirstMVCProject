using Microsoft.EntityFrameworkCore;
using MVC_Pratik_25_07.AppDbContext;
using MVC_Pratik_25_07.Entities.Concrete;
using MVC_Pratik_25_07.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Pratik_25_07.Repositories.Concrete
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext db;

        public StudentRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;

        }
        public IEnumerable<Student> GetAllIncludeSchools()
        {
            return db.Students.Include(s => s.School).Include(s => s.Lessons);

        }
        public Student GetByIdIncludeSchool(int id)
        {
            return db.Students.Include(s => s.School).FirstOrDefault(a => a.Id == id);
        }


    }
}
