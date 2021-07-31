using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using Structura.GuiTests.PageObjects;
using Structura.GuiTests.SeleniumHelpers;
using Structura.GuiTests.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tests.PageObjects;
using Tests.SeleniumHelpers;

namespace Structura.GuiTests.TestCases
{
    [TestFixture]
    class MainScenarios : BaseTest
    {
        private string UserEmail = ConfigurationHelper.Get<string>("UserEmail");
        private string TemporaryEmail = ConfigurationHelper.Get<string>("TemporaryEmail");
        private string UserPassword = ConfigurationHelper.Get<string>("UserPassword");
        private string UserFirstName = ConfigurationHelper.Get<string>("UserFirstName");
        private string UserLastName = ConfigurationHelper.Get<string>("UserLastName");
        private string UserAddress = ConfigurationHelper.Get<string>("UserAddress");
        private string UserCity = ConfigurationHelper.Get<string>("UserCity");
        private string UserState = ConfigurationHelper.Get<string>("UserState");
        private string UserZipCode = ConfigurationHelper.Get<string>("UserZipCode");
        private string UserMobilePhone = ConfigurationHelper.Get<string>("UserMobilePhone");

        [Test]
        public void CreateAccount()
        {
            MainPage mainPage = new MainPage(Driver);
            LoginPage loginPage = mainPage.ClickSignIn();

            Assert.AreEqual(LoginPage.Title, Driver.Title);

            loginPage.CreateEmailInput.SetText(this.TemporaryEmail);

            CreateAccountPage createAccountPage = loginPage.CreateAccout();

            createAccountPage.FirstName.SetText(this.UserFirstName);
            createAccountPage.LastName.SetText(this.UserLastName);

            Assert.AreEqual(createAccountPage.Email.GetAttribute("value"), this.TemporaryEmail);

            createAccountPage.Password.SetText(this.UserPassword);
            createAccountPage.Address.SetText(this.UserAddress);
            createAccountPage.City.SetText(this.UserCity);
            createAccountPage.State.SetSelectElementText(this.UserState);
            createAccountPage.ZipCode.SetText(this.UserZipCode);
            createAccountPage.MobilePhone.SetText(this.UserMobilePhone);

            MyAccountPage myAccountPage = createAccountPage.Register();

            Assert.IsTrue(SeleniumHelper.IsElementEnabled(myAccountPage.LogoutButton), "Logout button should be displayed and enabled on the page.");
        }

        [TestCase("POPULAR", 7)]
        [TestCase("BEST SELLERS", 7)]
        [Test]
        public void VerifyNumberOfProductsInCatalogCategory(string category, int numOfProducts)
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.SelectProductCategory(category);

            Assert.AreEqual(category, mainPage.ActiveProductCategory, "Category '{0}' should be selected.", category);
            Assert.AreEqual(numOfProducts, mainPage.DisplayedProductsCount, "Selected category should have {0} products displayed.", numOfProducts);
        }

        [Test]
        public void SearchForPrintedDressesAndMakeOrder()
        {
            string printedDresses = "Printed dresses";
            string searchResultHeading = "SEARCH";
            int expectedSearchResultNumber = 5;
            this.Login(this.UserEmail, this.UserPassword);
            MainPage mainPage = new MainPage(Driver);
            mainPage.MainSearchField.SetText(printedDresses);
            mainPage.MainSearchField.PressEnter();

            Assert.IsTrue(mainPage.PageHeading.Text.Contains(printedDresses.ToUpper()));
            Assert.IsTrue(mainPage.PageHeading.Text.Contains(searchResultHeading));
            Assert.AreEqual(expectedSearchResultNumber, mainPage.DisplayedProductsCount);

            IList<string> productNames = mainPage.ProductNameList;
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\..\..\products.txt");
            FileUtil.WriteText(productNames, filePath);
        }
    }
}
