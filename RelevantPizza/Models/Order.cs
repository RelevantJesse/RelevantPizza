using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelevantPizza.Models
{    
    public enum OrderType
    {
        CarryOut,
        Delivery
    }
    public class Order
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }
        public OrderType OrderType { get; set; }
        public Employee Driver { get; set; }
        public DateTime DriverOut { get; set; }
        public DateTime DriverIn { get; set; }
        IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
