using MVC_Pratik_25_07.Entities.Concrete;
using System.Collections.Generic;

namespace MVC_Pratik_25_07.Repositories.Abstract
{
  
    
        public interface IStudentRepository : IRepository<Student>
        {
            IEnumerable<Student> GetAllIncludeSchools();
            Student GetByIdIncludeSchool(int id);

        }

       
   
}
