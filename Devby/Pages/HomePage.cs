using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DevbyNews.Pages
{
    public class HomePage: BasePage
    {
        const string URL = "https://devby.io/";

        By _currency = By.XPath("//*[@class='marquee--link']");
        By _footer = By.ClassName("footer");
        By _navigationBar = By.ClassName("navbar");

        [FindsBy(How = How.XPath, Using = "(//*[@class='navbar__nav-item'])[1]")]
        private IWebElement _newsBtn;

        public HomePage(IWebDriver driver): base(driver) { }

        public void GoToUrl()
        {
            driver.Navigate().GoToUrl(URL);
        }

        public bool IsHomePageOpened()
        {
            return IsElementVisible(_currency);
        }

        public bool IsFooterVisible()
        {
            return IsElementVisible(_footer);
        }

        public bool IsNavigationBarVisible()
        {
            return IsElementVisible(_navigationBar);
        }

        public void GoToNewsPage()
        {
            _newsBtn.Click();
        }
    }
}
