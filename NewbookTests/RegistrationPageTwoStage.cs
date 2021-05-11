using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewbookTests
{
    public class RegistrationPageTwoStage
    {
        private readonly IWebDriver _webDriver;

        private By _companyNameField = By.CssSelector("[name = company_name]");
        private By _companyURLField = By.CssSelector("[name = company_website]");
        private By _addressField = By.CssSelector("[name = location]");
        private By _abbressList = By.CssSelector("[class=pac-matched]");
        private By _industryField = By.CssSelector("[name = industry]");
        private By _industryList = By.CssSelector("[role = option]");
        private By _finishButton = By.CssSelector(".SignupCompanyForm__submitButton--3mz3p");

        public RegistrationPageTwoStage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public RegistrationPageTwoStage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join/company");
            return this;
        }

        public RegistrationPageTwoStage SetCompanyName(string company_name)
        {
            _webDriver.FindElement(_companyNameField).SendKeys(company_name);
            return this;
        }

        public RegistrationPageTwoStage SetCompanyURL(string company_URL)
        {
            _webDriver.FindElement(_companyURLField).SendKeys(company_URL);
            return this;
        }

        public RegistrationPageTwoStage SetAddress(string address)
        {
            _webDriver.FindElement(_addressField).SendKeys(address);
            return this;
        }

        public void ClickAddress()
        {
            _webDriver.FindElement(_abbressList).Click();
        }

        public void ClickIndustryList()
        {
            _webDriver.FindElement(_industryField).Click();
        }

        public void ClickIndustry()
        {
            _webDriver.FindElement(_industryList).Click();
        }

        public void ClickFinishButton()
        {
            _webDriver.FindElement(_finishButton).Click();
        }

    }
}
