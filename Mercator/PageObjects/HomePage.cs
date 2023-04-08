using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CdtTimesheet.Common;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CdtTimesheet.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver _webDriver;
        private readonly string _siteUrl = TestContext.Parameters["SiteUrl"];
        private readonly By _createButton = By.XPath("//a[contains (text(), 'Create New')]");
        private readonly By _timesheetTable = By.CssSelector("tbody");
        private readonly By _allClickableBtns = By.CssSelector("td > a");
        private readonly By _allTimesheetsId = By.CssSelector("td:nth-child(2)");
        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void NavigateToHomePage()
        {
            _webDriver.Navigate().GoToUrl(_siteUrl);
        }

        public void ClickCreate()
        {
            _webDriver.FindElement(_createButton).Click();
        }

        public string CheckTimesheetsTable()
        {
            return _webDriver.FindElement(_timesheetTable).Text;
        }

        public void ClickEditBtnForCreatedEntry(string guidToEdit)
        {
            IList<IWebElement> allClickableBtns = _webDriver.FindElements(_allClickableBtns);
            var firstHrefElement = allClickableBtns.FirstOrDefault(_=>_.GetAttribute("href").Contains(guidToEdit));
            Thread.Sleep(2000);
            firstHrefElement?.Click();
        }
        public void ClickDeleteBtnForCreatedEntry(string guidToEdit)
        {
            IList<IWebElement> allClickableBtns = _webDriver.FindElements(_allClickableBtns);
            var lastHrefElement = allClickableBtns.Last(_ => _.GetAttribute("href").Contains(guidToEdit));
            Thread.Sleep(2000);
            lastHrefElement?.Click();
        }

        public string CheckTimesheetGuidInList()
        {
            _webDriver.WaitForElement(_allTimesheetsId, 10);
            string allTimesheetId = _webDriver.FindElement(_allTimesheetsId).Text;
            return allTimesheetId;
        }
    }
}
