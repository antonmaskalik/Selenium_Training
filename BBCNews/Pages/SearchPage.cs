using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBCNews.Pages
{
    public class SearchPage : BasePage
    {
        private By _newsHeaders = By.XPath("//*[@role='text']/p/span");

        [FindsBy(How = How.CssSelector, Using = "#search-input")]
        private IWebElement _searchBox;

        public SearchPage(IWebDriver driver) : base(driver) { }

        public void SearchNews(string header)
        {
            _searchBox.SendKeys(header);
            _searchBox.Submit();
        }

        public bool IsNewsFound(string header)
        {
            bool result = false;

            foreach (var element in driver.FindElements(_newsHeaders))
            {
                if (element.Text.ToLower().Contains(header.ToLower()))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
