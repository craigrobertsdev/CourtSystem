using System.ComponentModel.DataAnnotations;

namespace CourtSystem.Models.Data;

public class CaseFileDocument {
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
}