using Microsoft.AspNetCore.Mvc;
using Student.DataBase;
using Student.Models.Entities;

namespace Student.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext context;

        public StudentController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details()
        {
            string emailId = HomeController.email;
            string pass = HomeController.password;

            var student = context.students.Where(x => x.Email.Equals(emailId)).FirstOrDefault();
            if (student is not null)
            {
                if (student.Password.Equals(pass))
                {
                    return View(student);
                   
                }
            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = context.students.Find(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student1 s)
        {
            var student = context.students.Find(s.Id);

            student.Name = s.Name;
            student.Email = s.Email;
            student.Phone = s.Phone;
            student.Address = s.Address;
            student.Password = s.Password;
            student.Status = s.Status;

            context.SaveChanges();
            return RedirectToAction("Details", "Student");
        }
    }
}