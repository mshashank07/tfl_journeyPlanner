using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using tfl_test.PageObjects;
using tfl_test.Support;

namespace tfl_test.StepDefs
{
    public class JourneyPlannerSteps : BaseStep
    {

        private HomePage homePage;
        private JourneyResultsPage journeyResultsPage;
        private CookiesPopUp cookiesPopUp;
        private CookiesSettings cookiesSettings;

        [Given(@"user is on ""([^""]*)""")]
        public void GivenUserIsOnTfl(string url)
        {
            NavigateToUrl(url);
            cookiesPopUp = new CookiesPopUp(driver);
            cookiesPopUp.ClickAcceptCookies();
            cookiesSettings = new CookiesSettings(driver);
            cookiesSettings.ClickDone();

        }


        [When(@"user searches from ""([^""]*)""")]
        public void WhenUserSearchesFrom(string from)
        {
           homePage = new HomePage(driver);  
           homePage.InputFrom(from);
        }

        [When(@"user searches to ""([^""]*)""")]
        public void WhenUserSearchesTo(string to)
        {
            homePage.InputTo(to);
            
        }

        [When(@"user click on Plan my journey")]
        public void WhenUserClickOnPlanMyJourney()
        {
            
            homePage.ClickPlanMyJourney();  
        }

        [Then(@"user should see ""([^""]*)"" on Journey results page")]
        public void ThenUserShouldSeeOnJourneyResultsPage(string expected)
        {
            journeyResultsPage = new JourneyResultsPage(driver);
            var actualResult = journeyResultsPage.journeyResultSummary.Text;
            StringAssert.Contains("Croydon (London), East Croydon Station", actualResult);
            
        }


        [When(@"user searches from postcode ""([^""]*)""")]
        public void WhenUserSearchesFromPostcode(string fromPostcode)
        {
            
            homePage.InputFrom(fromPostcode);
        }

        [When(@"user searches to postcode ""([^""]*)""")]
        public void WhenUserSearchesToPostcode(string toPostcode)
        {
            
            homePage.InputTo(toPostcode);
        }

        [Then(@"user should see an error ""([^""]*)""")]
        public void ThenUserShouldSeeAnError(string expected)
        {
            
            var actualResult = journeyResultsPage.journeyResultSummary.Text;
            StringAssert.Contains(expected, actualResult);
        }


        [When(@"user click on Edit Journey")]
        public void WhenUserClickOnEditJourney()
        {
            
            journeyResultsPage.btnEditJourney.Click();
        }


        [When(@"changes the from field to ""([^""]*)""")]
        public void WhenChangesTheFromFieldTo(string editFrom)
        {
            
            journeyResultsPage.InputFrom(editFrom);
        }

        [When(@"user clicks on Update Journey")]
        public void WhenUserClicksOnUpdateJourney()
        {
            
            journeyResultsPage.ClickUpdateJourney();    
        }

        [When(@"user click on Recents tab")]
        public void WhenUserClickOnRecentsTab()
        {
            
            homePage.ClickRecents();
        }

        [Then(@"user should able to see recent search stations ""([^""]*)""")]
        public void ThenUserShouldAbleToSeeRecentSearchStations(string expected)
        {
            
            var actualResult = homePage.recentJourney.Text;
            Assert.That(actualResult, Is.EqualTo(expected));  
        }

    }
}
