using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using Tui_ToolQA.core.BaseTest;
using Tui_ToolQA.core.Pages;

namespace Tui_ToolQA.tests
{
    public class NavigationToolQATests : BaseTests
    {
        [OneTimeSetUp]
        public void oneTimeSetUp()
        {
            driver = getDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://toolsqa.com/");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("It is uneccessary now!");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Dispose();
        }

        [Test(Description = "Verify info which user just input to the form to register")]
        public void VerifyInfoAfterRegistering()
        {
            var fstName = "Test";
            var lstName = "Name";
            var email = "test@gmail.com";
            var phone = "0345943584";
            var subject = "automation";
            var address = "21 District 9";
            HomePage homePage = new HomePage(driver, wait);
            DemoQAPage demoQAPage = homePage.ClickOnDemoSite();
            FormPage formPage = demoQAPage.ClickOnForm();
            formPage.ClickOnPraticeForm();
            formPage.FillTheForm("Test", "Name", "abc@gmail.com", "0987653423", "automation", "21 District 9");
            Assert.AreEqual(fstName + " " + lstName, formPage.NameResult().Text);
        }
    }
}
