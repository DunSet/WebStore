using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.Data
{
    public static class TestData
    {
        public static List<Employee> Employees => new List<Employee>
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

        public static int ConnectionString(int x, int y) => x + y;
    }
}
