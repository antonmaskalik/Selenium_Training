using NUnit.Framework;
using BBCNews.Pages;
using System.Collections.Generic;

namespace BBCNews
{
    [TestFixture]
    public class BBCNewsTest : BaseTest
    {
        const string NEWS_HEADER_1 = "war";
        const string NEWS_HEADER_2 = "UA";
        const string NEWS_HEADER_3 = "world";
        const string USER_NAME = "anton.maskalik@gmail.com";
        const string PASSWORD = "!qaz!QAZ";

        [Test]
        public void HomePageTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.GoToUrl();

            Assert.IsTrue(homePage.IsHomePageOpend());
            Assert.IsTrue(homePage.IsHeaderVisible());
            Assert.IsTrue(homePage.IsModuleLanguagesVisible());
            Assert.IsTrue(homePage.IsFootrVisible());
        }

        [Test]
        public void PaginationTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.GoToUrl();
            homePage.GoToNewsPage();

            NewsPage newsPage = new NewsPage(driver);
            newsPage.GoToNewsOfWorld();
            int initialNumberNewsPage = newsPage.GetCurrentNumberNewsPage();
            newsPage.GoToNextPageNews();

            Assert.IsTrue(newsPage.IsNextPageNewsOpened(initialNumberNewsPage, newsPage.GetCurrentNumberNewsPage()));

            newsPage.GoToLastPageNews();

            Assert.IsTrue(newsPage.IsLastPageNewsOpened());
        }

        [Test]
        public void GoToNextPageNewsTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.GoToUrl();
            homePage.GoToNewsPage();

            NewsPage newsPage = new NewsPage(driver);
            newsPage.GoToNewsOfWorld();
            List<string> initialNewsHeaders = newsPage.GetNewsHeaders();
            newsPage.GoToNextPageNews();

            Assert.AreNotEqual(initialNewsHeaders, newsPage.GetNewsHeaders());
        }

        [TestCase(NEWS_HEADER_1)]
        [TestCase(NEWS_HEADER_2)]
        [TestCase(NEWS_HEADER_3)]
        public void SearchTest(string newsHeader)
        {
            HomePage homePage = new HomePage(driver);
            homePage.GoToUrl();
            homePage.GoToSearchPage();

            SearchPage searchPage = new SearchPage(driver);
            searchPage.SearchNews(newsHeader);

            Assert.IsTrue(searchPage.IsNewsFound(newsHeader));
        }

        [TestCase(USER_NAME, PASSWORD)]
        public void SignInTest(string userName, string password)
        {
            HomePage homePage = new HomePage(driver);
            homePage.GoToUrl();
            homePage.SingIn(userName, password);

            Assert.IsTrue(homePage.IsUserSingedIn());
        }
    }
}