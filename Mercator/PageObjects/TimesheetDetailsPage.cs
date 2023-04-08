using CdtTimesheet.Common;
using OpenQA.Selenium;

namespace CdtTimesheet.PageObjects
{
    public class TimesheetDetailsPage
    {
        private readonly IWebDriver _webDriver;
        private readonly By _detailsPgHeader = By.CssSelector("main > h1");
        private readonly By _backToListElement = By.XPath("//a[contains (text(), 'Back to List')]");
        private readonly By _hourlyRate = By.CssSelector("dl > dd:nth-child(4)");
        private readonly By _allEntryRows = By.CssSelector("tr");
        private readonly By _deleteBtn = By.CssSelector("input[value = 'Delete']");

        public TimesheetDetailsPage(IWebDriver _webDriver)
        {
            this._webDriver = _webDriver;
        }

        public string ConfirmTimesheetDetailsPgIsOpen()
        {
            _webDriver.WaitForElement(_detailsPgHeader, 10);
            return _webDriver.FindElement(_detailsPgHeader).Text;
        }

        public string GetTimesheetGuid()
        {
            string[] timesheetGuid = _webDriver.FindElement(_detailsPgHeader).Text.Split(' ');
            return timesheetGuid[1];
        }

        public void ClickBackToListBtn()
        {
            _webDriver.FindElement(_backToListElement).Click();
        }

        public string GetHourlyRate()
        {
            return _webDriver.FindElement(_hourlyRate).Text;
        }

        public int GetEntriesRowCount()
        {
            return _webDriver.FindElements(_allEntryRows).Count;
        }

        public void ClickDeleteBtn()
        {
            _webDriver.FindElement(_deleteBtn).Click();
        }
    }
}
