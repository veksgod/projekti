using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using bolnica_razor_pages.Data;
using bolnica_razor_pages.Models;

namespace bolnica_razor_pages.Pages.Pacijenti
{
    public class DeleteModel : PageModel
    {
        private readonly bolnica_razor_pages.Data.AppDbContext _context;

        public DeleteModel(bolnica_razor_pages.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pacijent Pacijent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacijent = await _context.Pacijenti.FirstOrDefaultAsync(m => m.Id == id);

            if (pacijent == null)
            {
                return NotFound();
            }
            else
            {
                Pacijent = pacijent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacijent = await _context.Pacijenti.FindAsync(id);
            if (pacijent != null)
            {
                Pacijent = pacijent;
                _context.Pacijenti.Remove(Pacijent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
