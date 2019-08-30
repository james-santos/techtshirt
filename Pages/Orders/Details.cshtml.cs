using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using techtshirt.Data;
using techtshirt.Models;


namespace techtshirt.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly techtshirt.Data.techtshirtContext _context;

        public DetailsModel(techtshirt.Data.techtshirtContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }
        public Order_Inventory Order_Inventory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Order = await _context.Order.FirstOrDefaultAsync(m => m.id == id);
            Order = _context.Order.Include(c => c.Customer)
                                    .Include(c => c.Order_Inventory)
                                        .ThenInclude(c => c.Inventory)
                                    .SingleOrDefault(m => m.id == id);
                                        // .ToListAsync();

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
