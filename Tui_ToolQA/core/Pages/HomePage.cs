using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tui_ToolQA.core.BaseTest;

namespace Tui_ToolQA.core.Pages
{
    public class HomePage : PageBases
    {
        //Element locator
        By demoSiteLocator = By.XPath("//div[@class='col-auto']//li[3]");

        public HomePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public IWebElement demoSite()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(demoSiteLocator));
            return driver.FindElement(demoSiteLocator);
        }

        public DemoQAPage ClickOnDemoSite()
        {
            demoSite().Click();
            return new DemoQAPage(driver, wait);
        }
    }
}
