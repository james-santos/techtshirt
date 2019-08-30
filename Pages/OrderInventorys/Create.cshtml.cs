using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using techtshirt.Data;
using techtshirt.Models;

namespace techtshirt.Pages.OrderInventorys
{
    public class CreateModel : PageModel
    {
        private readonly techtshirt.Data.techtshirtContext _context;

        public CreateModel(techtshirt.Data.techtshirtContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InventoryId"] = new SelectList(_context.Inventory, "id", "id");
        ViewData["OrderId"] = new SelectList(_context.Order, "id", "id");
            return Page();
        }

        [BindProperty]
        public Order_Inventory Order_Inventory { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order_Inventory.Add(Order_Inventory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
