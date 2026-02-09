using CoffeeAPI.Data;
using CoffeeAPI.Models;

namespace CoffeeAPI.Services
{
    public class BrewedCoffeeService: IBrewedCoffeeService
    {
        private readonly BrewedCoffeeDbContext _brewedCoffeeDbContext;

        public BrewedCoffeeService(BrewedCoffeeDbContext brewedCoffeeDbContext)
        {
            _brewedCoffeeDbContext = brewedCoffeeDbContext;
        }

        public BrewedCoffee GetInfo()
        {
            BrewedCoffee brewedCoffee = new BrewedCoffee
            {
                Message = "Your piping hot coffee is ready",
            };


            return brewedCoffee;
        }
    }
}
