using DevbyNews.Pages;
using NUnit.Framework;
using System.Collections.Generic;

namespace DevbyNews
{
    [TestFixture]
    public class DevbyNewsTests : BaseTest
    {
        const string TITLE_NEWS_1 = "В Минске — новые правила очереди за апостилем. Фотофакт";
        const string TITLE_NEWS_2 = "Reuters: Microsoft не будет полностью уходить из России";
        const string TITLE_NEWS_3 = "VironIT организует «коливинг» в отеле в Тбилиси";

        [Test]
        public void HomePageTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.GoToUrl();

            Assert.IsTrue(homePage.IsHomePageOpened());
        }

        [Test]
        public void GoToNewsPageTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.GoToUrl();
            homePage.GoToNewsPage();

            NewsPage newsPage = new NewsPage(driver);
            
            Assert.IsTrue(newsPage.IsNewsPage());
        }

        [Test]
        public void NavigationBarTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.GoToUrl();

            Assert.IsTrue(homePage.IsNavigationBarVisible());
        }


        [Test]
        public void FooterTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.GoToUrl();

            Assert.IsTrue(homePage.IsFooterVisible());
        }

        [Test]
        public void PaginationTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.GoToUrl();
            homePage.GoToNewsPage();

            NewsPage newsPage = new NewsPage(driver);
            string activePaginationItem = newsPage.GetActivePaginationItem();
            newsPage.GoToNextNewsPage();

            Assert.AreNotEqual(activePaginationItem, newsPage.GetActivePaginationItem());
        }

        [Test]
        public void GoToNextNewsPageTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.GoToUrl();
            homePage.GoToNewsPage();

            NewsPage newsPage = new NewsPage(driver);
            List<string> titles = newsPage.GetNewsTitles();
            newsPage.GoToNextNewsPage();

            Assert.AreNotEqual(titles, newsPage.GetNewsTitles());
        }

        [TestCase(TITLE_NEWS_1)]
        [TestCase(TITLE_NEWS_2)]
        [TestCase(TITLE_NEWS_3)]
        public void FindNewsTest(string title)
        {
            HomePage homePage = new HomePage(driver);
            homePage.GoToUrl();
            homePage.GoToNewsPage();

            NewsPage newsPage = new NewsPage(driver);

            Assert.IsTrue(newsPage.IsNewsExisted(title));
        }
    }
}