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
    public class MIWidgetSteps
    {
        private const string DRIVER_DIR = @"C:\Automation\";

        //private readonly IWebDriver _driver;
        private IWebDriver _driver;

        public MIWidgetSteps()
        {
            //_driver = new ChromeDriver(DRIVER_DIR);
            //_driver = new InternetExplorerDriver(DRIVER_DIR);
            _driver = new FirefoxDriver(DRIVER_DIR);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
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

        [When(@"I click on a class '(.*)'")]
        public void WhenIClickOnAClass(string p0)
        {
            _driver.FindElement(By.ClassName(p0)).Click();
        }
        [Then(@"I should see a '(.*)'")]
        public void ThenIShouldSeeA(string p0)
        {
            _driver.FindElement(By.ClassName(p0)).Click();
        }

        [When(@"I click on a text '(.*)'")]
        public void WhenIClickOnAText(string p0)
        {
            var layerControl = _driver.FindElement(By.ClassName("leaflet-control-layers-list"));
            var q = layerControl.FindElement(By.XPath($"//span[text()='{p0}']"));

            Assert.IsNotNull(q);
            q.Click();
        }

        [Then(@"I should not see a class with '(.*)'")]
        public void ThenIShouldNotSeeAClassWith(string p0)
        {
            var isElementPresent = IsElementPresent(By.ClassName(p0));
            Assert.IsFalse(isElementPresent);
        }
        [Then(@"I should able to see a style with '(.*)'")]
        public void ThenIShouldAbleToSeeAStyleWith(string p0)
        {
            var zoomAnimated = _driver.FindElement(By.CssSelector(".leaflet-map-pane .leaflet-proxy.leaflet-zoom-animated"));
            var style = zoomAnimated.GetAttribute("style");
            Assert.IsTrue(style.Contains(p0));
        }
        [Then(@"I should see a style with '(.*)'")]
        public void ThenIShouldSeeAStyleWith(string p0)
        {
            var zoomAnimated = _driver.FindElement(By.CssSelector(".leaflet-map-pane .leaflet-proxy.leaflet-zoom-animated"));
            var style = zoomAnimated.GetAttribute("style");
            Assert.IsTrue(style.Contains(p0));
        }

        private bool IsElementPresent (By by)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                _driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }


}

