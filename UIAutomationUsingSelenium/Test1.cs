using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace UIAutomationUsingSelenium
{
    [TestClass]
    public sealed class Test1
    {
        private Stopwatch stopwatch;

        [TestInitialize]
        public void TestInit()
        {
            stopwatch = Stopwatch.StartNew();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            stopwatch.Stop();
            var testName = TestContext.TestName;
            System.Console.WriteLine($"Test '{testName}' executed in {stopwatch.Elapsed.TotalSeconds:F2} seconds.");
        }

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Login_ShouldSucceed_WithValidCredentials()
        {
            using (var driver = WebDriverFactory.GetChromeDriver())
            {
                var loginPage = new LoginPage(driver);
                loginPage.GoTo();
                loginPage.Login("standard_user", "secret_sauce");
                loginPage.GetProductsTitle().Should().Be("Products");
            }
        }

        [TestMethod]
        public void AddInventoryItemsToCart_ShouldIncreaseCartCount()
        {
            using (var driver = WebDriverFactory.GetChromeDriver())
            {
                var loginPage = new LoginPage(driver);
                loginPage.GoTo();
                loginPage.Login("standard_user", "secret_sauce");
                var inventoryPage = new InventoryPage(driver);
                inventoryPage.AddAllItemsToCart();
                int cartCount = inventoryPage.GetCartItemCount();
                cartCount.Should().BeGreaterThan(0);
            }
        }
    }
}
