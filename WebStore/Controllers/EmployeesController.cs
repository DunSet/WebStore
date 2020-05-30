using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private static readonly List<Employee> __Employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Surname = "Родионова",
                FirstName = "Алёна",
                Patronimic = "Валерьевна",
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
        public IActionResult Index() => View(__Employees);
      

        public IActionResult EmployeeDetails(int id)
        {
            var employee = __Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }
    }
}
