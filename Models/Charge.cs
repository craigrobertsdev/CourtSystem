using System.ComponentModel.DataAnnotations;

namespace CourtSystem.Models;
public class Charge {
    [Key]
    public int Id { get; set; }
    public int Sequence { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string? VictimName { get; set; } = string.Empty;
    public string ChargeWording { get; set; } = string.Empty;
}
