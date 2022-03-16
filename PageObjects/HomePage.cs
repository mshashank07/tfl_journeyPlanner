using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tfl_test.Support;

namespace tfl_test.PageObjects
{
    public class HomePage :BaseStep
    {
        public IWebDriver driver;
        public HomePage(IWebDriver Driver)
        {
            driver = Driver;  
        }

        public IWebElement inputFrom => driver.FindElement(By.Id("InputFrom"));
        public IWebElement inputTo => driver.FindElement(By.Id("InputTo"));
        public IWebElement btnPlanMyJourney => driver.FindElement(By.Id("plan-journey-button"));
        public IWebElement btnRecents => driver.FindElement(By.LinkText("Recents"));

        public IWebElement recentJourney => driver.FindElement(By.LinkText("jp-recent-content-home-"));


        public void ClickPlanMyJourney() => btnPlanMyJourney.Click();
        public void ClickRecents() => btnRecents.Click();    

        public void InputFrom(string fromAddress) => inputFrom.SendKeys(fromAddress);
       
        public void InputTo(string toAddress)
        {
            
            inputTo.SendKeys(toAddress);
            WaitForElement(btnPlanMyJourney);

        }


    }
}
