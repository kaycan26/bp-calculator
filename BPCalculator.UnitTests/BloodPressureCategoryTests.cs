using BPCalculator;
using Xunit;

namespace BPCalculator.UnitTests
{
    public class BloodPressureCategoryTests
    {
        [Theory]
        [InlineData(90, 60, BPCategory.Ideal)]
        [InlineData(110, 70, BPCategory.Ideal)]
        [InlineData(135, 85, BPCategory.PreHigh)]
        [InlineData(150, 95, BPCategory.High)]
        public void Category_Is_Calculated_Correctly(
            int systolic, int diastolic, BPCategory expectedCategory)
        {
            // Arrange
            var bp = new BloodPressure
            {
                Systolic = systolic,
                Diastolic = diastolic
            };

            // Act
            var actual = bp.Category;

            // Assert
            Assert.Equal(expectedCategory, actual);
        }
    }
}
