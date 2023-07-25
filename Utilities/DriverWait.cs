using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WarcTechnicalTest.Utilities
{
    internal class DriverWait
    {
        private readonly WebDriverWait wait;

        public DriverWait(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void WaitForAjaxToComplete() =>
            wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
        
        public bool WaitForElementToBeDisplayed(By locator)
        {
            try
            {
                wait.Until(d => d.FindElement(locator).Displayed);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool WaitForElementToBeDisplayed(IWebElement element)
        {
            try
            {
                wait.Until(d => element.Displayed);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
