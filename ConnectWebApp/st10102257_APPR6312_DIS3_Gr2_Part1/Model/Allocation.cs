using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Model
{
    public class Allocation
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("DisasterId")]
        public int DisasterId { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        // Navigation properties
        public Disasters Disaster { get; set; }
        public Categories Category { get; set; }

        public bool CanBeAllocatedTo(Disasters disaster)
        {

            if (disaster.isActive == true)
                return true;

            return false;
        }
    }

}
