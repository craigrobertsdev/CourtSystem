using System.ComponentModel.DataAnnotations;

namespace CourtSystem.Models.Data;
public class CourtListModel {
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public List<DefendantModel> Defendants { get; set; } = [];
}
