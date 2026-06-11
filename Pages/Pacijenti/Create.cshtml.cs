using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using bolnica_razor_pages.Data;
using bolnica_razor_pages.Models;

namespace bolnica_razor_pages.Pages.Pacijenti;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Pacijent Pacijent { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Pacijenti.Add(Pacijent);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}