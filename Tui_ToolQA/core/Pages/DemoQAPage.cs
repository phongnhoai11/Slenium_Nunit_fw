using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tui_ToolQA.core.BaseTest;

namespace Tui_ToolQA.core.Pages
{
    public class DemoQAPage : PageBases
    {
        //Locator
        By formLocator = By.XPath("(//div[@class='card-body'])[2]");
        public DemoQAPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            driver = FocusOnNewTab(1);
            this.wait = new WebDriverWait(driver, timeout: TimeSpan.FromSeconds(60));
        }

        public IWebElement Form()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(formLocator));
            return driver.FindElement(formLocator);
        }

        public FormPage ClickOnForm()
        {
            Form().Click();
            return new FormPage(driver, wait);
        }
    }
}
