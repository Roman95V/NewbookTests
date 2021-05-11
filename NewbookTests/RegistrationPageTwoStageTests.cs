using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace NewbookTests
{
    public class RegistrationPageTwoStageTests
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
        public void CheckTheSuccessfulRegistrationOfTheUserOnTheSite()
        {
            Random email = new Random();
            int _email = email.Next(100, 999);

            var registrationPageFirst = new RegistrationPage(_webDriver);
            registrationPageFirst.OpenPage()
                .SetFirstName("Will")
                .SetLastName("Smith")
                .SetEmail($"sosixo{_email}5@quossum.com")
                .SetMobile("4444444444")
                .SetPassword("@123Will@")
                .SetConfirmPassword("@123Will@")
                .ClickLoginButton();
            Thread.Sleep(3000);
            var registrationPage = new RegistrationPageTwoStage(_webDriver);
            registrationPage.SetCompanyName("WWWWW")
                .SetCompanyURL("wweer.com")
                .SetAddress("d")
                .ClickAddress();
            registrationPage.ClickIndustryList();
            registrationPage.ClickIndustry();
            registrationPage.ClickFinishButton();

            var result = _webDriver.Url;
            Thread.Sleep(3000);
            Assert.AreEqual("https://newbookmodels.com/explore", result);

        }
    }
}
