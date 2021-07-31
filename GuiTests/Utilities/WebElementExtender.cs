using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structura.GuiTests.Utilities
{
    public static class WebElementExtender
    {
        public static SelectElement AsSelectElement(this IWebElement element)
        {
            return new SelectElement(element);
        }

        public static void SetSelectElementText(this IWebElement element, string option)
        {
            element.AsSelectElement().SelectByText(option);
        }

        public static void SetText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void PressEnter(this IWebElement element)
        {
            element.SendKeys(Keys.Enter);
        }

        public static void PressTabKey(this IWebElement element)
        {
            element.SendKeys(Keys.Tab);
        }
    }
}
