using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using techtshirt.Data;
using techtshirt.Models;

namespace techtshirt.Pages.OrderInventorys
{
    public class DeleteModel : PageModel
    {
        private readonly techtshirt.Data.techtshirtContext _context;

        public DeleteModel(techtshirt.Data.techtshirtContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order_Inventory = await _context.Order_Inventory.FindAsync(id);

            if (Order_Inventory != null)
            {
                _context.Order_Inventory.Remove(Order_Inventory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
