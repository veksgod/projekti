using System.ComponentModel.DataAnnotations;

namespace bolnica_razor_pages.Models;

public class Odjel
{
    public int Id { get; set; }

    [Required]
    public string Naziv { get; set; } = string.Empty;

    public string Opis { get; set; } = string.Empty;

    public int BrojPacijenata { get; set; }

    public string PrimariusIme { get; set; } = string.Empty;

    public ICollection<Pacijent>? Pacijenti { get; set; }
}