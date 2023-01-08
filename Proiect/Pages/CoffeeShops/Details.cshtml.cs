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
    public class DetailsModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public DetailsModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

      public CoffeeShop CoffeeShop { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CoffeeShop == null)
            {
                return NotFound();
            }

            var coffeeshop = await _context.CoffeeShop.FirstOrDefaultAsync(m => m.ID == id);
            if (coffeeshop == null)
            {
                return NotFound();
            }
            else 
            {
                CoffeeShop = coffeeshop;
            }
            return Page();
        }
    }
}
