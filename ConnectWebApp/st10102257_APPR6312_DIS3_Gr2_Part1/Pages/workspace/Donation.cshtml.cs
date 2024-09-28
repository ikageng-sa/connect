using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using st10102257_APPR6312_DIS3_Gr2_Part1.Data;
using st10102257_APPR6312_DIS3_Gr2_Part1.Model;

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Pages.workspace
{
    public class DonationModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public string result = null;
        public IEnumerable<Categories> Categories { get; set; }
        public GoodsDonations Donation { get; set; }
        public MonetaryDonations MonetaryDonation { get; set; }
        public DonationModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Categories = _db.Categories;
        }
        public async Task<IActionResult> OnPostRecordDonation() 
        {
            string donor = Request.Form["donor"];
            int categoryId = Convert.ToInt32(Request.Form["category"]);
            DateTime date = Convert.ToDateTime(Request.Form["date"]);
            decimal amount = Convert.ToDecimal(Request.Form["amount"]);
            string description = Request.Form["description"];

            var categoryName = _db.Categories
                .Where(c => c.ID == categoryId)
                .Select(c => c.Name)
                .FirstOrDefault();
            if (categoryName.ToLower() == "monetary")
            {
                var category = _db.Categories.FirstOrDefault(d => d.ID == categoryId); // get the category
                var newAmount = category.Total + amount;
                var monetaryDonation = new MonetaryDonations
                {
                    Donor = donor,
                    Date = date,
                    CategoryId = categoryId,
                    Amount = amount,
                    Description = description,
                };


                category.Total = newAmount; // Update the amount
                await _db.AddAsync(monetaryDonation);
                await _db.SaveChangesAsync();
            }
            else
            {
                var category = _db.Categories.FirstOrDefault(d => d.ID == categoryId); // get the category
                var newAmount = category.Total + amount;
                var goodsDonation = new GoodsDonations
                {
                    Donor = donor,
                    Date = date,
                    CategoryId = categoryId,
                    Amount = amount,
                    Description = description,
                };

                category.Total = newAmount; // Update the amount
                await _db.GoodsDonations.AddAsync(goodsDonation);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("Dashboard");
        }

        public async Task<IActionResult> OnPostCreateCategory()
        {
            // Get the value of "CategoryName" from the form
            string categoryName = Request.Form["CategoryName"];

            // Create a new Category object and set its Name property
            var category = new Categories
            {
                Name = categoryName
            };

            // Add the category to the database
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();

            return RedirectToPage("Donation");

        }

    }
}
