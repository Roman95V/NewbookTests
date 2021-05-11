using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace NewbookTests
{
    public class UserLogOutTest
    {
        private IWebDriver _webDriver;
        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            _webDriver = new FirefoxDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);

        }
        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }

        [Test]
        public void CheckSuccessfulUserLogOut()
        {
            //email    sosixo6385@quossum.com
            //password @123Will@
            var signInPage = new SignInPage(_webDriver);
            signInPage.OpenPage()
                .SetEmail("sosixo6385@quossum.com")
                .SetPassword("@123Will@")
                .ClickLoginButton();

            var userLogOut = new UserLogOut(_webDriver);
            userLogOut.ClickMenuButton();
            userLogOut.ClickLogOUtButton();

            var result = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/auth/signin", result);
        }
    }
}
