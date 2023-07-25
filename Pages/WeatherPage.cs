using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WarcTechnicalTest.Pages
{
    internal class WeatherPage : BasePage
    {
        private readonly IWebDriver _driver;
        private readonly By _lowTemperature = By.XPath("(//div[@class='wr-day-temperature__low'])[2]//span//span/span[1]");
        private readonly By _highTemperature = By.XPath("(//div[@class='wr-day-temperature__high'])[1]//span//span/span[1]");
        private readonly By _tomorrowWeather = By.XPath("//li[@class='wr-day wr-day--1 wr-js-day  ']");
        private readonly By _locations = By.XPath("//span[@class='gel-long-primer']");
        private readonly By _search = By.Id("ls-c-search__input-label");
        private readonly By _cookies = By.XPath("//button[@class='ssrcss-1fomw6p-ConsentButton exhqgzu2']");
        private readonly By _weather = By.XPath("//span[@class='ssrcss-1wlspqz-NavItemHoverState e1gviwgp18']");

        public WeatherPage(IWebDriver driver)
            : base(driver)
        {
            _driver = driver;
        }

        public void ClickWeather()
        {
            _driver.FindElement(_weather).Click();
        }

        public void ClickTomorrowWeather()
        {
            _driver.FindElement(_tomorrowWeather).Click();
        }
        public IWebElement LowTemperatureElement()
        {
           return _driver.FindElement(_lowTemperature);
        }
        public IWebElement HighTemperatureElement()
        {
           return _driver.FindElement(_highTemperature);
        }

        public void ClickAcceptCookies()
        {
            var element = _driver.FindElement(_cookies);
            Click(element);
        }

        public void EnterLocation(string location)
        {
            _driver.FindElement(_search).Click();
            _driver.FindElement(_search).SendKeys(location);
            _driver.FindElement(_search).SendKeys(Keys.Enter);

            foreach (var item in Locations())
            {
                if (item.Text.Equals(location))
                {
                    item.Click();
                }
            }
        }
        public IList<IWebElement> Locations()
        {
           return _driver.FindElements(_locations);
        }

        public void CompareTemp()
        {
            try
            {
                string highTemperature = HighTemperatureElement().Text;
                string lowTemperature = LowTemperatureElement().Text;
                string HightemperatureText = highTemperature.Replace("°", "");
                string LowtemperatureText = lowTemperature.Replace("°", "");
                int highTemp = int.Parse(HightemperatureText);
                int lowTemp = int.Parse(LowtemperatureText);


                Assert.Greater(highTemp, lowTemp, "Tomorrow's high temperature is greater than tomorrow's low temperature");


            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }
        

    }
}

