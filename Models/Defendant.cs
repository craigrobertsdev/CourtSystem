namespace CourtSystem.Models;
public class Defendant {
    private string? _activeCaseFileNumber;
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public List<CaseFile> CaseFiles { get; set; } = [];
    public CaseFile? ActiveCaseFile { get; set; }

    public string? ActiveCaseFileNumber {
        get {
            return ActiveCaseFile?.CaseFileNumber;
        }
        set {
            ActiveCaseFile = CaseFiles.FirstOrDefault(cf => cf.CaseFileNumber == value);
            _activeCaseFileNumber = value;
        }
    }
}
