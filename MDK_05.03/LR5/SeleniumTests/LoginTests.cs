using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver driver = null!;
        private WebDriverWait wait = null!;
        private const string BaseUrl = "https://the-internet.herokuapp.com/login";

        [SetUp]
        public void SetUp()
        {
            driver = GlobalTestSetup.Driver;
            wait = GlobalTestSetup.Wait;
        }

        [TearDown]
        public void TearDown()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [Test]
        public void Test1_OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            Assert.That(driver.Title, Is.Not.Null);
        }

        [Test]
        public void Test2_SuccessfulLogin()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector(".fa")).Click();
            
            var h2Element = driver.FindElement(By.CssSelector("h2"));
            Assert.That(h2Element.Text, Is.EqualTo("Secure Area"));
        }

        [Test]
        public void Test3_LoginWithoutUsername()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector(".fa")).Click();
            
            var flashMessage = driver.FindElement(By.Id("flash"));
            Assert.That(flashMessage.Displayed, Is.True);
        }

        [Test]
        public void Test4_LoginWithoutPassword()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.CssSelector(".fa")).Click();
            
            var flashMessage = driver.FindElement(By.Id("flash"));
            Assert.That(flashMessage.Displayed, Is.True);
        }

        [Test]
        public void Test5_LoginWithWrongCredentials()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.Id("username")).SendKeys("wrong");
            driver.FindElement(By.Id("password")).SendKeys("wong");
            driver.FindElement(By.CssSelector(".fa")).Click();
            
            var flashMessage = driver.FindElement(By.Id("flash"));
            Assert.That(flashMessage.Displayed, Is.True);
        }

        [Test]
        public void Test6_VerifyLoginPageElements()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            
            Assert.That(driver.FindElement(By.Id("username")).Displayed, Is.True);
            Assert.That(driver.FindElement(By.Id("password")).Displayed, Is.True);
            Assert.That(driver.FindElement(By.CssSelector(".fa")).Displayed, Is.True);
        }

        [Test]
        public void Test7_VerifyPasswordFieldType()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            
            var passwordField = driver.FindElement(By.XPath("//input[@id='password'][@type='password']"));
            Assert.That(passwordField, Is.Not.Null);
        }

        [Test]
        public void Test8_LoginAndLogout()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector(".fa")).Click();
            
            driver.FindElement(By.CssSelector(".icon-2x")).Click();
            
            var h2Element = driver.FindElement(By.CssSelector("h2"));
            Assert.That(h2Element.Text, Is.EqualTo("Login Page"));
        }

        [Test]
        public void Test9_LogoutAndLoginAgain()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector(".fa")).Click();
            
            driver.FindElement(By.CssSelector(".icon-2x")).Click();
            
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector(".fa")).Click();
            
            var h2Element = driver.FindElement(By.CssSelector("h2"));
            Assert.That(h2Element.Text, Is.EqualTo("Secure Area"));
        }

        [Test]
        public void Test10_XSSInputTest()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var usernameField = driver.FindElement(By.Id("username"));
            usernameField.SendKeys("<script>alert(1)</script>");
            
            Assert.That(usernameField.GetAttribute("value"), Is.EqualTo("<script>alert(1)</script>"));
        }
    }
}
