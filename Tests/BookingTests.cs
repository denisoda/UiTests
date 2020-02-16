using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UiTests.Tests
{
    [TestClass]
    public class BookingTests
    {
        private readonly IWebDriver driver;
        private const string AppUrl = "https://www.booking.com/";
        private const string UserAccountEmail = "i8ask14@mailboxt.net";
        private const string UserAccountPass = "UserAccountPass";

        public BookingTests()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void BookingChangeCurrencySwitchTest()
        {
            driver.Navigate().GoToUrl(AppUrl);
            
            var currencyButton = driver.FindElement(By.CssSelector("a[aria-controls='currency_selector_popover']"));
            currencyButton.Click();

            var euroCurrencyButton = driver.FindElement(By.CssSelector("a[data-currency='EUR']"));
            euroCurrencyButton.Click();

            var currencyButtonAfterClick = driver.FindElement(By.CssSelector("a[aria-controls='currency_selector_popover']"));

            Assert.IsTrue(currencyButtonAfterClick.Text == "€");
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void BookingFlightsAviabilityTest()
        {
            driver.Navigate().GoToUrl(AppUrl);

            var flightsOrdersButton = driver.FindElement(By.CssSelector("a[data-decider-header='flights']"));

            flightsOrdersButton.Click();
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void AccountAviabilityTest()
        {
            driver.Navigate().GoToUrl(AppUrl);

            var flightsOrdersButton = driver.FindElement(By.CssSelector(@"a[data-title='Get a more personalized search]'"));

            flightsOrdersButton.Click();
        }
    }
}