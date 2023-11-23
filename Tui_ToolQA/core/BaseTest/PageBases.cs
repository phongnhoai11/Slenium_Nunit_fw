using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Tui_ToolQA.core.BaseTest
{
    public abstract class PageBases
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public PageBases(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        protected IWebDriver FocusOnNewTab(int indexOfTab)
        {
            return driver.SwitchTo().Window(driver.WindowHandles[indexOfTab]);
        }
    }
}
