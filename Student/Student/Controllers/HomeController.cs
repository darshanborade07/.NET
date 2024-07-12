using Microsoft.AspNetCore.Mvc;
using Student.DataBase;
using Student.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Student.Controllers
{
    public class HomeController : Controller
    {
        public static string email;
        public static string password;
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email,string Password)
        {
            email = Email;
            password = Password;
            var student = context.students.ToList();

            foreach (var s in student)
            {
                if (s.Email.Equals(Email) && s.Password.Equals(Password)) 
                {
                    if (s.Role.Equals("Admin")) 
                    {
                        return RedirectToAction("Index","Admin");
                    }
                    return RedirectToAction("Index","Student");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
