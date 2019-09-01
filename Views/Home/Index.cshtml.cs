using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using techtshirt.Data;
using techtshirt.Models;

namespace techtshirt.Views.Home
{
    public class IndexModel : PageModel
    {
        private readonly techtshirt.Data.techtshirtContext _context;

        public IndexModel(techtshirt.Data.techtshirtContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Order.AsNoTracking()
                                        .ToListAsync();
        }
    }
}
