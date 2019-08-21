using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace techtshirt.Models
{
    // Inventory is configured via OnModelCreating
    public class Inventory
    {
        public int id { get; set; }
        [Display(Name = "Item Name")]
        public string name { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Size")]
        public string size { get; set; }
        [Display(Name = "Color")]
        public string color { get; set; }
        [Display(Name = "On Hand Quantity")]
        public int on_hand_qty { get; set; }
        [Display(Name = "Cost")]
        public decimal cost { get; set; }
        [Display(Name = "Sale Price")]
        public decimal sale_price { get; set; }
        [Display(Name = "Allocated Quantity")]
        public int allocated_qty { get; set; }
        [Display(Name = "Total Quantity")]
        public int total_qty { get; set; }

        public ICollection<Order_Inventory> Order_Inventory { get; set; }
    }
}
