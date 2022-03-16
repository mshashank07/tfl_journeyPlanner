using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace tfl_test.Support
{
    [Binding]
    public class Hooks
    {

        public static IWebDriver driver;

        [BeforeScenario]
        public void InitialiseDriver()
        {
            driver = new ChromeDriver();
            ScenarioContext.Current.Set(driver, "currentDriver");
            ScenarioContext.Current.Set(driver, "defaultDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                ScenarioContext.Current.Get<IWebDriver>("currentDriver").Quit();
                driver = null;
            }
            ScenarioContext.Current.Clear();

        }
        [AfterTestRun]
        public static void StopSeleniumAfterAllTests()
        {
            driver?.Quit();
        }

    }
}
