using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Model
{
    public class MonetaryDonations
    {
        [Key]
        public int ID { get; set; }
        [AllowNull]
        public string? Donor { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public bool isAllocated { get; set; } = false;

        // Navigation property
        public Categories Category { get; set; }
    }
}
