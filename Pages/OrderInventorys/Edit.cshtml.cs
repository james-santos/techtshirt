using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using techtshirt.Data;
using techtshirt.Models;

namespace techtshirt.Pages.OrderInventorys
{
    public class EditModel : PageModel
    {
        private readonly techtshirt.Data.techtshirtContext _context;

        public EditModel(techtshirt.Data.techtshirtContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order_Inventory Order_Inventory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order_Inventory = await _context.Order_Inventory
                .Include(o => o.Inventory)
                .Include(o => o.Order).FirstOrDefaultAsync(m => m.id == id);

            if (Order_Inventory == null)
            {
                return NotFound();
            }
           ViewData["InventoryId"] = new SelectList(_context.Inventory, "id", "id");
           ViewData["OrderId"] = new SelectList(_context.Order, "id", "id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Order_Inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order_InventoryExists(Order_Inventory.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Order_InventoryExists(int id)
        {
            return _context.Order_Inventory.Any(e => e.id == id);
        }
    }
}
