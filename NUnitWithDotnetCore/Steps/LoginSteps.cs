using BDD_Automation.Context;
using System.Configuration;
using TechTalk.SpecFlow;

namespace BDD_Automation.Steps
{
    [Binding]
   public class LoginSteps : BaseSteps
    {
        private readonly WebDriver webDriver;
        private string user = System.Environment.GetEnvironmentVariable("TestUser");
        private string password = System.Environment.GetEnvironmentVariable("TestPassword");
        private readonly string url = System.Environment.GetEnvironmentVariable("TestUrl");

        public LoginSteps(WebDriver driver) : base(driver)
        {
            webDriver = driver;
        }
     
        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            if (string.IsNullOrEmpty(url))
            {
                webDriver._driver.Navigate().GoToUrl("http://demo.guru99.com/V4/");
            } else
            {
                webDriver._driver.Navigate().GoToUrl(url);
            }

        }

        [Given(@"I have typed username and password")]
        public void GivenIHaveTypedUsernameAndPassword()
        {
            //loginPage.Login("mngr251696", "pYpunys");
            if (string.IsNullOrEmpty(user))
            {
                user = "mngr251696";
                password = "pYpunys";
            }
            loginPage.Login(user, password);
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            loginPage.ClickLogin();
        }
     

        [Then(@"I should see the HomePage page")]
        public void ThenIShouldSeeTheHomePagePage()
        {
           homePage.VerifyHomePage();
        }
    }
}
