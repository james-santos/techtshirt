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
                                      Value = a.id.ToString(),
                                      Text =  a.name
                                  }).ToListAsync();

            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }
        public Order_Inventory Order_Inventory { get; set; }

        public async Task<IActionResult> OnPostOrderAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var quantity = Order_Inventory.quantity;
            Console.WriteLine(quantity);
            Console.WriteLine("yoyo");

            _context.Order.Add(Order);
            // await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostInventoryAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var quantity = Order_Inventory.quantity;
            Console.WriteLine(quantity);
            Console.WriteLine("yoyo");

            // _context.Order.Add(Order);
            // await _context.SaveChangesAsync();

            return RedirectToPage("");
        }


    }
}
