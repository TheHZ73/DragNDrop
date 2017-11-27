using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace DragAndDrop
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void BeforeTest()
        {
            string directoryForChromeDriver = Directory.GetCurrentDirectory();
            driver = new ChromeDriver(directoryForChromeDriver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }

        [Test]
        public void TestDragNDrop()
        {
            driver.Navigate().GoToUrl(@"http://way2automation.com/way2auto_jquery/droppable.php");

            string login = "TheHZ";
            string password = "Wizard73";
            var loginForm = new LoginForm(driver);
            loginForm.Login(login, password);

            var page = new PageHelpers(driver); 
            page.OpenDroppablePage();
            page.DragAndDrop();
            Assert.True(page.GetDragAndDropResult().Equals("Dropped!"));
        }
    }
}

