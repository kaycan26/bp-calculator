using BPCalculator;
using Xunit;

namespace BPCalculator.BddTests
{
    public class BloodPressureCategoryBddTests
    {
        [Theory(DisplayName = "BDD: Blood pressure category scenarios")]
        [InlineData(90, 60, BPCategory.Ideal)]
        [InlineData(110, 70, BPCategory.Ideal)]
        [InlineData(135, 85, BPCategory.PreHigh)]
        [InlineData(150, 95, BPCategory.High)]
        public void BloodPressureCategory_Scenarios(
            int systolic, int diastolic, BPCategory expectedCategory)
        {
            // GIVEN a blood pressure reading
            var bp = new BloodPressure
            {
                Systolic = systolic,
                Diastolic = diastolic
            };

            // WHEN I calculate the category
            var actual = bp.Category;

            // THEN the result should match the expected category
            Assert.Equal(expectedCategory, actual);
        }
    }
}
