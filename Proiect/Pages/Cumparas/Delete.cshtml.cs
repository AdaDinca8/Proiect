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
    public class DeleteModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public DeleteModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Cumpara Cumpara { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cumpara == null)
            {
                return NotFound();
            }

            var cumpara = await _context.Cumpara.FirstOrDefaultAsync(m => m.ID == id);

            if (cumpara == null)
            {
                return NotFound();
            }
            else 
            {
                Cumpara = cumpara;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cumpara == null)
            {
                return NotFound();
            }
            var cumpara = await _context.Cumpara.FindAsync(id);

            if (cumpara != null)
            {
                Cumpara = cumpara;
                _context.Cumpara.Remove(Cumpara);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
