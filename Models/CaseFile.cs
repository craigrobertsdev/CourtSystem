namespace CourtSystem.Models;
public class CaseFile {
    public string CaseFileNumber { get; set; } = string.Empty;
    public string? CourtFileNumber { get; set; } = string.Empty;
    public List<HearingEntry> PreviousHearings { get; set; } = [];
    public List<CaseFileEnquiryLog> CfelEntries { get; set; } = [];
    public string FactsOfCharge { get; set; } = string.Empty;
    public List<Charge> Charges { get; set; } = [];
}
