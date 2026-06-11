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

namespace bolnica_razor_pages.Pages.Pacijenti
{
    public class EditModel : PageModel
    {
        private readonly bolnica_razor_pages.Data.AppDbContext _context;

        public EditModel(bolnica_razor_pages.Data.AppDbContext context)
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

            var pacijent =  await _context.Pacijenti.FirstOrDefaultAsync(m => m.Id == id);
            if (pacijent == null)
            {
                return NotFound();
            }
            Pacijent = pacijent;
           ViewData["OdjelId"] = new SelectList(_context.Odjeli, "Id", "Naziv");
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

            _context.Attach(Pacijent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacijentExists(Pacijent.Id))
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

        private bool PacijentExists(int id)
        {
            return _context.Pacijenti.Any(e => e.Id == id);
        }
    }
}
