using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tests.PageObjects;

namespace Tests.SeleniumHelpers
{
    public static class WebDriverExtensions
    {
        private const int implicitTimeout = 30;
        public static bool WaitUntilPageIsOpened(IWebDriver driver, string pageTitle, int timeout = implicitTimeout)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.TitleContains(pageTitle));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + pageTitle + "' is not found in current context page.");
                throw;
            }
        }

        public static IWebElement WaitUntilPageElementIsVisible(IWebDriver driver, By elementLocator, int timeout = implicitTimeout)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public static IWebElement WaitUntilElementExists(IWebDriver driver, By elementLocator, int timeout = implicitTimeout)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public static IWebElement FindElementByJQuery(this IWebDriver driver, string selector)
        {
            var js = (IJavaScriptExecutor)driver;
            // inject jquery if required
            if ((bool)js.ExecuteScript("return typeof jQuery == 'undefined'"))
            {
                js.ExecuteScript("var jq = document.createElement('script');jq.src = '//code.jquery.com/jquery-latest.min.js';document.getElementsByTagName('head')[0].appendChild(jq);");
                Thread.Sleep(300);
            }
            var formattedSelector = selector.IndexOf("$(", StringComparison.InvariantCultureIgnoreCase) == -1 ? string.Format("$(\"{0}\")", selector.Replace('\"', '\'')) : selector;
            var elements = FindElements(driver, formattedSelector);
            if (!elements.Any())
            {
                // retry with a delay 
                Thread.Sleep(4000);
                elements = FindElements(driver, formattedSelector);
                if (!elements.Any())
                    throw new InvalidOperationException("No element found with selector " + formattedSelector);
            }
            if (elements.Count() > 1)
                throw new InvalidOperationException(
                    string.Format(
                        "Multiple elements found with selector {0}. Make sure that the selector uniquely identifies a single element.",
                        formattedSelector));
            return elements.FirstOrDefault() as IWebElement;
        }

        private static IEnumerable<object> FindElements(IWebDriver driver, string selector)
        {
            const string ret = "return ";
            var result = ((IJavaScriptExecutor)driver).ExecuteScript(
                (selector.StartsWith(ret, StringComparison.InvariantCultureIgnoreCase) ? string.Empty : ret) + selector);
            return result as IEnumerable<object>;
        }
    }
}