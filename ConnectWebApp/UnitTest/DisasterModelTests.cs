using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using st10102257_APPR6312_DIS3_Gr2_Part1.Data;
using st10102257_APPR6312_DIS3_Gr2_Part1.Model;
using st10102257_APPR6312_DIS3_Gr2_Part1.Pages.workspace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class DisasterModelTests
    {
        [TestMethod]
        public async Task OnPost_AddsDisasterToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_DisasterDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var disasterModel = new DisasterModel(context);

                // sample Disaster object with required properties
                var disaster = new Disasters
                {
                    Name = "Test Disaster",
                    Description = "Test Description",
                    Location = "Test Location",
                    startDate = DateTime.Now,
                    endDate = DateTime.Now.AddDays(7),
                    isActive = true
                };

                // Act
                IActionResult result = await disasterModel.OnPost(disaster);

                // Assert
                Assert.AreEqual(1, context.Disasters.Count()); // Check if disaster was added to the database
                Assert.IsInstanceOfType(result, typeof(RedirectToPageResult));
            }
        }
    }
}
