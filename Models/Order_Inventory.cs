using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace techtshirt.Models
{
    // Inventory is configured via OnModelCreating
    public class Order_Inventory
    {
        public int id { get; set; }
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("inventory_id")]
        public int InventoryId { get; set; }
        public Order Order { get; set; }
        public Inventory Inventory { get; set; }
        [Display(Name = "Order Quantity")]
        public int order_qty { get; set; }
        [Display(Name = "Total Sale Price")]
        public decimal total_sale_price { get; set; }
    }
}
