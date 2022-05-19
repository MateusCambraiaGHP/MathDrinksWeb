using MathDrinks.Models;
using Microsoft.EntityFrameworkCore;

namespace MathDrinks.Interfaces
{
    public interface IApplicationMySqlDbContext
    {
        public DbSet<Supplier_Product> Supplier_Product { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public int Save();
    }
}
