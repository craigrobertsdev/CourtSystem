using System.ComponentModel.DataAnnotations;

namespace CourtSystem.Models.Data;
public class CaseFileEnquiryLogModel {
    [Key]
    public int Id { get; set; }
    public string EntryText { get; set; } = string.Empty;
    public string EnteredBy { get; set; } = string.Empty;

    public DateTime EntryDate { get; set; }
}
