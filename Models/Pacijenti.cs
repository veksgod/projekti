using System.ComponentModel.DataAnnotations;

namespace bolnica_razor_pages.Models;

public class Pacijent
{
    public int Id { get; set; }

    [Required]
    public string Ime { get; set; } = string.Empty;

    [Required]
    public string Prezime { get; set; } = string.Empty;

    public DateTime DatumRodjenja { get; set; }

    public string Spol { get; set; } = string.Empty;

    public string Adresa { get; set; } = string.Empty;

    public string Telefon { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string BrojKartona { get; set; } = string.Empty;

    public int OdjelId { get; set; }

    public Odjel? Odjel { get; set; }
}