using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewbookTests
{
    public class SignInPage
    {
        private readonly IWebDriver _webDriver;

        private By _emailField = By.CssSelector("input[type=email]");
        private By _passwordField = By.CssSelector("input[type=password]");
        private By _loginButton = By.CssSelector(".SignInForm__submitButton--cUdOV");
        private By _accountBlockMassage = By.CssSelector("div.FormErrorText__error---nzyq:nth-child(1) > div:nth-child(1)");

        public SignInPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignInPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            return this;
        }

        public SignInPage SetEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public SignInPage SetPassword(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }

        public void ClickLoginButton()
        {
            _webDriver.FindElement(_loginButton).Click();
        }

        public string GetUserAccountBlockMessage()
        {
            return _webDriver.FindElement(_accountBlockMassage).Text;
        }
    }
}
