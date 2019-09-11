using System;
using System.Threading;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace Specflow.Playground.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class GoogleSearchSteps : IDisposable
    {
        private IWebDriver _driver;

        public GoogleSearchSteps()
        {
            _driver = new ChromeDriver(@"C:\Automation\");
        }

        [Given(@"I am on the google page")]
        public void GivenIAmOnTheGooglePage()
        {
            _driver.Navigate().GoToUrl("https://www.google.com");
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string keyword)
        {
            var q = _driver.FindElement(By.Name("q"));
            q.SendKeys(keyword);
            q.Submit();
        }

        [Then(@"I should see title ""(.*)""")]
        public void ThenIShouldSeeTitle(string title)
        {
            Thread.Sleep(5000);
            Assert.AreEqual(_driver.Title, title);
        }

        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Dispose();

                _driver = null;
            }
        }
    }
}
