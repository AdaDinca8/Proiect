using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;


namespace Proiect.Pages.CoffeeShops
{
    public class EditModel : CoffeeShopCategoriePageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public EditModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CoffeeShop CoffeeShop { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CoffeeShop = await _context.CoffeeShop
                .Include(b => b.Comanda)
                .Include(b => b.CoffeeShopCategorie).ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            var coffeeshop = await _context.CoffeeShop.FirstOrDefaultAsync(m => m.ID == id);
            if (coffeeshop == null)
            {
                return NotFound();
            }
            PopulateDateAtribuiteCategoriei(_context, CoffeeShop);
            CoffeeShop = coffeeshop;
            ViewData["ComandaID"] = new SelectList(_context.Set<Comanda>(), "ID", "StatusComanda");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[]
 selectedCategorii)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var coffeeShopToUpdate = await _context.CoffeeShop
            .Include(i => i.Comanda)
            .Include(i => i.CoffeeShopCategorie)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (coffeeShopToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<CoffeeShop>(
            coffeeShopToUpdate,
            "CoffeeShop",
            i => i.Coffee, i => i.Brand,
            i => i.Pret, i => i.ComandaID))
            {
                UpdateCoffeeShopCategorii(_context, selectedCategorii, coffeeShopToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateCoffeeShopCategorii(_context, selectedCategorii, coffeeShopToUpdate);
            PopulateDateAtribuiteCategoriei(_context, coffeeShopToUpdate);
            return Page();
        }
    }


}    

