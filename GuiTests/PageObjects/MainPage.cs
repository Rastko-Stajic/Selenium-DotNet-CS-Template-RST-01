using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using Tests.PageObjects;
using Tests.SeleniumHelpers;

namespace Structura.GuiTests.PageObjects
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"_ctl0__ctl0_Content_Main_promo\"]/table/tbody/tr[3]/td/a")]
        public IWebElement TransferFundsButton { get; set; }

        public IWebElement ActiveProductCategory
        {
            get
            {
                return driver.FindElement(By.CssSelector("#home-page-tabs > li.active > a"));
            }
        }

        public void SelectProductCategory(string categoryName)
        {
            driver.FindElement(By.XPath(string.Format("//*[@id='home-page-tabs']/li/a[text()='{0}']", categoryName))).Click();
        }

        public LoginPage ClickSignIn()
        {
            this.LoginButton.Click();
            WebDriverExtensions.WaitUntilPageIsOpened(this.driver, LoginPage.Title);

            return new LoginPage(this.driver);
        }
    }
}
