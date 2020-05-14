using OpenQA.Selenium;
using BDD_Automation.Context;

namespace BDD_Automation.Pages
{
    public class LoginPage : BasePage
    {
        private readonly WebDriver driver;
        readonly Logging.Logger log = new Logging.Logger();
        private By TxtUserName => By.Name("uid");
        private By TxtPassword => By.Name("password");
        private By BtnLogin => By.Name("btnLogin");

        //public LoginPage(Driver driver, Assert assert) : base(driver, assert) { }

        public LoginPage(WebDriver _driver)
        {
            this.driver = _driver;
        }

        public void Login(string userName, string password)
        {
            log.Info("Login with username: " + userName + " and password: " + password);
            driver.SendKeys(TxtUserName, userName, "Enter text in UserName");
            driver.SendKeys(TxtPassword, password, "Enter text in password");
        }

        public HomePage ClickLogin()
        {
            log.Info("Click Login button");
            driver.FindElement(BtnLogin).Click();
            return new HomePage(driver);
        }
    }
}
