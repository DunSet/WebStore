using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    //[Route("Staff")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;
        public EmployeesController(IEmployeesData EmployeesData)
        {
            _EmployeesData = EmployeesData;
        }

        private static readonly List<Employee> __Employees = TestData.Employees;
     
    //[Route("List")]
        public IActionResult Index() => View(_EmployeesData.Get());
      
    //[Route("{id}")]
        public IActionResult EmployeeDetails(int id)
        {
            var employee = _EmployeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }
    }
}
