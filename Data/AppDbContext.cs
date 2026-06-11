using Microsoft.EntityFrameworkCore;
using bolnica_razor_pages.Models;

namespace bolnica_razor_pages.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Pacijent> Pacijenti => Set<Pacijent>();

    public DbSet<Odjel> Odjeli => Set<Odjel>();
}