using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBCNews.Pages
{
    public class HomePage : BasePage
    {
        const string URL = "https://www.bbc.com/";
        const string USER_NAME = "Your account";

        private By _header = By.Id("orb-header");
        private By _moduleLanguages = By.XPath("//*[@class='module module--highlight module--languages']");
        private By _footer = By.Id("orb-footer");
        private By _title = By.XPath("//*[@class='module module--header']/h2/span");
        private By _singInBtn = By.Id("idcta-username");
        private By _userNameBox = By.Id("user-identifier-input");
        private By _passwordBox = By.Id("password-input");
        private By _submitBtn = By.Id("submit-button");

        [FindsBy(How = How.ClassName, Using = "orb-nav-newsdotcom")]
        private IWebElement _newsBtn;

        [FindsBy(How = How.Id, Using = "orbit-search-button")]
        private IWebElement _searchBtn;

        public HomePage(IWebDriver driver) : base(driver) { }

        public void GoToUrl()
        {
            driver.Navigate().GoToUrl(URL);
        }

        public bool IsHomePageOpend()
        {
            return IsElementVisible(_title);
        }

        public bool IsHeaderVisible()
        {
            return IsElementVisible(_header);
        }

        public bool IsModuleLanguagesVisible()
        {
            return IsElementVisible(_moduleLanguages);
        }

        public bool IsFootrVisible()
        {
            return IsElementVisible(_footer);
        }

        public void GoToNewsPage()
        {
            _newsBtn.Click();
        }

        public void GoToSearchPage()
        {
            _searchBtn.Click();
        }

        public void SingIn(string userName, string password)
        {
            driver.FindElement(_singInBtn).Click();

            WaitElement(_userNameBox);

            driver.FindElement(_userNameBox).SendKeys(userName);
            driver.FindElement(_passwordBox).SendKeys(password);
            driver.FindElement(_submitBtn).Click();
        }

        public bool IsUserSingedIn()
        {
            WaitElement(_singInBtn);

            return driver.FindElement(_singInBtn).Text == USER_NAME;
        }
    }
}
