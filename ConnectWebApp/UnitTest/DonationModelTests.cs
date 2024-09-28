using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using st10102257_APPR6312_DIS3_Gr2_Part1.Data;
using st10102257_APPR6312_DIS3_Gr2_Part1.Model;
using st10102257_APPR6312_DIS3_Gr2_Part1.Pages.workspace;

namespace UnitTest
{
    [TestClass]
    public class DonationModelTests
    {
        [TestMethod]
        public async Task OnPostRecordDonation_MonetaryCategory_AddsMonetaryDonationToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_DonationDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                // Add test data
                var monetaryCategory = new Categories { ID = 1, Name = "Monetary", Total = 0 };
                context.Categories.Add(monetaryCategory);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var donationModel = new DonationModel(context);

                // Mock the form Request object
                var formValues = new FormCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
                {
                    { "donor", "TestDonor" },
                    { "category", "1" },
                    { "date", "2023-11-24" },
                    { "amount", "100.00" },
                    { "description", "TestDescription" },
                });

                var httpContext = new DefaultHttpContext { Request = { Form = formValues } };
                donationModel.PageContext = new PageContext { HttpContext = httpContext };

                // Act
                await donationModel.OnPostRecordDonation();

                // Assert
                // Add assertions to check if the MonetaryDonations table has a new record
                Assert.AreEqual(1, context.MonetaryDonations.Count());
            }
        }
    }
}
