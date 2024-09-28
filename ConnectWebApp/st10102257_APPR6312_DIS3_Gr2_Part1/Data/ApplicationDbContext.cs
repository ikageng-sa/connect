using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using st10102257_APPR6312_DIS3_Gr2_Part1.Model;

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<GoodsDonations> GoodsDonations { get; set; }
        public DbSet<GoodsPurchased> GoodsPurchased { get; set; }
        public DbSet<MonetaryDonations> MonetaryDonations { get; set; }
        public DbSet<Disasters> Disasters { get; set; }
        public DbSet<Allocation> Allocation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GoodsDonations>()
                .Property(d => d.Date)
                .HasConversion(
                    v => v.ToString("yyyy-MM-dd"),
                    v => DateTime.ParseExact(v, "yyyy-MM-dd", null));
        }

    }
}
