using DatabaseActivities.Models.Entity;
using DatabaseActivities.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseActivities.Controllers
{
    public class StudentController : Controller
    {
        private StudentService service = new StudentService();
        public ActionResult Index()
        {
            return View(service.GetAllStudents());
        }
        public ActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StudentCreation(StudentModel student)
        {
            service.AddStudent(student);
            return RedirectToAction("Index", service.GetAllStudents());
        }
        public ActionResult EditStudent(int id)
        {
            StudentModel StudentToEdit = service.GetStudentById(id);
            if (StudentToEdit == null)
            {
                return HttpNotFound();
            }
            return View(StudentToEdit);
        }
        [HttpPost]
        public ActionResult StudentEdit(StudentModel student, int  IdTP)
        {
            student.Id = IdTP;
            service.EditStuent(student);
            return RedirectToAction("EditStudent", "Soldier", new { id = student.Id});
        }
    }
}