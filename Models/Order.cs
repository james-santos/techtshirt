using System;

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
        public DateTime date_placed { get; set; }
        public DateTime date_shipped { get; set; }

        // customer relationship

        //invoice id
    }
}
