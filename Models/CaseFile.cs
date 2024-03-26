using System.ComponentModel.DataAnnotations;

namespace CourtSystem.Models;
public class CaseFile {
    [Key]
    public string CaseFileNumber { get; set; } = string.Empty;
    [MaxLength(20)]
    public string? CourtFileNumber { get; set; } = string.Empty;
    public List<HearingEntry> PreviousHearings { get; set; } = [];
    public List<CaseFileEnquiryLog> CfelEntries { get; set; } = [];
    public string FactsOfCharge { get; set; } = default!;
    public Information Information { get; set; } = default!;
    public List<Charge> Charges { get; set; } = [];
    public List<CaseFileDocument> CaseFileDocuments { get; set; } = [];
    public List<OccurrenceDocument> OccurrenceDocuments { get; set; } = [];
    public string Notes { get; set; } = string.Empty;

    public void GenerateInformationFromCharges() {
        List<InformationEntry> charges = [];
        foreach (var charge in Charges) {
            charges.Add(new InformationEntry(charge.Sequence, charge.ChargeWording));
        }

        Information = new Information {
            Charges = charges
        };
    }
}
