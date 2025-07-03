using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using FluentAssertions;

namespace UIAutomationUsingSelenium
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly By _usernameField = By.Id("user-name");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.Id("login-button");
        private readonly By _productsTitle = By.ClassName("title");
        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(10);

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoTo() => _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        public void Login(string username, string password)
        {
            var wait = new WebDriverWait(_driver, _timeout);
            wait.Until(d => d.FindElement(_usernameField).Displayed);
            _driver.FindElement(_usernameField).SendKeys(username);
            wait.Until(d => d.FindElement(_passwordField).Displayed);
            _driver.FindElement(_passwordField).SendKeys(password);
            wait.Until(d => d.FindElement(_loginButton).Displayed);
            _driver.FindElement(_loginButton).Click();
        }

        public string GetProductsTitle()
        {
            var wait = new WebDriverWait(_driver, _timeout);
            wait.Until(d => d.FindElement(_productsTitle).Displayed);
            return _driver.FindElement(_productsTitle).Text;
        }
    }
}
