using techtshirt.Models;
using Microsoft.EntityFrameworkCore;


namespace techtshirt.Data
{
    public class techtshirtContext : DbContext

    {
        public techtshirtContext (DbContextOptions<techtshirtContext> options)
            : base(options)
        {

        }

        public DbSet<Inventory> Inventory { get; set; }

    }
}
