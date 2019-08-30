using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using techtshirt.Data;
using techtshirt.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Newtonsoft.Json;

namespace techtshirt.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly techtshirt.Data.techtshirtContext _context;

        public CreateModel(techtshirt.Data.techtshirtContext context)
        {
            _context = context;
        }

        // this task provides the list of customers for the dropdown select list
        public List<SelectListItem> Options { get; set; }
        public List<SelectListItem> InvOptions { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            // creates select options drop down razor pages way
            Options = await _context.Customer.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.id.ToString(),
                                      Text =  a.first_name + " " + a.last_name
                                  }).ToListAsync();

            InvOptions = await _context.Inventory.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.id.ToString() + "|" + a.cost,
                                      Text =  a.name
                                  }).ToListAsync();

            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        [BindProperty]
        public Order_Inventory Order_Inventory { get; set; }

        // most likely push all orderinv in this method when creating order button clicked
        // this is an Ajax only post request not model binding
        public async Task<IActionResult> OnPostOrderAsync()
        {
            // if (!ModelState.IsValid)
            // {
            //     return Page();
            // }

            // this block will read the json data from ajax
            {
                MemoryStream stream = new MemoryStream();
                Request.Body.CopyTo(stream);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    string requestBody = reader.ReadToEnd();
                    if(requestBody.Length > 0)
                    {
                        Console.WriteLine(requestBody);
                        var obj = JsonConvert.DeserializeObject<RootObject>(requestBody);
                        if(obj != null)
                        {
                                // inilize order object once here
                                Order.total_sale_price = obj.order.total_sale_price;
                                Order.status = "Approved";
                                Order.total_pieces = obj.order.total_pieces;
                                Order.reference_code = obj.order.reference_code;
                                Order.date_placed = obj.order.date_placed;
                                Order.date_shipped = obj.order.date_shipped;
                                Order.customer_id = obj.order.customer_id;
                                var curCustomer = _context.Customer.Find(Order.customer_id);

                                Console.WriteLine(curCustomer);
                                Console.WriteLine(curCustomer.first_name);
                                // create order
                                Order.customer_id = curCustomer.id;
                                Order.Customer = curCustomer;
                                _context.Order.Add(Order);
                                await _context.SaveChangesAsync();

                            foreach(InventoryDto dto in obj.data)
                            {
                                // Order_Inventory.OrderId = Order.id;
                                // Order_Inventory.InventoryId = dto.invId;
                                // Order_Inventory.order_qty = dto.quantity;
                                // Order_Inventory.total_sale_price = dto.itemtotal;
                                var curOrder = _context.Order.Find(Order.id);
                                var curInventory = _context.Inventory.Find(dto.invId);

                                _context.Order_Inventory.Add(new Order_Inventory{
                                                                OrderId = Order.id,
                                                                Order = curOrder,
                                                                InventoryId = dto.invId,
                                                                Inventory = curInventory,
                                                                order_qty = dto.quantity,
                                                                total_sale_price = dto.itemtotal});

                            }

                        }
                        // await _context.SaveChangesAsync();
                    }
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        // data transfer object of the json from ajax order post
        public class InventoryDto
        {
            public int invId {get; set;}
            public string product { get; set; }
            public int quantity { get; set; }
            public decimal itemtotal { get; set; }
        }

        public class RootObject
        {
            public List<InventoryDto> data { get; set; }
            public Order order { get; set;}
        }


    }
}
