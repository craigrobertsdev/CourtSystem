using CourtSystem.Data;
using CourtSystem.Models.UI;

namespace CourtSystem;
public partial class CourtListPage {
    private CourtList CourtList { get; set; } = default!;
    public Defendant? ActiveDefendant { get; set; }
    private string? _error { get; set; }
    private readonly ApplicationDbContext _context = new();

    protected override void OnInitialized() {
        var output = CourtListParser.ReadCaseFiles("SeedData.json");
        if (output is not null) {
            CourtList = output;
            CourtList.GenerateInformations();

            ActiveDefendant = CourtList.Defendants.FirstOrDefault();
            if (ActiveDefendant is not null) {
                ActiveDefendant.ActiveCaseFile = ActiveDefendant?.CaseFiles.FirstOrDefault();
            }
        }
        else {
            _error = "Error reading file";
        }

    }

    private void ActivateDefendant(Defendant defendant) {
        ActiveDefendant = defendant;
        if (ActiveDefendant.ActiveCaseFile is null) {
            ActiveDefendant.ActiveCaseFile = ActiveDefendant.CaseFiles.First();
        }
    }

    private string IsSelected(Defendant defendant) {
        if (ActiveDefendant?.Id == defendant.Id) {
            return "!bg-sky-700";
        }

        return "hover:bg-gray-500";
    }

    private void SaveCourtList() {

    }
}
