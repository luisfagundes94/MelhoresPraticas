using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace MelhoresPraticasTp3Testes {

    [TestClass]
    public class UiTest {

        private IWebDriver driver;
        private readonly String BASE_URL = "https://localhost:44304/";

        [TestInitialize]
        public void SetUp() {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            FirefoxOptions options = new FirefoxOptions {
                AcceptInsecureCertificates = true
            };
            //options.AddArgument("--headless");

            driver = new FirefoxDriver(service, options);
            driver.Navigate().GoToUrl(BASE_URL);
        }

        [TestCleanup]
        public void TearDown() {
            driver.Quit();
            driver.Dispose();
        }
        
        [TestMethod]
        public void CanNavigateToCreateStudentPage() {
            driver.Navigate().GoToUrl(BASE_URL + "/Home/Create");
            var firstHeader = driver.FindElement(By.Id("cadastrar"));
            Assert.AreEqual("Cadastrar", firstHeader.Text);
        }

        [TestMethod]
        public void CanCreateANewStudent() {
            driver.Navigate().GoToUrl(BASE_URL + "/Home/Create");
            driver.FindElement(By.Id("Name")).SendKeys("Teste Automatizado");
            driver.FindElement(By.Id("Cpf")).SendKeys("1111111111");
            driver.FindElement(By.Id("Email")).SendKeys("teste@gmail.com");
            driver.FindElement(By.Id("btn_save")).Click();
            driver.Navigate().GoToUrl(BASE_URL);

            var body = driver.FindElement(By.TagName("body"));
            var newStudentName = "Teste Automatizado";

            Assert.IsTrue(body.Text.Contains(newStudentName));
        }
        
    }
}
