using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using st10102257_APPR6312_DIS3_Gr2_Part1.Data;
using st10102257_APPR6312_DIS3_Gr2_Part1.Model;

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Pages.workspace
{
    public class PurchaseGoodsModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Categories> Categories { get; set; }

        public PurchaseGoodsModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Categories = _db.Categories;
        }

        public IActionResult OnPost()
        {
            int category = Convert.ToInt32(Request.Form["category"]);
            string description = Request.Form["description"];
            decimal amountUsed = Convert.ToDecimal(Request.Form["amount_used"]);
            decimal items = Convert.ToDecimal(Request.Form["items_count"]);
            DateTime date = Convert.ToDateTime(Request.Form["date"]);

            var monetaryCategory = _db.Categories.FirstOrDefault(d => d.Name.ToLower() == "monetary");
            var goodsCategory = _db.Categories.FirstOrDefault(d => d.ID == category);

            if(monetaryCategory != null)
            {
                var newAmount = monetaryCategory.Total - amountUsed;
                var newItemCount = goodsCategory.Total + items;
                var goodsDonations = new GoodsDonations
                {
                    Donor = "PURCHASED",
                    CategoryId = category,
                    Date = date,
                    Description = description,
                    Amount = items,
                };

                goodsCategory.Total = newItemCount;
                _db.Add(goodsDonations);        // Save to database
                _db.SaveChanges();

                int donationId = goodsDonations.ID;

                var goodsPurchased = new GoodsPurchased
                {
                    AmountUsed = amountUsed,
                    GoodsDonationsId = donationId
                };

                monetaryCategory.Total = newAmount;      // Update the amount in inventory
                _db.Add(goodsPurchased);
                _db.SaveChanges();

                TempData["StatusMessage"] = "A new purchased was successfully added.";
            }
            else
            {
                TempData["StatusMessage"] = "Could not add a new purchase, Try again.";
            }
           
            return RedirectToPage("Dashboard");
        }
    }
}
