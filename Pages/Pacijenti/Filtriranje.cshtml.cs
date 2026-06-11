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
    public class FiltriranjeModel : PageModel
    {
        private readonly AppDbContext _context;

        public FiltriranjeModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string Prezime { get; set; } = "";

        public IList<Pacijent> Pacijenti { get; set; } = new List<Pacijent>();

        public async Task OnGetAsync()
        {
            var upit = _context.Pacijenti
                .Include(p => p.Odjel)
                .AsQueryable();

            if (!string.IsNullOrEmpty(Prezime))
            {
                upit = upit.Where(p => p.Prezime.Contains(Prezime));
            }

            Pacijenti = await upit.ToListAsync();
        }
    }
}