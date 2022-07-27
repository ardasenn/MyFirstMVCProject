using Microsoft.AspNetCore.Mvc;
using MVC_Pratik_25_07.Entities.Concrete;
using MVC_Pratik_25_07.Models;
using MVC_Pratik_25_07.Repositories.Abstract;
using System.Linq;

namespace MVC_Pratik_25_07.Controllers
{
    public class StudentController : Controller
    {
      
        private readonly IStudentRepository studentRepository;
        private readonly IRepository<School> schoolRepository;
        private readonly IRepository<Lesson> lessonRepository;

        public StudentController(IStudentRepository studentRepository, IRepository<School> schoolRepository, IRepository<Lesson> lessonRepository)
        {
            this.studentRepository = studentRepository;
            this.schoolRepository = schoolRepository;
           this.lessonRepository = lessonRepository;
        }
        // public IActionResult Index()
        // {
        //     var students = studentRepository.GetAllIncludeSchools();
        //     return View(students);
        // }
        ////Students:Create
        //public IActionResult Create()
        //{
        //    StudentWithSchoolsVM studentWithSchoolsVM = new StudentWithSchoolsVM();
        //    studentWithSchoolsVM.Schools = schoolRepository.GetAll();
        //    return View(studentWithSchoolsVM);
        //}
        //Student post
        //[HttpPost]
        //public IActionResult Create(StudentWithSchoolsVM studentWithSchoolsVM)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        studentWithSchoolsVM.Schools = schoolRepository.GetAll();
        //        return View(studentWithSchoolsVM);
        //    }
        //    else
        //    {
        //        bool check;
        //        check = studentRepository.Add(studentWithSchoolsVM.Student);
        //        if (check) return RedirectToAction(nameof(Index));
        //        else
        //        {
        //            ViewBag.Message = "Öğrenci Eklenemedi!!!";
        //            studentWithSchoolsVM.Schools = schoolRepository.GetAll();
        //            return View(studentWithSchoolsVM);
        //        }

        //    }
        //}
        //public IActionResult Update(int id)
        //{
        //    StudentWithSchoolsVM studentWithSchoolsVM = new StudentWithSchoolsVM();
        //    studentWithSchoolsVM.Student = studentRepository.GetWhere(a => a.Id == id).FirstOrDefault();
        //    studentWithSchoolsVM.Schools = schoolRepository.GetAll();
        //    return View(studentWithSchoolsVM);

        //}

        //Post:Student to Update
        //[HttpPost]
        //public IActionResult Update(StudentWithSchoolsVM studentWithSchools, int id)
        //{
        //    bool check;
        //    studentWithSchools.Student.Id = id;
        //    check = studentRepository.Update(studentWithSchools.Student);

        //    if (check) return RedirectToAction(nameof(Index));
        //    else
        //    {
        //        ViewBag.Message = "Öğrenci Eklenemedi!!!";
        //        studentWithSchools.Schools = schoolRepository.GetAll();
        //        return View(studentWithSchools);
        //    }
        //}
        ////Get School and lesson
        //public IActionResult AddLesson(int id)
        //{
        //    StudentWithSchoolsVM studentWithSchoolsVM = new StudentWithSchoolsVM();
        //    studentWithSchoolsVM.Student = studentRepository.GetById(id);
        //    studentWithSchoolsVM.Lessons = lessonRepository.GetAll();
        //    return View(studentWithSchoolsVM);
        //}

        //[HttpPost]
        //public IActionResult AddLesson(StudentWithSchoolsVM studentWithSchoolsVM, int id)
        //{
        //    bool check;
        //    studentWithSchoolsVM.Student = studentRepository.GetById(id);
        //    Lesson lesson = lessonRepository.GetById(studentWithSchoolsVM.LessonID);
        //    studentWithSchoolsVM.Student.Lessons.Add(lesson);
        //    check = studentRepository.Update(studentWithSchoolsVM.Student);
        //    if (check) return RedirectToAction(nameof(Index));
        //    else
        //    {
        //        ViewBag.Message = "Ders Eklenemedi!!!";

        //    }
        //    return View();

        //}

        public IActionResult Delete(int id)
        {
            Student student = studentRepository.GetById(id);
            bool check=studentRepository.Delete(student);
            if (check) return Json("Ok");
            else return Json("hata");
        }

        public IActionResult Index()
        { 
            return View();
        }
        public IActionResult GetListPartial()
        {
            var students = studentRepository.GetAllIncludeSchools();
            return PartialView("_GetListPartial", students);
        }

        public IActionResult CreatePartial()
        {
            StudentWithSchoolsVM studentWithSchoolsVM = new StudentWithSchoolsVM();
            studentWithSchoolsVM.Schools = schoolRepository.GetAll();
            return PartialView("_CreatePartial",studentWithSchoolsVM);            
        }
        public IActionResult AddStudentAJ(Student student)
        {
            bool check;
            if (ModelState.IsValid)
            {
                check = studentRepository.Add(student);
                if (check) return Json("Ok");
            }           
            else
            {
                ViewBag.Message = "Ders Eklenemedi!!!";
            }
            return Json("hata");
        }
        public IActionResult UpdatePartial(int id)
        {
            StudentWithSchoolsVM studentWithSchoolsVM = new StudentWithSchoolsVM();
           studentWithSchoolsVM.Student = studentRepository.GetWhere(a => a.Id == id).FirstOrDefault();            
            studentWithSchoolsVM.Schools = schoolRepository.GetAll();
            return PartialView("_UpdatePartial", studentWithSchoolsVM);
        }

        public IActionResult UpdateStudentAJ(Student student)
        {
            bool check;
            if (ModelState.IsValid)
            {                 
                check = studentRepository.Update(student);
                if (check) return Json("Ok");
            }
            else
            {
                ViewBag.Message = "Ders Eklenemedi!!!";
            }
            return Json("hata");
        }

        public IActionResult AddLessonPartial(int id)
        {
            StudentWithSchoolsVM studentWithSchoolsVM = new StudentWithSchoolsVM();
            studentWithSchoolsVM.Student = studentRepository.GetById(id);
            studentWithSchoolsVM.Lessons = lessonRepository.GetAll();
            return PartialView("_AddLessonPartial", studentWithSchoolsVM);
        }

        
        public IActionResult AddLesson(StudentWithSchoolsVM studentWithSchoolsVM, int id)
        {
            bool check;
            studentWithSchoolsVM.Student = studentRepository.GetById(id);
            Lesson lesson = lessonRepository.GetById(studentWithSchoolsVM.LessonID);
            studentWithSchoolsVM.Student.Lessons.Add(lesson);
            check = studentRepository.Update(studentWithSchoolsVM.Student);
            if (check) return Json("Ok");
            else
            {
                ViewBag.Message = "Ders Eklenemedi!!!";

            }
            return Json("hata");

        }


    }
}

