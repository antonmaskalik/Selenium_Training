﻿using NUnit.Framework;
using OpenQA.Selenium;

namespace DevbyNews
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.InitDriver();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
