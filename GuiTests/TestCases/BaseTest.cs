using NUnit.Framework;
using OpenQA.Selenium;
using Structura.GuiTests.PageObjects;
using Structura.GuiTests.SeleniumHelpers;
using Structura.GuiTests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.PageObjects;

namespace Structura.GuiTests.TestCases
{
    class BaseTest
    {
        private IWebDriver driver;
        private StringBuilder _verificationErrors;
        private string baseUrl;

        [SetUp]
        public void BaseSetUp()
        {
            driver = new DriverFactory().Create();
            baseUrl = ConfigurationHelper.Get<string>("TargetUrl");
            _verificationErrors = new StringBuilder();
            driver.Navigate().GoToUrl(baseUrl);
        }

        [TearDown]
        public void BaseTearDown()
        {
            try
            {
                driver.Quit();
                driver.Close();
            }
            catch (Exception)
            {
                // Ignore errors if we are unable to close the browser
            }
        }

        public IWebDriver Driver
        {
            get
            {
                return this.driver;
            }
        }

        public string BaseUrl
        {
            get
            {
                return this.baseUrl;
            }
        }

        public void Login(string email, string password)
        {
            MainPage mainPage = this.Logout();
            LoginPage loginPage = mainPage.ClickSignIn();
            loginPage.LoginEmail.SetText(email);
            loginPage.LoginPassword.SetText(password);
            loginPage.LoginButton.Click();
        }

        public MainPage Logout()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            MainPage mainPage = new MainPage(driver);
            if (SeleniumHelper.IsElementEnabled(mainPage.LogoutButton))
            {
                mainPage.LogoutButton.Click();
            }

            return mainPage;
        }
    }
}
