using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.CoffeeShops
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public DeleteModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CoffeeShop == null)
            {
                return NotFound();
            }
            var coffeeshop = await _context.CoffeeShop.FindAsync(id);

            if (coffeeshop != null)
            {
                CoffeeShop = coffeeshop;
                _context.CoffeeShop.Remove(CoffeeShop);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
