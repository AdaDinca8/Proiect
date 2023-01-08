using Proiect.Migrations;

namespace Proiect.Models
{
    public class CoffeeShopData
    {
        public IEnumerable<CoffeeShop> CoffeeShops { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CoffeeShopCategorie> CoffeeShopCategorii { get; set; }
    }
}
