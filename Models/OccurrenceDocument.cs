using System.ComponentModel.DataAnnotations;

namespace CourtSystem.Models;

public class OccurrenceDocument {
    [Key]   
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
}