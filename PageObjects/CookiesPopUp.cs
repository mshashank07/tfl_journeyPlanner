using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfl_test.PageObjects
{
    public class CookiesPopUp
    {
        public IWebDriver driver;
        public CookiesPopUp(IWebDriver Driver)
        {
            driver = Driver;
        }

        public IWebElement acceptCookies => driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));

        
        public void ClickAcceptCookies() => acceptCookies.Click();

        

    }
}
