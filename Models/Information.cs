namespace CourtSystem.Models;

public class Information {
    public List<InformationEntry> Charges { get; set; } = [];
}

public record InformationEntry(int Sequence, string Text);