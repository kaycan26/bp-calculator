using BPCalculator;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BPCalculator.BddTests.StepDefinitions
{
    [Binding]
    public class BloodPressureCategorySteps
    {
        private readonly ScenarioContext _scenarioContext;

        public BloodPressureCategorySteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a systolic value of (.*)")]
        public void GivenASystolicValueOf(int systolic)
        {
            var bp = new BloodPressure
            {
                Systolic = systolic
            };

            _scenarioContext["bp"] = bp;
        }

        [Given(@"a diastolic value of (.*)")]
        public void GivenADiastolicValueOf(int diastolic)
        {
            var bp = (BloodPressure)_scenarioContext["bp"];
            bp.Diastolic = diastolic;
        }

        [When(@"I calculate the blood pressure category")]
        public void WhenICalculateTheBloodPressureCategory()
        {
            var bp = (BloodPressure)_scenarioContext["bp"];
            _scenarioContext["category"] = bp.Category;
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string expectedCategory)
        {
            var actual = (BPCategory)_scenarioContext["category"];
            actual.ToString().Should().Be(expectedCategory);
        }
    }
}
