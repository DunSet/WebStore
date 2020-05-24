using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Employee> __Employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Surname = "Родионова",
                FirstName = "Алена",
                Patronimic = "Витальевна",
                Age = 21
            },
             new Employee
            {
                Id = 2,
                Surname = "Фельчер",
                FirstName = "Патрик",
                Patronimic = "Петрович",
                Age = 26
            },
              new Employee
            {
                Id = 3,
                Surname = "Незабудка",
                FirstName = "Михаил",
                Patronimic = "Олегович",
                Age = 45
            },
        };
       
        public IActionResult Index()
        {

            //ViewBag.Info = "Hello world";
            ViewData["Info"] = "Hello world!";
            return View(__Employees);
        }

        public IActionResult AnotherAction()
        {
            return Content("Another action result");
        }
    }
}
