using CdtTimesheet.Common;
using CdtTimesheet.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CdtTimesheet.Steps
{
    [Binding]
    public sealed class CreateTimesheetStep
    {
        private readonly CreateTimesheetPage _createTimesheetPage;
        private readonly ScenarioContext _scenarioContext;

        public CreateTimesheetStep(CreateTimesheetPage createTimesheetPage, ScenarioContext scenarioContext)
        {
            _createTimesheetPage = createTimesheetPage;
            _scenarioContext = scenarioContext;
        }

        [When(@"I enter below Employee Id and Hourly Rate")]
        public void WhenIEnterBelowEmployeeIdAndHourlyRate(Table table)
        {
            var timesheetDetails = table.CreateInstance<TimesheetDetails>();
            var employeeId = timesheetDetails.EmployeeId;
            var hourlyRate = timesheetDetails.HourlyRate;
            _scenarioContext.Add("EmployeeId", employeeId);
            _scenarioContext.Add("HourlyRate", hourlyRate);
            _createTimesheetPage.EnterEmployeeIdHourRate(employeeId, hourlyRate);
        }

        [When(@"I enter Timesheet details")]
        public void WhenIEnterTimesheetDetails(Table table)
        {
            var timesheetDetails = table.CreateInstance<TimesheetDetails>();
            var day = timesheetDetails.Day;
            var hours = timesheetDetails.Hours;
            var mins = timesheetDetails.Minutes;
            _createTimesheetPage.EnterDayHrsMins(day, hours, mins);
        }

        [When(@"I click Save button")]
        public void WhenIClickSaveButton()
        {
            _createTimesheetPage.ClickSaveBtn();
        }

    }
}
