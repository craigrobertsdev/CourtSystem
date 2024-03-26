using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CourtSystem.Models;

public class Information {
    [Key]
    public int Id { get; set; } 
    public List<InformationEntry> Charges { get; set; } = [];
}

[Owned]
public record InformationEntry(int Sequence, string Text);