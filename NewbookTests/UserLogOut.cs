using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewbookTests
{
    public class UserLogOut
    {
        private readonly IWebDriver _webDriver;

        private By _menu = By.CssSelector(".AvatarClient__avatar--3TC7_");
        private By _logOut = By.CssSelector(".link_type_logout");

        public UserLogOut(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void ClickMenuButton()
        {
            _webDriver.FindElement(_menu).Click();
        }

        public void ClickLogOUtButton()
        {
            _webDriver.FindElement(_logOut).Click();
        }
    }
}
