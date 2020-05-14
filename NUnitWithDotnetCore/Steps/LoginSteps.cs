using BDD_Automation.Context;
using System.Configuration;
using TechTalk.SpecFlow;

namespace BDD_Automation.Steps
{
    [Binding]
    public class LoginSteps : BaseSteps
    {
        private readonly WebDriver webDriver;
        private string _user = System.Environment.GetEnvironmentVariable("TestUser");
        private string _password = System.Environment.GetEnvironmentVariable("TestPassword");
        private string _url = System.Environment.GetEnvironmentVariable("TestUrl");

        public LoginSteps(WebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            _url = string.IsNullOrEmpty(_url) ? "http://demo.guru99.com/V4/" : _url;

            webDriver._driver.Navigate().GoToUrl(_url);

        }

        [Given(@"I have typed username and password")]
        public void GivenIHaveTypedUsernameAndPassword()
        {
            _user = string.IsNullOrEmpty(_user) ? "mngr260908" : _user;
            _password = string.IsNullOrEmpty(_password) ? "UnuhUsy" : _password;
            loginPage.Login(_user, _password);
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
