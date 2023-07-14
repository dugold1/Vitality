using WarcTechnicalTest.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace WarcTechnicalTest
{
    class Webdriver
    {
        public IWebDriver Driver;


        public void SetDriver()
        {
            var browser = FeatureHook.Config.Driver.ToLower();
            switch (browser)
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    Driver = new ChromeDriver();  
                    break;
                default:
                    throw new Exception($"The browser {browser} is not currently implemented");
            }
         
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Driver.Manage().Cookies.DeleteAllCookies();
        }
    }
}
