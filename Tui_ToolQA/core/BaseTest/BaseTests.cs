using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Tui_ToolQA.core.BaseTest
{
    public abstract class BaseTests
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        string chromeDriverPath = Path.Combine(Environment.CurrentDirectory.ToString(), "drivers", "chromedriver.exe");
        string firefoxDriverPath = Path.Combine(Environment.CurrentDirectory.ToString(), "drivers", "geckodriver.exe");

        public IWebDriver getDriver(string driverType = "chrome")
        {
            switch(driverType)
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("start-maximized");
                    driver = new ChromeDriver(chromeDriverPath, options);
                    break;
                case "firefox":
                    FirefoxOptions f_options = new FirefoxOptions();
                    f_options.AddArgument("start-maximized");
                    driver = new FirefoxDriver(firefoxDriverPath, f_options);
                    break;
                default:
                    throw new ArgumentException($"Don't have driver type: {driverType}");
            }

            return driver;
        }
    }
}
