using Microsoft.EntityFrameworkCore;
namespace CoffeeAPI.Data
{
    public class BrewedCoffeeDbContext: DbContext
    {
        public DbSet<BrewedCoffeeDbContext> BrewedCoffee { get; set; }

        public BrewedCoffeeDbContext(DbContextOptions<BrewedCoffeeDbContext> options) : base(options) 
        { 

        }
    }
}
