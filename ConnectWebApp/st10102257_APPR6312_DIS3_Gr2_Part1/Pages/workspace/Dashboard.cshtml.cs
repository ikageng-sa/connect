using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using st10102257_APPR6312_DIS3_Gr2_Part1.Data;
using st10102257_APPR6312_DIS3_Gr2_Part1.Model;
using System.Globalization;

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Pages.workspace
{
    public class DashboardModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Categories> Categories { get; set; }
        public IEnumerable<GoodsDonations> Donations { get; set; }
        public IEnumerable<Disasters> Disasters { get; set; }
        public IEnumerable<DonationsCombined> AllDonations { get; set; }
        public GoodsDonations Donation { get; set; }
        public List<string> DonationCategories { get; set; }
        public Dictionary<string, decimal> CategoryTotals { get; set; }

        public DashboardModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            var goodsDonations = _db.GoodsDonations
                .Include(g => g.Category)
                .Select(g => new DonationsCombined
                {
                    Donor = g.Donor,
                    Date = g.Date,
                    CategoryName = g.Category.Name,
                    Amount = g.Amount,
                    Description = g.Description,
                    isAllocated = g.isAllocated
                }).ToList();
            var monetaryDonations = _db.MonetaryDonations
                .Include(d => d.Category)
                .Select(g => new DonationsCombined
                {
                    Donor = g.Donor,
                    Date = g.Date,
                    CategoryName = g.Category.Name,
                    Amount = g.Amount,
                    Description = g.Description,
                    isAllocated = g.isAllocated
                }).ToList();

            AllDonations = goodsDonations.Union(monetaryDonations).ToList();





            Categories = _db.Categories.ToList();
            // Donations = _db.GoodsDonations
            //    .Include(a => a.Category);
            Disasters = _db.Disasters;

            DonationCategories = Categories.Select(d => d.Name).ToList();

            CategoryTotals = new Dictionary<string, decimal>();

            foreach (var category in DonationCategories)
            {
                decimal totalAmount = AllDonations
                    .Where(d => d.CategoryName == category && !d.isAllocated)
                    .Sum(d => d.Amount);
                CategoryTotals.Add(category, totalAmount);
            }

        }
        public async Task<IActionResult> OnPost(GoodsDonations Donation)
        {
            if (Donation.Date == default(DateTime))
            {
                ModelState.AddModelError("Donation.date", "Date is required.");
                return Page();
            }

            await _db.GoodsDonations.AddAsync(Donation);
            await _db.SaveChangesAsync();
            return RedirectToPage("Dashboard");
        }

        public async Task<IActionResult> OnPostChangeStatus()
        {
            int id = Convert.ToInt32(Request.Form["disaster_id"]);
            bool status = Convert.ToBoolean(Request.Form["status"]);


            // Retrieve the existing disaster from the database
            var disaster = await _db.Disasters.FindAsync(id);

            if (disaster != null)
            {
                // Update the property value
                disaster.isActive = status;

                // Save the changes to the database
                await _db.SaveChangesAsync();

                TempData["StatusMessage"] = "Status was changed successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Disaster not found.";
            }

            return RedirectToPage("Dashboard");
        }

    }
}
