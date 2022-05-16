using MathDrinks.Interfaces;
using MathDrinks.Models;
using Microsoft.EntityFrameworkCore;

namespace MathDrinks.Data
{
    public class ApplicationMySqlDbContext : DbContext, IApplicationMySqlDbContext
    {
        public IConfiguration _configuration { get; set; }

        public ApplicationMySqlDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"),
                      ServerVersion.AutoDetect(_configuration.GetConnectionString("DefaultConnection")));
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        public int Save() 
        {
            return SaveChanges();
        }
    }
}
