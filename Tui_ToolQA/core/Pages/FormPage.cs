using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tui_ToolQA.core.BaseTest;

namespace Tui_ToolQA.core.Pages
{
    public class FormPage : PageBases
    {
        //locator
        By practiceFormLocator = By.XPath("(//ul[@class='menu-list']//span)[10]");
        By fstNameLocator = By.CssSelector("#firstName");
        By lstNameLocator = By.CssSelector("#lastName");
        By emailLocator = By.CssSelector("#userEmail");
        By genderLocator = By.XPath("//label[contains(text(),'Male')]/parent::div");
        By phoneLocator = By.CssSelector("#userNumber");
        By subjectLocator = By.XPath("//div[@id='subjectsWrapper']/div[2]/div/div");
        By hobbiesLocator = By.XPath("//div[@id='hobbiesWrapper']/div/div[1]");
        By addressLocator = By.CssSelector("#currentAddress");
        By stateLocator = By.XPath("//div[@id='state']/div");
        By cityLocator = By.XPath("//div[@id='city']/div");
        By submitLocator = By.XPath("//button[contains(text(),'Submit')]");
        By nameResultLocator = By.XPath("(//div[@class='table-responsive']//td)[2]");
        public FormPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("document.body.style.zoom='75%';");
        }

        public IWebElement PracticeForm()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(practiceFormLocator));
            return driver.FindElement(practiceFormLocator);
        }

        public IWebElement fstName() => driver.FindElement(fstNameLocator);
        public IWebElement lstName() => driver.FindElement(lstNameLocator);
        public IWebElement Email() => driver.FindElement(emailLocator);
        public IWebElement Gender() => driver.FindElement(genderLocator);
        public IWebElement Phone() => driver.FindElement(phoneLocator);
        public IWebElement Subject() => driver.FindElement(subjectLocator);
        public IWebElement Hobbies() => driver.FindElement(hobbiesLocator);
        public IWebElement Address() => driver.FindElement(addressLocator);
        public IWebElement State()
        {
            IWebElement state = driver.FindElement(stateLocator);
            return driver.FindElement(By.XPath("*[@id='option-1']"));
        }
        public IWebElement City()
        {
            IWebElement state = driver.FindElement(cityLocator);
            return driver.FindElement(By.XPath("*[@id='option-1']"));
        }

        public void ClickOnSubmitButton()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(submitLocator));
        }
        public IWebElement NameResult() => driver.FindElement(nameResultLocator);

        public void ClickOnPraticeForm()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
        }
        public void SelectGender()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", Gender());
        }

        public void FillTheForm(
            string fstNameValue, 
            string lstnameValue, 
            string EmailValue, 
            string PhoneNumber, 
            string subjectsValue, 
            string addressValue)
        {
            fstName().SendKeys(fstNameValue);
            lstName().SendKeys(lstnameValue);
            Email().SendKeys(EmailValue);
            Gender().Click();
            Phone().SendKeys(PhoneNumber);
            Address().SendKeys(addressValue);

            ((IJavaScriptExecutor)driver).ExecuteScript("document.body.style.zoom='75%';");
            ClickOnSubmitButton();
        }
    }
}
