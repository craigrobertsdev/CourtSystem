using CourtSystem.Models;

namespace CourtSystem.Data;
public class CourtListDataAccess {
    private readonly ApplicationDbContext _context;

    public CourtListDataAccess() {
        _context = new ApplicationDbContext();
    }

    public void SaveCourtList(CourtList courtList) {
        _context.CourtLists.Add(courtList);
        _context.SaveChanges();
    }

    public CourtList? GetCourtList() {
        return _context.CourtLists.FirstOrDefault();
    }
}
