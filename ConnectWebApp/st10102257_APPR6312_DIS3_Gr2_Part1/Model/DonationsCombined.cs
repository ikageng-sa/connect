using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Model
{
    public class DonationsCombined
    {
        public string? Donor { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public bool isAllocated { get; set; }

        // Navigation property
        public Categories Category { get; set; }
    }
}
