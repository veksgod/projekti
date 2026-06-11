using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using bolnica_razor_pages.Data;
using bolnica_razor_pages.Models;

namespace bolnica_razor_pages.Pages.Pacijenti;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Pacijent> Pacijenti { get; set; } = new List<Pacijent>();

    public async Task OnGetAsync()
    {
        Pacijenti = await _context.Pacijenti
            .Include(p => p.Odjel)
            .ToListAsync();
    }
}