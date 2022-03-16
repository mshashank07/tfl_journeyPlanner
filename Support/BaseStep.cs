using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace tfl_test.Support
{

    [Binding]
    public class BaseStep { 

        public IWebDriver driver = Hooks.driver;

        public void WaitForPageToLoad()
        {
            GenerateWebDriverWait().Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString().Equals("complete"));
        }

        public void WaitForElement(IWebElement elementLocator)
        {
            GenerateWebDriverWait().Until(d => elementLocator.Displayed);
        }

        public void WaitForElements(IList<IWebElement> elements)
        {
            GenerateWebDriverWait().Until(d => elements.Count > 0);
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            WaitForPageToLoad();
            driver.Manage().Window.Maximize();
            WaitForPageToLoad();
        }

        private WebDriverWait GenerateWebDriverWait(int seconds = 90)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        }

    
    }
}
