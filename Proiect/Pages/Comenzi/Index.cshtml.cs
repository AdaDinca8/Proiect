using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;
using Proiect.Models.ViewModels;

namespace Proiect.Pages.Comenzi
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Comanda> Comanda { get;set; } = default!;

        public ComandaIndexData ComandaData { get; set; }
        public int ComandaID { get; set; }
        public int CoffeeShopID { get; set; }
        public async Task OnGetAsync(int? id, int? coffeeShopID)
        {
            ComandaData = new ComandaIndexData();
            ComandaData.Comenzi = await _context.Comanda
            .Include(i => i.CoffeeShops)
            .OrderBy(i => i.StatusComanda)
            .ToListAsync();
            if (id != null)
            {
                ComandaID = id.Value;
                Comanda comanda = ComandaData.Comenzi
                .Where(i => i.ID == id.Value).Single();
                ComandaData.CoffeeShops = comanda.CoffeeShops;
            }

        }
    }
}
