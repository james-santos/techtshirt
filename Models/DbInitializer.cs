using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using techtshirt.Data;
namespace techtshirt.Models
{
    public static class DbInitializer
    {
        public static void Initialize(techtshirtContext context)
        {
            // context.Database.EnsureCreated();

            // Look for any Inventory.
            if (context.Inventory.Any())
            {
            return;   // DB has been seeded
            }

            context.Inventory.AddRange(
                    new Inventory
                    {
                        name = "Black Tech",
                        description = "Black T-Shirt",
                        size = "XL",
                        color = "violet",
                        on_hand_qty = 24,
                        cost = 2.99m,
                        sale_price =4.99m,
                        allocated_qty = 5,
                        total_qty = 32
                    },

                    new Inventory
                    {
                        name = "Red Tech",
                        description = "Red T-Shirt",
                        size = "S",
                        color = "red",
                        on_hand_qty = 2,
                        cost = 1.99m,
                        sale_price =3.99m,
                        allocated_qty = 2,
                        total_qty = 10
                    },

                    new Inventory
                    {
                        name = "Blue Tech",
                        description = "Blue T-Shirt",
                        size = "M",
                        color = "blue",
                        on_hand_qty = 44,
                        cost = 2.50m,
                        sale_price = 8.99m,
                        allocated_qty = 9,
                        total_qty = 80
                    }
                );

            // Look for any Customer.
            if (context.Customer.Any())
            {
                return;   // DB has been seeded
            }

            context.Customer.AddRange(
                    new Customer
                    {
                        first_name = "Jim",
                        last_name = "Santos",
                        type = "Individual",
                        address = "100000 Marsh St, San Luis Obispo, CA",
                        PhoneNumber = "(555) 555-5555",
                        company = "EDR"
                    },

                    new Customer
                    {
                        first_name = "Robin",
                        last_name = "Lee",
                        type = "Individual",
                        address = "100000 Higuera St, San Luis Obispo, CA",
                        PhoneNumber = "(555) 555-5555",
                        company = "FULLSTACK"
                    },

                    new Customer
                    {
                        first_name = "Dave",
                        last_name = "Simmons",
                        type = "Corporation",
                        address = "100000 Sunset Blvd, LA, CA",
                        PhoneNumber = "(555) 555-5555",
                        company = "LLC"
                    }
                );

            context.SaveChanges();
        }
    }
}
