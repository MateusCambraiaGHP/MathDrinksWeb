using MathDrinks.Models;
using Microsoft.EntityFrameworkCore;

namespace MathDrinks.Interfaces
{
    public interface IApplicationMySqlDbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public int Save();
    }
}
