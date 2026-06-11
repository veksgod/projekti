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
    public class IndexModel : PageModel
    {
        private readonly bolnica_razor_pages.Data.AppDbContext _context;

        public IndexModel(bolnica_razor_pages.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Odjel> Odjel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Odjel = await _context.Odjeli.ToListAsync();
        }
    }
}
