using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace BBCNews.Pages
{
    public class NewsPage : BasePage
    {
        const int ONE = 1;
        private By _paginationCurrentNumber = By.XPath("//*[contains (@class, 'pagination-current-page')]");
        private By _paginationTotalNumber = By.XPath("//*[contains (@class, 'pagination-total-page')]");
        private By _newsHeaders  = By.XPath("//*[@class='lx-stream-post__header-text gs-u-align-middle']");

        [FindsBy(How = How.XPath, Using = "(//*[@class='nw-o-link'])[6]")]
        private IWebElement _WorldBtn;

        [FindsBy(How = How.XPath, Using = "//*[@rel='next']")]
        private IWebElement _nextPageNewsBtn;

        [FindsBy(How = How.XPath, Using = "//*[@rel='last']")]
        private IWebElement _lastPageNewsBtn;

        public NewsPage(IWebDriver driver) : base(driver) { }

        public void GoToNewsOfWorld()
        {
            _WorldBtn.Click();
        }

        public int GetCurrentNumberNewsPage()
        {
            return int.Parse(driver.FindElement(_paginationCurrentNumber).Text);
        }

        public void GoToNextPageNews()
        {
            _nextPageNewsBtn.Click();

            WaitPageLoad();
        }

        public bool IsNextPageNewsOpened(int currentPage, int nextPage)
        {      
            return nextPage - currentPage == ONE;
        }

        public void GoToLastPageNews()
        {
            _lastPageNewsBtn.Click();
        }

        public bool IsLastPageNewsOpened()
        {
            return GetCurrentNumberNewsPage() == int.Parse(driver.FindElement(_paginationTotalNumber).Text);
        }

        public List<string> GetNewsHeaders()
        {
            List<string> headers = new List<string>();

            foreach (var element in driver.FindElements(_newsHeaders))
            {
                headers.Add(element.Text);
            }

            return headers;
        }
    }
}
