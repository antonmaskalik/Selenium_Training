using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace DevbyNews.Pages
{
    public class NewsPage : BasePage
    {
        const string SCROLL_COMMAND = "arguments[0].scrollIntoView(true);";

        private By _title = By.XPath("//*[@class='island__body-title']/h1");
        private By _activePaginationItem = By.XPath("//*[@class='pagination__item pagination__item_active']/a");
        private By _newsTitles = By.XPath("//*[@class='card__title card__title_text-crop']");

        [FindsBy(How = How.XPath, Using = "//*[@class='pagination__item-next']")]
        private IWebElement _nextNewsPageBtn;

        public NewsPage(IWebDriver driver) : base(driver) { }

        public bool IsNewsPage()
        {
            return IsElementVisible(_title);
        }

        public string GetActivePaginationItem()
        {
            return driver.FindElement(_activePaginationItem).Text;
        }

        public List<string> GetNewsTitles()
        {
            List<string> titles = new List<string>();

            foreach (var element in driver.FindElements(_newsTitles))
            {
                titles.Add(element.Text);
            }

            return titles;
        }

        public void GoToNextNewsPage()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(SCROLL_COMMAND, _nextNewsPageBtn);
            _nextNewsPageBtn.Click();
        }

        public bool IsNewsExisted(string title)
        {
            bool flag = true;

            while(flag)
            {
                foreach (var element in driver.FindElements(_newsTitles))
                {
                    if (element.Text.Equals(title))
                    {
                        flag = false;

                        break;
                    }
                }

                GoToNextNewsPage();
            }

            return !flag;
        }
    }
}
