﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.ViewModel;

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

        #region Редактирование

        public IActionResult Edit(int? Id) //редактирование
        {
            if (Id is null) return View(new EmployeeViewModel());

            if (Id < 0)
                return BadRequest();

            var employee = _EmployeesData.GetById((int) Id);
            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel
            { 
                Id = employee.Id,
                Surname = employee.Surname,
                Name = employee.FirstName,
                Patronimic = employee.Patronimic,
                Age = employee.Age

            
            });
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel Model) // редирект после редактирвоаиня
        {
            if (Model is null)
                throw new ArgumentNullException(nameof(Model));


            var employee = new Employee
            {
                Id = Model.Id,
                FirstName = Model.Name,
                Surname = Model.Surname,
                Patronimic = Model.Patronimic,
                Age = Model.Age
            };
            if (Model.Id == 0)
                _EmployeesData.Add(employee);
            else
                _EmployeesData.Edit(employee);

            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion

        #region удаление
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var employee = _EmployeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Surname = employee.Surname,
                Name = employee.FirstName,
                Patronimic = employee.Patronimic,
                Age = employee.Age
            });
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _EmployeesData.Delete(id);
            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion
    }
}
