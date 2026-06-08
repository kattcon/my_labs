using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

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

        [Test]
        public void Create_Country_Test()
        {
            var URL = "http://localhost:8080/";
            var countryName = "Pais Selenium3";

            _driver!.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(URL);

            _driver.FindElement(By.CssSelector("a[href='/country']")).Click();

            _driver.FindElement(By.Id("name")).SendKeys(countryName);
            _driver.FindElement(By.Id("continente")).SendKeys("Asia");
            _driver.FindElement(By.Id("idioma")).SendKeys("Selenium3");

            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            Thread.Sleep(3000);

            Assert.That(_driver.Url, Is.EqualTo(URL));
            Assert.That(_driver.PageSource, Does.Contain(countryName));
        }

        [TearDown]
        public void TearDown()
        {   
            Thread.Sleep(10000);
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}