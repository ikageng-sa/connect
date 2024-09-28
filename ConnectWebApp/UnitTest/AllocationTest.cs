using st10102257_APPR6312_DIS3_Gr2_Part1.Model;

namespace UnitTest
{
    [TestClass]
    public class AllocationTest
    {
        [TestMethod]
        public void CanBeAllocatedTo_DisasterIsActive_ReturnsTrue()
        {
            // Arrange
            var allocation = new Allocation();

            // Act
            var result = allocation.CanBeAllocatedTo(new Disasters { isActive = true });

            // Assert
            Assert.IsTrue(result);
        }
    }
}