using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect.Data;

namespace Proiect.Models
{
    public class CoffeeShopCategoriePageModel : PageModel
    {
        public List<DateAtribuiteCategoriei> DateAtribuiteCategorieiList;
        public void PopulateDateAtribuiteCategoriei(ProiectContext context,
        CoffeeShop coffeeShop)
        {
            var allCategorii = context.Categorie;
            var coffeeShopCategorii = new HashSet<int>(
            coffeeShop.CoffeeShopCategorie.Select(c => c.CategorieID)); //
            DateAtribuiteCategorieiList = new List<DateAtribuiteCategoriei>();
            foreach (var cat in allCategorii)
            {
                DateAtribuiteCategorieiList.Add(new DateAtribuiteCategoriei
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Atribuit = coffeeShopCategorii.Contains(cat.ID)
                });
            }
        }
        public void UpdateCoffeeShopCategorii(ProiectContext context,
        string[] selectedCategorii, CoffeeShop coffeeShopToUpdate)
        {
            if (selectedCategorii == null)
            {
                coffeeShopToUpdate.CoffeeShopCategorie = new List<CoffeeShopCategorie>();
                return;
            }
            var selectedCategoriiHS = new HashSet<string>(selectedCategorii);
            var coffeeShopCategorii = new HashSet<int>
                (coffeeShopToUpdate.CoffeeShopCategorie.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriiHS.Contains(cat.ID.ToString()))
                {
                    if (!coffeeShopCategorii.Contains(cat.ID))
                    {
                        coffeeShopToUpdate.CoffeeShopCategorie.Add(
                        new CoffeeShopCategorie
                        {
                            CoffeeShopID = coffeeShopToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (coffeeShopCategorii.Contains(cat.ID))
                    {
                        CoffeeShopCategorie courseToRemove
                        = coffeeShopToUpdate
                        .CoffeeShopCategorie
                       
                    .SingleOrDefault(i => i.CategorieID == cat.ID);
                    context.Remove(courseToRemove);}
                }
            }
        }
    }
}
