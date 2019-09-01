using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using techtshirt.Data;
using techtshirt.Models;

namespace techtshirt.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly techtshirt.Data.techtshirtContext _context;

        public IndexModel(techtshirt.Data.techtshirtContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }
        public IList<Order> PrevOrders { get;set; }
        public IList<Order_Inventory> Order_Inventory { get;set; }
         public IList<Inventory> Inventory { get;set; }

        public async Task OnGetAsync()
        {

            var firstDay = DateTime.Today.AddDays(-30);

            PrevOrders = await _context.Order.Where(x => x.date_placed >= firstDay).Include(x => x.Customer).ToListAsync();
            // Order = await _context.Order.AsNoTracking()
            //                             .ToListAsync();
            Order_Inventory = await _context.Order_Inventory
                .Include(o => o.Inventory)
                .Include(o => o.Order).ToListAsync();



        Inventory = await _context.Inventory.ToListAsync();
        }
    }
}
