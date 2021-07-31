using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structura.GuiTests.PageObjects
{
    public class MyAccountPage : BasePage
    {
        public MyAccountPage(IWebDriver driver) : base(driver) { }

        public static string Title
        {
            get
            {
                return "My account - My Store";
            }
        }


    }
}
