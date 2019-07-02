using RelevantPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelevantPizza.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PizzaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return;
            }

            Employee[] employees = new Employee[]
            {
                new Employee{FirstName = "Jesse", LastName = "Prescott", PhoneNumber="123-123-1234", Role=Roles.Manager, Salary=100000M},
                new Employee{FirstName = "Jim", LastName = "Smith", PhoneNumber="123-123-1234", Role=Roles.AssistantManager, Salary=40000M},
                new Employee{FirstName = "Bob", LastName = "Anderson", PhoneNumber="123-123-1234", Role=Roles.Cashier, Salary=10000M}
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
