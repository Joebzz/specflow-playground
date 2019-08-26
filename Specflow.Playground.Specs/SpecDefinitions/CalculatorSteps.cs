using TechTalk.SpecFlow;
using Specflow.Playground.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Specflow.Playground.Specs.StepDefinitions
{
    [Binding]
    public class CalculatorSteps
    {
        private Calculator _calculator = new Calculator();
        private int _result;
        [Given(@"I have entered '(.*)' into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            _calculator.FirstNumber = number;
        }

        [Given(@"I have also entered '(.*)' into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int number)
        {
            _calculator.SecondNumber = number;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Add();
        }

        [When(@"I press subtract")]
        public void WhenIPressSubtract()
        {
            _result = _calculator.Subtract();
        }

        [Then(@"the result should be '(.*)' on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            Assert.AreEqual(expectedResult, _result);
        }
    }
}
