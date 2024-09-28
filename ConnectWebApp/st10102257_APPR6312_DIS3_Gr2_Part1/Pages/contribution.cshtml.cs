using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using st10102257_APPR6312_DIS3_Gr2_Part1.Data;
using st10102257_APPR6312_DIS3_Gr2_Part1.Model;

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Pages
{
    public class contributionModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<MonetaryDonations> monetaryDonations { get; set; }
        public IEnumerable<GoodsDonations> goodsDonations { get; set; }
        public IEnumerable<Disasters> disasters { get; set; }
        public IEnumerable<Categories> categories { get; set; }
        public IEnumerable<DonationsAllocatedToDisasters> Allocations { get; set; }

        public contributionModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            categories = _db.Categories.ToList();
            goodsDonations = _db.GoodsDonations.ToList();
            monetaryDonations = _db.MonetaryDonations.ToList();
            disasters = _db.Disasters.ToList();

            var allocatedAmounts = _db.Allocation
                .Include(a => a.Disaster)
                .Include(a => a.Category)
                .Where(a => a.Disaster.isActive)
                .GroupBy(a => new { a.DisasterId, a.CategoryId })
                .Select(group => new
                {
                    DisasterId = group.Key.DisasterId,
                    CategoryId = group.Key.CategoryId,
                    Name = group.FirstOrDefault().Disaster.Name,
                    Location = group.FirstOrDefault().Disaster.Location,
                    TotalAmount = group.Sum(a => a.Amount)
                })
                .ToList();

            Allocations = allocatedAmounts
                .GroupBy(a => a.DisasterId)
                .Select(group => new DonationsAllocatedToDisasters
                {
                    DisasterId = group.Key,
                    Name = group.FirstOrDefault().Name,
                    Location = group.FirstOrDefault().Location,
                    MonetaryAmount = group.Where(a => a.CategoryId == 1).Sum(a => a.TotalAmount),
                    GoodsAmount = group.Where(a => a.CategoryId != 1).Sum(a => a.TotalAmount)
                })
                .ToList();
        }

    }
}
