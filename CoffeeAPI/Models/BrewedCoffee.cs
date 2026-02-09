namespace CoffeeAPI.Models
{
    public class BrewedCoffee
    {
        //public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime Prepared { get; set; } = DateTime.UtcNow;
    }
}
