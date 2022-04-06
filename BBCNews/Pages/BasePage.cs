using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace BBCNews.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public bool IsElementVisible(By searchElementBy)
        {
            try
            {
                bool result = driver.FindElement(searchElementBy).Displayed;
                return result;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void WaitPageLoad()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(e => driver.PageSource != null);
        }

        public void WaitElement(By element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(e => IsElementVisible(element));
        }
    }
}
