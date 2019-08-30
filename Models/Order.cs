using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace techtshirt.Models
{
    // Inventory is configured via OnModelCreating
    public class Order
    {
        public int id { get; set; }
        public string status { get; set; }
        public decimal total_sale_price { get; set; }
        public int total_pieces { get; set; }
        public string reference_code { get; set; }
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date_placed { get; set; }

        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date_shipped { get; set; }
        public int customer_id { get; set; }
        [ForeignKey("customer_id")]
        public Customer Customer { get; set; }

        public ICollection<Order_Inventory> Order_Inventory { get; set; }

    }
}
