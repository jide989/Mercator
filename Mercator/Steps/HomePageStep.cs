using CdtTimesheet.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CdtTimesheet.Features
{
    [Binding]
    public class HomePageStep
    {
        private readonly HomePage _homePage;
        private readonly TimesheetDetailsPage _timesheetDetailsPage;
        private readonly ScenarioContext _scenarioContext;

        public HomePageStep(HomePage homePage, TimesheetDetailsPage timesheetDetailsPage, ScenarioContext scenarioContext)
        {
            _homePage = homePage;
            _timesheetDetailsPage = timesheetDetailsPage;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have navigated to Timesheets WebApp")]
        public void GivenIHaveNavigatedToTimesheetsWebApp()
        {
            _homePage.NavigateToHomePage();
        }

        [When(@"I click on Create button")]
        public void WhenIClickOnCreateButton()
        {
            _homePage.ClickCreate();
        }

        [Then(@"the timesheet record is created in the timesheet list")]
        public void ThenTheTimesheetRecordIsCreatedInTheTimesheetList()
        {
            _timesheetDetailsPage.ClickBackToListBtn();
            string employeeId = _scenarioContext["EmployeeId"].ToString();
            Assert.IsTrue(_homePage.CheckTimesheetsTable().Contains(employeeId));
        }

        [When(@"I click edit button for the timesheet entry to edit from timesheets list")]
        public void WhenIClickEditButtonForTheTimesheetEntryToEditFromTimesheetsList()
        {
           //Get the Timesheet Guid and add to dictionary for later use
            var timesheetGuid = _timesheetDetailsPage.GetTimesheetGuid();
            _scenarioContext.Add("TimesheetGuid", timesheetGuid);
            string guidToEdit = _scenarioContext["TimesheetGuid"].ToString();
            
            _timesheetDetailsPage.ClickBackToListBtn();
            _homePage.ClickEditBtnForCreatedEntry(guidToEdit);
        }

        [When(@"I delete the timesheet entry from timesheets list")]
        public void WhenIDeleteTheTimesheetEntryFromTimesheetsList()
        {
            //Get the Timesheet Guid and add to dictionary for later use
            var timesheetGuid = _timesheetDetailsPage.GetTimesheetGuid();
            _scenarioContext.Add("TimesheetGuid", timesheetGuid);
            string guidToEdit = _scenarioContext["TimesheetGuid"].ToString();

            _timesheetDetailsPage.ClickBackToListBtn();
            _homePage.ClickDeleteBtnForCreatedEntry(guidToEdit);
            _timesheetDetailsPage.ClickDeleteBtn();
        }

        [Then(@"the timesheet entry is deleted")]
        public void ThenTheTimesheetEntryIsDeleted()
        {
            string timesheetGuid = _scenarioContext["TimesheetGuid"].ToString();
            Assert.IsFalse(_homePage.CheckTimesheetGuidInList().Contains(timesheetGuid));
        }

    }
}
