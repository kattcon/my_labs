using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UIAutomationTests
{
    public class Selenium
    {
        private IWebDriver? _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void Enter_To_List_Of_Countries_Test()
        {
            var URL = "http://localhost:8080/";

            _driver!.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl(URL);

            Assert.That(_driver, Is.Not.Null);
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}