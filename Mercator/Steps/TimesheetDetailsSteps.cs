using CdtTimesheet.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CdtTimesheet.Features
{
    [Binding]
    public class TimesheetDetailsSteps
    {
        private readonly TimesheetDetailsPage _timesheetDetailsPage;
        private readonly ScenarioContext _scenarioContext;

        public TimesheetDetailsSteps(TimesheetDetailsPage timesheetDetailsPage, ScenarioContext scenarioContext)
        {
            _timesheetDetailsPage = timesheetDetailsPage;
            _scenarioContext = scenarioContext;
        }

        [Then(@"the timesheet details page is displayed")]
        public void ThenTheTimesheetDetailsPageIsDisplayed()
        {
            //Hard coding "timesheet" string here as it will always be constant
            //once timesheet is edited or created on the timesheet details pg
            Assert.IsTrue(_timesheetDetailsPage.ConfirmTimesheetDetailsPgIsOpen()
                .Contains("Timesheet"));
        }

        [Then(@"the hourly rate is visible")]
        public void ThenTheHourlyRateIsVisible()
        {
            string hourlyRateEntered = _scenarioContext["HourlyRate"].ToString();
            string hourlyRateOnDetailsPg= _timesheetDetailsPage.GetHourlyRate();
            Assert.IsTrue(hourlyRateOnDetailsPg.Contains(hourlyRateEntered));
        }

        [Then(@"the timesheet details page is updated")]
        public void ThenTheTimesheetDetailsPageIsUpdated()
        {
            Assert.IsTrue(_timesheetDetailsPage.GetEntriesRowCount() > 2);
        }


    }
}
