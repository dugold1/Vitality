using BoDi;
using Microsoft.Extensions.Configuration;
using System;
using TechTalk.SpecFlow;
using WarcTechnicalTest.Utilities;

namespace WarcTechnicalTest.Hooks
{
    [Binding]
    internal class FeatureHook
    {
        public static TestConfig Config;
        private Webdriver _webdriver;
        private readonly IObjectContainer _objectContainer;



        public FeatureHook(IObjectContainer objectContainer) =>
            _objectContainer = objectContainer;


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var browser = Environment.GetEnvironmentVariable("browser");
            var config = new ConfigurationBuilder()
              .AddJsonFile("Appsettings.json")
              .Build();
            Config = new TestConfig();
            config.GetSection("TestConfig").Bind(Config);

            if (!string.IsNullOrEmpty(browser))
                Config.Driver = browser;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _webdriver = new Webdriver();
            _webdriver.SetDriver();
            _objectContainer.RegisterInstanceAs(_webdriver.Driver);
        }


  
    }
}