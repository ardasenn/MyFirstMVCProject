using Microsoft.AspNetCore.Mvc;
using MVC_Pratik_25_07.Entities.Concrete;
using MVC_Pratik_25_07.Repositories.Abstract;

namespace MVC_Pratik_25_07.Controllers
{
    public class SchoolController : Controller
    {
        private readonly IRepository<School> schoolRepository;
        private readonly IRepository<Lesson> lessonRepository;

        public SchoolController(IRepository<School> schoolRepository, IRepository<Lesson> lessonRepository)
        {
            this.schoolRepository = schoolRepository;
            this.lessonRepository = lessonRepository;
        }
        public IActionResult Index()
        {
            var schools = schoolRepository.GetAll();
            return View(schools);
        }

        //Sschool/Create
        public IActionResult Create()
        {
            School school = new School();
            return View(school);       
        }
        [HttpPost]
        public IActionResult Create(School school)
        {
            if (!ModelState.IsValid)
            {
                var schools = schoolRepository.GetAll(); 
                return View(schools);
            }
            else
            {

            bool check;        

            check = schoolRepository.Add(school);

            if (check) return RedirectToAction(nameof(Index));
            else
            {
                ViewBag.Message = "Okul Eklenemedi!!!";

            }
            return View();
            }
        }

        //Get School
        public IActionResult Update(int id)
        {
            School school = schoolRepository.GetById(id);
            return View(school);
        }


        //Post:School to Update
        [HttpPost]
        public IActionResult Update(School school, int id)
        {
            bool check;
            school.Id = id;
            check = schoolRepository.Update(school);

            if (check) return RedirectToAction(nameof(Index));
            else
            {
                ViewBag.Message = "Öğrenci Eklenemedi!!!";
                return View(school);
            }
        }
        
        // Delete
        public IActionResult Delete(int id)
        {
            School school = schoolRepository.GetById(id);
            bool check;
            check = schoolRepository.Delete(school);
            if (check)
            {
                var schools = schoolRepository.GetAll();
                return View("Index", schools);
            }
            else
            {
                ViewBag.Message = "Okul Silinemez Öğrenciler var, Okulsuz mu Kalsın!!!";
                var schools = schoolRepository.GetAll();
                return View("Index", schools);

            }

        }
    }
}
