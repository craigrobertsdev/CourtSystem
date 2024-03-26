using CourtSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace CourtSystem.Data;
public class ApplicationDbContext : DbContext {
    public DbSet<CourtList> CourtLists { get; set; }
    public string DbPath { get; set; }
    public ApplicationDbContext() {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        DbPath = Path.Join(folder, "CourtSystem.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");
}
