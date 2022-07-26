using Microsoft.AspNetCore.Mvc;
using MVC_Pratik_25_07.Entities.Concrete;
using MVC_Pratik_25_07.Repositories.Abstract;

namespace MVC_Pratik_25_07.Controllers
{
    public class LessonController : Controller
    {
        private readonly IRepository<Lesson> lessonRepository;

        public LessonController(IRepository<Lesson> lessonRepository)
        {
            this.lessonRepository = lessonRepository;
        }
        public IActionResult Index()
        {
            var lesson = lessonRepository.GetAll();
            return View(lesson);
        }

        public IActionResult Create()
        {
            Lesson lesson = new Lesson();
            return View(lesson);
        }

        [HttpPost]
        public IActionResult Create(Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                
                return View(lesson);
            }
            else
            {
                bool check;
                check = lessonRepository.Add(lesson);

                if (check) return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.Message = "Ders Eklenemedi.";
                }
                return View();
            }
           
        }
        //Get LEsson
        public IActionResult Update(int id)
        {
            Lesson lesson = lessonRepository.GetById(id);
            return View(lesson);
        }

        //Post:Lesson to Update
        [HttpPost]
        public IActionResult Update(Lesson lesson, int id)
        {
            bool check;
            lesson.Id = id;
            check = lessonRepository.Update(lesson);

            if (check) return RedirectToAction(nameof(Index));
            else
            {
                ViewBag.Message = "Ders Eklenemedi!!!";
                return View(lesson);
            }
        }
        public IActionResult Delete(int id)
        {
            Lesson lesson = lessonRepository.GetById(id);
            bool check;
            check = lessonRepository.Delete(lesson);
            if (check)
            {
                var lessons = lessonRepository.GetAll();
                return View("Index", lessons);
            }
            else
            {
                ViewBag.Message = "Ders Silinemez Öğrenciler var, Derssiz mu Kalsın!!!";
                var lessons = lessonRepository.GetAll();
                return View("Index", lessons);

            }

        }
    }
}
