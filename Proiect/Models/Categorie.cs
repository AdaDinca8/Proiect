namespace Proiect.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }
        public ICollection<CoffeeShopCategorie>? CoffeeShopCategorie { get; set; }
    }
}
