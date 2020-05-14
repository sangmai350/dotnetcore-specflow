using OpenQA.Selenium;
using BDD_Automation.Context;

namespace BDD_Automation.Pages
{
    public class HomePage : BasePage
    {
        private By HmbrgrMenu => By.CssSelector("marquee.heading3");
        private By TxtSrUsName => By.Id("searchByParamInput");

        private readonly WebDriver driver;
        readonly Logging.Logger log = new Logging.Logger();

        public HomePage(WebDriver _driver)
        {
            this.driver = _driver;
        }

        public void VerifyHomePage()
        {
            try
            {
                log.Info("Wait For Hamburger menu displayed");
                driver.WaitForCondition(driver => driver.FindElement(HmbrgrMenu).Displayed, "Wait for Hamberger menu to appear");
            }
            catch
            {
                Assert.Fail("Home Page was not loaded");
            }
        }
    }
}
