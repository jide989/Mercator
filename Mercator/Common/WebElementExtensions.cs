using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CdtTimesheet.Common
{
    public static class WebElementExtensions
    {
         public static void ClearAndSendKeys(this IWebElement element, string input)
        {
            element.Clear();
            element.SendKeys(input);
        }

         public static IWebElement WaitForElement(this IWebDriver webDriver, By by, int timeout)
         {
             if (timeout > 0)
             {
                 var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
                 return wait.Until(webDriver => webDriver.FindElement(by));
             }
             var exc = new ElementNotVisibleException();
             throw exc;
        }
    }
}
