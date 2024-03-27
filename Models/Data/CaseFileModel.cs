using System.ComponentModel.DataAnnotations;

namespace CourtSystem.Models.Data;
public class CaseFile {
    [Key]
    public string CaseFileNumber { get; set; } = string.Empty;
    public DefendantModel Defendant { get; set; } = default!;
    [MaxLength(20)]
    public string? CourtFileNumber { get; set; } = string.Empty;
    public List<HearingEntryModel> PreviousHearings { get; set; } = [];
    public List<CaseFileEnquiryLogModel> CfelEntries { get; set; } = [];
    public string FactsOfCharge { get; set; } = default!;
    public InformationModel Information { get; set; } = default!;
    public List<ChargeModel> Charges { get; set; } = [];
    public List<CaseFileDocument> CaseFileDocuments { get; set; } = [];
    public List<OccurrenceDocumentModel> OccurrenceDocuments { get; set; } = [];
    public string Notes { get; set; } = string.Empty;
}
