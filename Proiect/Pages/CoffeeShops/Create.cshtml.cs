using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.CoffeeShops
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : CoffeeShopCategoriePageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public CreateModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ComandaID"] = new SelectList(_context.Set<Comanda>(), "ID", "StatusComanda");
            var coffeeShop = new CoffeeShop();
            coffeeShop.CoffeeShopCategorie = new List<CoffeeShopCategorie>();
            PopulateDateAtribuiteCategoriei(_context, coffeeShop);
            return Page();
        }

        [BindProperty]
        public CoffeeShop CoffeeShop { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategorii)
        {
            var newCoffeeShop = new CoffeeShop();
            if (selectedCategorii != null)
            {
                newCoffeeShop.CoffeeShopCategorie = new List<CoffeeShopCategorie>();
                foreach (var cat in selectedCategorii)
                {
                    var catToAdd = new CoffeeShopCategorie
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newCoffeeShop.CoffeeShopCategorie.Add(catToAdd);
                }
            }
            CoffeeShop.CoffeeShopCategorie = newCoffeeShop.CoffeeShopCategorie
                ;
            _context.CoffeeShop.Add(CoffeeShop);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
       

    }



}

