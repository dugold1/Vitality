using OpenQA.Selenium;

namespace WarcTechnicalTest.Pages
{
    internal class BasePage
    {

        private readonly IWebDriver _driver;
        private readonly IJavaScriptExecutor _jsDriver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _jsDriver = (IJavaScriptExecutor)_driver;
        }

        public void MoveToElement(int x, int y)
        {
            var js = string.Format("window.scrollTo({0}, {1})", x, y);
            _jsDriver.ExecuteScript(js);
        }

        public void Click(IWebElement element) =>
             ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);


    }
}
