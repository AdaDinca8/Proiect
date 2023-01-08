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
    public class EditModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public EditModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cumpara Cumpara { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cumpara == null)
            {
                return NotFound();
            }

            var cumpara =  await _context.Cumpara.FirstOrDefaultAsync(m => m.ID == id);
            if (cumpara == null)
            {
                return NotFound();
            }
            Cumpara = cumpara;
           ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");
           ViewData["CoffeeShopID"] = new SelectList(_context.CoffeeShop, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cumpara).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CumparaExists(Cumpara.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CumparaExists(int id)
        {
          return _context.Cumpara.Any(e => e.ID == id);
        }
    }
}
