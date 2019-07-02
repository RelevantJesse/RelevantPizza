using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelevantPizza.Models
{
    public enum Roles {
        Driver,
        Insider,
        Cashier,
        AssistantManager,
        Manager
    }

    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Roles Role { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
    }
}
