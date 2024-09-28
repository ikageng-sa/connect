using Microsoft.AspNetCore.Components.Web;

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Model
{
    public class DonationWithCategoryName
    {
        public int DonationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public bool isAllocated { get; set; }
        public string CategoryName { get; set; }
    }
}
