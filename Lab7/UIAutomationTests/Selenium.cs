using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;

namespace UIAutomationTests
{
    public class Selenium
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
        }

        [Test]
        public void Enter_To_List_Of_Countries_Test()
        {
            // Arrange
            string url = "http://localhost:8080/";
            driver.Manage().Window.Maximize();
            // Act
            driver.Navigate().GoToUrl(url);
            // Assert
            Assert.IsNotNull(driver);
        }

        [Test]
        public void Create_new_country()
        {
            // Arrange
            string url = "http://localhost:8080/";
            string countryName = "India";
            string countryContinent = "Asia";
            string countryLanguage = "Hindi";
            driver.Manage().Window.Maximize();
            // Act
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("addbtn")).Click();

            driver.FindElement(By.Id("name")).SendKeys(countryName);
            driver.FindElement(By.Id("continente")).SendKeys(countryContinent);
            driver.FindElement(By.Id("idioma")).SendKeys(countryLanguage);

            driver.FindElement(By.Id("submit")).Click();
            // Assert
            IWebElement table = driver.FindElement(By.TagName("tbody"));
            ReadOnlyCollection<IWebElement> data = table.FindElements(By.TagName("span"));
            IWebElement countryIndia = null;
            foreach (IWebElement element in data)
            {
                if (element.Text == countryName)
                {
                    countryIndia = element;
                }
            }
            Assert.IsNotNull(countryIndia);
        }
    }
}
