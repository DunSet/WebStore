using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
{
   public interface IEmployeesData
    {
        IEnumerable<Employee> Get();//reading
        Employee GetById(int id);
        int Add(Employee Employee);
        void Edit(Employee employee);
        bool Delete(int id);
        void SaveChanges();
    }
}
