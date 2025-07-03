using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UIAutomationUsingSelenium
{
    public class InventoryPage
    {
        private readonly IWebDriver _driver;
        private readonly By _addToCartButtons = By.CssSelector("button.btn_inventory");
        private readonly By _cartBadge = By.ClassName("shopping_cart_badge");
        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(10);

        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddAllItemsToCart()
        {
            var wait = new WebDriverWait(_driver, _timeout);
            wait.Until(d => d.FindElements(_addToCartButtons).Count > 0);
            var buttons = _driver.FindElements(_addToCartButtons);
            foreach (var button in buttons)
            {
                wait.Until(d => button.Displayed && button.Enabled);
                button.Click();
            }
        }

        public int GetCartItemCount()
        {
            var wait = new WebDriverWait(_driver, _timeout);
            wait.Until(d => d.FindElements(_cartBadge).Count > 0 || d.FindElements(_cartBadge).Count == 0);
            var badge = _driver.FindElements(_cartBadge);
            if (badge.Count == 0) return 0;
            return int.Parse(badge[0].Text);
        }
    }
}
