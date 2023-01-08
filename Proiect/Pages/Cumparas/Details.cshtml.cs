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
    public class DetailsModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public DetailsModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

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
    }
}
