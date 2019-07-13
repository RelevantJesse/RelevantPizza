using Microsoft.AspNetCore.Mvc.Rendering;
using RelevantPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelevantPizza.ViewModels
{
    public class OrderItemAddViewModel
    {
        public OrderItemType Type { get; set; }
        public decimal Price { get; set; }
        public int InventoryID { get; set; }
        public InventoryItemType InventoryItemType { get; set; }
        public List<InventoryItem> OrderItemDetails { get; set; }

        public IEnumerable<SelectListItem> InventoryList { get; set; }

        public OrderItemAddViewModel()
        {
            OrderItemDetails = new List<InventoryItem>();
            InventoryList = new List<SelectListItem>();
        }
    }
}
