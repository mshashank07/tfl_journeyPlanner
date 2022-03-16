using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfl_test.PageObjects
{
    public class JourneyResultsPage
    {
        public IWebDriver driver;
        public JourneyResultsPage(IWebDriver Driver)
        {
            driver = Driver;
        }

        public IWebElement btnEditJourney => driver.FindElement(By.LinkText("Edit Journey"));
        public IWebElement inputEditFrom => driver.FindElement(By.Id("InputFrom"));
        public IWebElement inputEditTo => driver.FindElement(By.Id("InputTo"));
        public IWebElement btnUpdateJourney => driver.FindElement(By.Id("plan-journey-button"));

        public IWebElement journeyResultSummary => driver.FindElement(By.ClassName("journey-result-summary"));
        public IWebElement journeyfieldValidationError => driver.FindElement(By.ClassName("field-validation-errors"));

        public void InputFrom(string fromAddress) => inputEditFrom.SendKeys(fromAddress);

        public void ClickUpdateJourney() => btnUpdateJourney.Click();


    }
}
