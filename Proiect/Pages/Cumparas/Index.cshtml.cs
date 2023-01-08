using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Cumparas
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Cumpara> Cumpara { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cumpara != null)
            {
                Cumpara = await _context.Cumpara
                .Include(c => c.Client)
                .Include(c => c.CoffeeShop).ToListAsync();
            }
        }
    }
}
