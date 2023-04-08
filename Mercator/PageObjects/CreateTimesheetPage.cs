using CdtTimesheet.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CdtTimesheet.PageObjects
{
    public class CreateTimesheetPage
    {
        private IWebDriver _webDriver;
        private readonly By _employeeIdElement = By.Id("Timesheet_EmployeeId");
        private readonly By _hourlyRateElement = By.Id("Timesheet_HourlyRate");
        private readonly By _daysListElement = By.Id("newEntry_Day");
        private readonly By _hrsElement = By.Id("newEntry_Hours");
        private readonly By _minsElement = By.Id("newEntry_Minutes");
        private readonly By _addRowElement = By.Id("add-row");
        private readonly By _saveBtn = By.CssSelector("input[value='Save']");

        public  CreateTimesheetPage(IWebDriver _webDriver)
        {
            this._webDriver = _webDriver;
        }

        public void EnterEmployeeIdHourRate(string employeeId, string hourlyRate)
        {
            _webDriver.FindElement(_employeeIdElement)
                .ClearAndSendKeys(employeeId);
            _webDriver.FindElement(_hourlyRateElement).ClearAndSendKeys(hourlyRate);
        }
        public void EnterDayHrsMins(string day, string hrs, string mins)
        {
            var daysList = _webDriver.FindElement(_daysListElement);
            var select = new SelectElement(daysList);
            select.SelectByText(day);

            _webDriver.FindElement(_hrsElement).ClearAndSendKeys(hrs);
            _webDriver.FindElement(_minsElement).ClearAndSendKeys(mins);
            _webDriver.FindElement(_addRowElement).Click();
        }
        public void ClickSaveBtn()
        {
            _webDriver.FindElement(_saveBtn).Click();
        }
    }
}
