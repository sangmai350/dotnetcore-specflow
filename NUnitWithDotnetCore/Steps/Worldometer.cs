using BDD_Automation.Context;
using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;

namespace BDD_Automation.Steps
{
    [Binding]
    public class Worldometer : BaseSteps
    {
        private readonly WebDriver webDriver;
        private string user = System.Environment.GetEnvironmentVariable("TestUser");
        private string password = System.Environment.GetEnvironmentVariable("TestPassword");
        private readonly string url = System.Environment.GetEnvironmentVariable("TestUrl");
        public string attribute;

        public Worldometer(WebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        [Given(@"I open Worldometer site")]
        public void GivenIOpenWorldometerSite()
        {
            if (string.IsNullOrEmpty(url))
            {
                webDriver._driver.Navigate().GoToUrl("https://www.worldometers.info/coronavirus/");
            }
            else
            {
                webDriver._driver.Navigate().GoToUrl(url);
            }
        }

        [Then(@"I saw the header")]
        public void ThenISawTheHeader()
        {
            attribute = (webDriver._driver.FindElement(By.Id("page-top"))).GetAttribute("class");
            Assert.Equals(attribute, "label-counter");
        }
    }
}
