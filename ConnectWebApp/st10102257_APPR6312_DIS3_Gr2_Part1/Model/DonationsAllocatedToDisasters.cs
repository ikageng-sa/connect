namespace st10102257_APPR6312_DIS3_Gr2_Part1.Model
{
    public class DonationsAllocatedToDisasters
    {
        public int DisasterId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal GoodsAmount { get; set; } = 0;
        public decimal MonetaryAmount { get; set; } = 0;
        public bool isAlleviated { get; set; }

        // Navigation property
        public Categories category { get; set; }
        public Disasters disaster { get; set; }
    }
}
