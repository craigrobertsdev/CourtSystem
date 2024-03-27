using CourtSystem.Models.Data;

namespace CourtSystem.Data;
public class CourtListDataAccess {
    private readonly ApplicationDbContext _context;

    public CourtListDataAccess() {
        _context = new ApplicationDbContext();
    }

    public void SaveCourtList(CourtListModel courtList) {
        _context.CourtLists.Add(courtList);
        _context.SaveChanges();
    }

    public CourtListModel? GetCourtList() {
        return _context.CourtLists.FirstOrDefault();
    }
}
