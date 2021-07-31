using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Structura.GuiTests.SeleniumHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structura.GuiTests.PageObjects
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [FindsBy(How = How.ClassName, Using = "login")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "search_query_top")]
        public IWebElement MainSearchField { get; set; }

        [FindsBy(How = How.ClassName, Using = "logout")]
        public IWebElement LogoutButton { get; set; }

        [FindsBy(How = How.Id, Using = "account")]
        public IWebElement MyAccountLink { get; set; }

        [FindsBy(How = How.ClassName, Using = "page-heading")]
        public IWebElement PageHeading { get; set; }

        /// <summary>
        /// Product List appears on multiple pages but on main page 
        /// there are more than one product list and than we need 
        /// to determine which one is active (which has class 'active').
        /// In the case that we have only one product list it doesn't have class 'active'.
        /// </summary>
        public IList<IWebElement> ProductList
        {
            get
            {
                if (SeleniumHelper.IsElementDisplayed(driver, By.CssSelector("ul.product_list.active")))
                {
                    return driver.FindElements(By.CssSelector(".product_list.active > li"));
                }
                return driver.FindElements(By.CssSelector(".product_list > li"));
            }
        }


        public IList<string> ProductNameList
        {
            get
            {
                IList<string> products = new List<string>();
                foreach(IWebElement product in this.ProductList)
                {
                    products.Add(product.FindElement(By.XPath(".//a[@class='product-name']")).Text);
                }

                return products;
            }
        }

        public int DisplayedProductsCount
        {
            get
            {
                return this.ProductList.Count;
            }
        }

        public string MyAccountLinkText
        {
            get
            {
                return MyAccountLink.FindElement(By.TagName("span")).Text;
            }
        }
    }
}
