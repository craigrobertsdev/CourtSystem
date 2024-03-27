using System.ComponentModel.DataAnnotations;

namespace CourtSystem.Models.Data;

public class InformationModel {
    [Key]
    public int Id { get; set; }
    public List<InformationEntry> Charges { get; set; } = [];
}

public record InformationEntry(int Sequence, string Text);