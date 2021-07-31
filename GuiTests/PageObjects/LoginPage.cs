using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Structura.GuiTests.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
{
    public class LoginPage : BasePage
    {
        public static string Title
        {
            get
            {
                return "Login - My Store";
            }
        }

        public LoginPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "email_create")]
        public IWebElement CreateEmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement LoginEmail { get; set; }

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement LoginPassword { get; set; }

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        public IWebElement CreateAccountButton { get; set; }

        public CreateAccountPage CreateAccout()
        {
            this.CreateAccountButton.Click();
            WebDriverExtensions.WaitUntilElementExists(driver, By.Id("submitAccount"));

            CreateAccountPage createAccountPage = new CreateAccountPage(driver);

            if (!createAccountPage.PageHeading.Text.Equals(CreateAccountPage.Heading))
            {
                Thread.Sleep(3);
                createAccountPage = new CreateAccountPage(driver);
            }

            return createAccountPage;
        }
    }
}