using WarcTechnicalTest.Hooks;
using WarcTechnicalTest.Pages;
using WarcTechnicalTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace WarcTechnicalTest.StepDefs
{
    [Binding]
    public sealed class WeatherPageSteps
    {
        private readonly WeatherPage _homePage;
        private readonly IWebDriver _driver;

        public WeatherPageSteps(IWebDriver driver)
        {
            _driver = driver;
            _homePage = new WeatherPage(driver);

        }

        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            _driver.Navigate().GoToUrl(FeatureHook.Config.Url);

        }

        [When(@"I click accept cookies")]
        public void WhenIClickAcceptCookies()
        {
            _homePage.ClickAcceptCookies();
        }

        [When(@"I click on weather")]
        public void WhenIClickOnWeather()
        {
            _homePage.ClickWeather();
        }

        [When(@"I search '([^']*)'")]
        public void WhenISearch(string bournemouth)
        {
            _homePage.EnterLocation(bournemouth);


        }

        [When(@"I click on tomorrow date")]
        public void WhenIClickOnTomorrowDate()
        {
            _homePage.ClickTomorrowWeather();
        }


        [Then(@"I assert tomorrow high temperature is greater than the low temperature")]
        public void ThenIAssertTomorrowHighTemperatureIsGreaterThanTheLowTemperature()
        {
            _homePage.CompareTemp();
        }


    }
}
