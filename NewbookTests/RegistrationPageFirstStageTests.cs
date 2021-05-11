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
    public class RegistrationPageFirstStageTests
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
        public void CheckTheTransitionToTheSecondStageOfRegistration()
        {
            Random email = new Random();
            int _email = email.Next(100, 999);

            var registrationPage = new RegistrationPage(_webDriver);
            registrationPage.OpenPage()
                .SetFirstName("Will")
                .SetLastName("Smith")
                .SetEmail($"sosixo{_email}5@quossum.com")
                .SetMobile("4444444444")
                .SetPassword("@123Will@")
                .SetConfirmPassword("@123Will@")
                .ClickLoginButton();

            var result = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/join/company", result);

        }
    }
}
