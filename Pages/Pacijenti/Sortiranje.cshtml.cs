using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using bolnica_razor_pages.Data;
using bolnica_razor_pages.Models;

namespace bolnica_razor_pages.Pages.Pacijenti
{
    public class SortiranjeModel : PageModel
    {
        private readonly AppDbContext _context;

        public SortiranjeModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Pacijent> Pacijenti { get; set; } = new List<Pacijent>();

        public async Task OnGetAsync()
        {
            Pacijenti = await _context.Pacijenti
                .OrderBy(p => p.Prezime)
                .ToListAsync();
        }
    }
}