using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using bolnica_razor_pages.Data;
using bolnica_razor_pages.Models;

namespace bolnica_razor_pages.Pages.Odjeli
{
    public class DeleteModel : PageModel
    {
        private readonly bolnica_razor_pages.Data.AppDbContext _context;

        public DeleteModel(bolnica_razor_pages.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Odjel Odjel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odjel = await _context.Odjeli.FirstOrDefaultAsync(m => m.Id == id);

            if (odjel == null)
            {
                return NotFound();
            }
            else
            {
                Odjel = odjel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odjel = await _context.Odjeli.FindAsync(id);
            if (odjel != null)
            {
                Odjel = odjel;
                _context.Odjeli.Remove(Odjel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
