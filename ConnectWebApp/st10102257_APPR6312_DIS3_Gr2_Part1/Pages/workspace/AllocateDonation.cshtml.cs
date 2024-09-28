using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using st10102257_APPR6312_DIS3_Gr2_Part1.Data;
using st10102257_APPR6312_DIS3_Gr2_Part1.Model;

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Pages.workspace
{
    public class AllocateDonationModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<GoodsDonations> Donations { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
        public List<DonationWithCategoryName> DonationsWithCategories { get; set; }
        public GoodsDonations Donation { get; set; }
        public Disasters Disaster { get; set; }
        public int DonatonId { get; set; }
        public int disasterId { get; set; }
        public AllocateDonationModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int disasterId)
        {
            this.disasterId = disasterId;

            // Get categories
            Categories = _db.Categories.ToList(); 

           
            if (disasterId != null)
            {
                // Retrieve the donation with donation id
                Disaster = _db.Disasters.FirstOrDefault(d => d.ID == disasterId);
            }
            else
            {
                // Initialize Donation to an empty or default object
                Donation = new GoodsDonations(); // Replace with the appropriate constructor
            }


        }

        public IActionResult OnPost()
        {
            int category = Convert.ToInt32(Request.Form["category"]);
            decimal amount = Convert.ToDecimal(Request.Form["amount_to_send"]);
            int disaster = Convert.ToInt32(Request.Form["disasterId"]);

            var disasterObj = _db.Disasters.Find(disaster);

            var allocationObj = new Allocation();

            var canBeAllocateTo = allocationObj.CanBeAllocatedTo(disasterObj);

            if (!canBeAllocateTo)
            {
                TempData["StatusMessage"] = "Cannot allocate to a disaster that is not active.";
                return RedirectToPage("Dashboard");
            }

            // Prepare objects to update or add to the database
            var updateCategory = _db.Categories.FirstOrDefault(d => d.ID == category);
            var allocation = new Allocation
            {
                DisasterId = disaster,
                Amount = amount,
                CategoryId = category,
            };

            if(updateCategory != null)
            {
                // Perform database functions
                _db.Add(allocation);
                decimal amountRemaining = updateCategory.Total - amount;     // subtract the amount
                updateCategory.Total = amountRemaining;     // Update amount in inventory
                _db.SaveChanges();
                TempData["StatusMessage"] = "Allocation was successful.";
            }
            else
            {
                TempData["StatusMessage"] = "Failed to allocate.";
            }


            return RedirectToPage("Dashboard");
        }
    }
}
