namespace Proiect.Models
{
    public class Comanda
    {
        public int ID { get; set; }
        public string StatusComanda { get; set; }
        public int Total { get; set; }
        public ICollection<CoffeeShop>? CoffeeShops { get; set; }
    }
}
