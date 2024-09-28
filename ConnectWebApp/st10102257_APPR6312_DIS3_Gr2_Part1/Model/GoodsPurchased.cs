using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Model
{
    public class GoodsPurchased
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("GoodsDonationsId")]
        public int GoodsDonationsId { get; set; }
        public decimal AmountUsed { get; set; }

        // Navigation property
        public GoodsDonations GoodsDonations { get; set; }
    }
}
