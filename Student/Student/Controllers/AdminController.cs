using Microsoft.AspNetCore.Mvc;
using Student.DataBase;
using Student.Models.Entities;

namespace Student.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext context;

        public AdminController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student1 s) 
        {
            var student = new Student1
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                Address = s.Address,
                Date = s.Date,
                Status = s.Status,
                Password = s.Password,
                Role = s.Role
            };
            context.students.Add(student);
            context.SaveChanges();
            return View("Index");
        }

        [HttpGet]
        public IActionResult List() 
        {
            var student = context.students.ToList();
            // return View(student);
            return Json(student);
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
            if(s is not null)
            {
                student.Name = s.Name;
                student.Email = s.Email;
                student.Phone = s.Phone;
                student.Address = s.Address;
                student.Date = s.Date;
                student.Status = s.Status;
                student.Password = s.Password;

                context.SaveChanges();
            }

            return RedirectToAction("List", "Admin");
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var student = context.students.Find(id);
            context.students.Remove(student);
            context.SaveChanges();
            return RedirectToAction("List", "Admin");
        }

        [HttpGet]
        public IActionResult Search()
        {
            var student = context.students.ToList();
            return View(student);
        }
        [HttpGet]
        public IActionResult Sort()
        {
            var student = context.students.OrderBy(x => x.Name).ToList();
            return View(student);
        }
    }
}
