using CourtSystem.Models.Data;
using System.IO;
using System.Text.Json;

namespace CourtSystem.Data;
public static class CourtListParser {
    private static readonly JsonSerializerOptions options = new() {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    public static CourtListModel? ReadCaseFiles(string path) {
        var filePath = Path.Combine(Environment.CurrentDirectory, "Data", "SeedData.json");
        using var reader = new StreamReader(filePath);
        var json = reader.ReadToEnd();
        var courtList = JsonSerializer.Deserialize<CourtListModel>(json, options);
        return courtList;
    }
}
