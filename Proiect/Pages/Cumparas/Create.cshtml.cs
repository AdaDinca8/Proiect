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

namespace Proiect.Pages.Cumparas
{
    public class CreateModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public CreateModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var coffeeShopList = _context.CoffeeShop;
            



            ViewData["CoffeeShopID"] = new SelectList(coffeeShopList, "ID", "Brand");
        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
            return Page();
    }

    [BindProperty]
        public Cumpara Cumpara { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cumpara.Add(Cumpara);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
