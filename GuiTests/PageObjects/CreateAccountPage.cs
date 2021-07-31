using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.SeleniumHelpers;

namespace Structura.GuiTests.PageObjects
{
    public class CreateAccountPage : BasePage
    {
        public static string Title
        {
            get
            {
                return "Login - My Store";
            }
        }

        public static string Heading
        {
            get
            {
                return "CREATE AN ACCOUNT";
            }
        }

        public CreateAccountPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.ClassName, Using = "page-heading")]
        public IWebElement PageHeading { get; set; }

        [FindsBy(How = How.Id, Using = "customer_firstname")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "customer_lastname")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "address1")]
        public IWebElement Address { get; set; }

        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement City { get; set; }

        [FindsBy(How = How.Id, Using = "id_state")]
        public IWebElement State { get; set; }

        [FindsBy(How = How.Id, Using = "postcode")]
        public IWebElement ZipCode { get; set; }

        [FindsBy(How = How.Id, Using = "phone_mobile")]
        public IWebElement MobilePhone { get; set; }

        [FindsBy(How = How.Id, Using = "submitAccount")]
        public IWebElement BtnRegister { get; set; }

        public MyAccountPage Register()
        {
            this.BtnRegister.Click();
            WebDriverExtensions.WaitUntilPageIsOpened(driver, MyAccountPage.Title);

            return new MyAccountPage(driver);
        }


    }
}
