namespace Proiect.Models
{
    public class CoffeeShopCategorie
    {
        public int ID { get; set; }
        public int CoffeeShopID { get; set; }
        public CoffeeShop CoffeeShop { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
