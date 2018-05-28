using ApplyStudent.Service.ModelsDTO;
using ApplyStudent.Service.Services;
using ApplyStudent.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplyStudent.WebApplication.Controllers
{
    public class StudentController : Controller
    {
        IStudentService StudentService;
        public StudentController(IStudentService studentService)
        {
            StudentService = studentService;
        }
        // GET: Student
        public ActionResult Index()
        {
            var students = StudentService.GetStudents();
            return View(students);
        }
        [HttpGet]
        public ActionResult New()
        {
            var vm = new StudentViewModel();
            return View(vm);
        }
        [HttpPost]
        public ActionResult New(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                var studentDTO = new StudentDTO()
                {
                    Email = student.Email,
                    Name = student.Name,
                    Surname = student.Surname,
                    Password = student.Password
                };
                StudentService.AddStudent(studentDTO);
                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }
        }
    }
}