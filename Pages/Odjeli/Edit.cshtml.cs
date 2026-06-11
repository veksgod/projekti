using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bolnica_razor_pages.Data;
using bolnica_razor_pages.Models;

namespace bolnica_razor_pages.Pages.Odjeli
{
    public class EditModel : PageModel
    {
        private readonly bolnica_razor_pages.Data.AppDbContext _context;

        public EditModel(bolnica_razor_pages.Data.AppDbContext context)
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

            var odjel =  await _context.Odjeli.FirstOrDefaultAsync(m => m.Id == id);
            if (odjel == null)
            {
                return NotFound();
            }
            Odjel = odjel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Odjel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdjelExists(Odjel.Id))
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

        private bool OdjelExists(int id)
        {
            return _context.Odjeli.Any(e => e.Id == id);
        }
    }
}
