using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using st10102257_APPR6312_DIS3_Gr2_Part1.Data;
using st10102257_APPR6312_DIS3_Gr2_Part1.Model;

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Pages.workspace
{
    public class DisasterModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Disasters Disaster { get; set; }

        public DisasterModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPost(Disasters Disaster)
        {
            await _db.Disasters.AddAsync(Disaster);
            await _db.SaveChangesAsync();
            return RedirectToPage("Dashboard");
        }
    }
}
