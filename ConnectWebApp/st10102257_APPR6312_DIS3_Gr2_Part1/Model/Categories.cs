using System.ComponentModel.DataAnnotations;

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Model
{
    public class Categories
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Total { get; set; }
    }
}
