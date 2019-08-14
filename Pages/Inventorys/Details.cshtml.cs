using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using techtshirt.Data;
using techtshirt.Models;

namespace techtshirt.Pages.Inventorys
{
    public class DetailsModel : PageModel
    {
        private readonly techtshirt.Data.techtshirtContext _context;

        public DetailsModel(techtshirt.Data.techtshirtContext context)
        {
            _context = context;
        }

        public Inventory Inventory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inventory = await _context.Inventory.FirstOrDefaultAsync(m => m.id == id);

            if (Inventory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
