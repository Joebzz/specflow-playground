using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;

namespace Specflow.Playground.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class MiwidgetSteps
    {
        private const string DRIVER_DIR = @"C:\Automation\";

        //private readonly IWebDriver _driver;
        private IWebDriver _driver;

        public MiwidgetSteps()
        {
            //_driver = new ChromeDriver(DRIVER_DIR);
            //_driver = new InternetExplorerDriver(DRIVER_DIR);
            //_driver = new FirefoxDriver(DRIVER_DIR);

            _driver = new EdgeDriver(DRIVER_DIR);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _driver.Manage().Window.Maximize();
        }

        [Given(@"I am on the miwidgets page")]
        public void GivenIAmOnTheMiwidgetsPage()
        {
            _driver.Navigate().GoToUrl("https://miwidgets.marine.ie/");
        }
        
        [When(@"I look for '(.*)' tag")]
        public void WhenILookForTag(string p0)
        {
            var q = _driver.FindElement(By.TagName(p0));
            Assert.IsNotNull(q);
        }

        [Then(@"I should see a class with '(.*)'")]
        public void ThenIShouldSeeAClassWith(string p0)
        {
            var q = _driver.FindElement(By.ClassName(p0));
            Assert.IsNotNull(q);
        }

    }
}
