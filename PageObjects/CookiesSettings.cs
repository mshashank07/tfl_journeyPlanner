using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tfl_test.Support;

namespace tfl_test.PageObjects
{
    public class CookiesSettings : BaseStep
    {
        public IWebDriver driver;
        public CookiesSettings(IWebDriver Driver)
        {
            driver = Driver;
        }
        public IWebElement btnDone => driver.FindElement(By.XPath("//button[contains(text(),'Done')]"));

        public void ClickDone()
        {
           btnDone.Click();
        }

    }
}
