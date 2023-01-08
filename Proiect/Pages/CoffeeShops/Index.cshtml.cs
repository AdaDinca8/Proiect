using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.CoffeeShops
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<CoffeeShop> CoffeeShop { get;set; } = default!;
        public CoffeeShopData CoffeeShopD { get; set; }
        public int CoffeeShopID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID)
        {
            CoffeeShopD = new CoffeeShopData();

            CoffeeShopD.CoffeeShops = await _context.CoffeeShop
            .Include(b => b.Comanda)
            .Include(b => b.CoffeeShopCategorie)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Coffee)
            .ToListAsync();
            if (id != null)
            {
                CoffeeShopID = id.Value;
                CoffeeShop coffeeShop = CoffeeShopD.CoffeeShops
                .Where(i => i.ID == id.Value).Single();
                CoffeeShopD.Categorii = coffeeShop.CoffeeShopCategorie.Select(s => s.Categorie);
            }
        }

        
        }
    }

