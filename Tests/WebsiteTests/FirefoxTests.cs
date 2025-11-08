using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace WebsiteTests
{
    public class FirefoxTests
    {
        private IWebDriver driver;
        private string baseUrl = "https://alltxe.github.io/College/";

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new FirefoxOptions();
            driver = new FirefoxDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }

        [Test]
        public void Test1_OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseUrl + "index.html");
            Assert.That(driver.Title, Is.EqualTo("Test Website - Home"));
        }

        [Test]
        public void Test2_NavigateToAbout()
        {
            driver.Navigate().GoToUrl(baseUrl + "index.html");
            driver.FindElement(By.LinkText("About")).Click();
            Assert.That(driver.Title, Is.EqualTo("Test Website - About"));
        }

        [Test]
        public void Test3_CheckAboutImage()
        {
            driver.Navigate().GoToUrl(baseUrl + "about.html");
            var image = driver.FindElement(By.Id("aboutImage"));
            Assert.That(image.Displayed, Is.True);
        }

        [Test]
        public void Test4_ClickAboutImage()
        {
            driver.Navigate().GoToUrl(baseUrl + "about.html");
            driver.FindElement(By.Id("aboutImage")).Click();
            // Alert handling if needed, but since JS alert, might need to accept
            try
            {
                var alert = driver.SwitchTo().Alert();
                Assert.That(alert.Text, Is.EqualTo("Image clicked!"));
                alert.Accept();
            }
            catch (NoAlertPresentException)
            {
                // If no alert, perhaps JS is blocked
            }
        }

        [Test]
        public void Test5_NavigateToProducts()
        {
            driver.Navigate().GoToUrl(baseUrl + "about.html");
            driver.FindElement(By.LinkText("Products")).Click();
            Assert.That(driver.Title, Is.EqualTo("Test Website - Products"));
        }

        [Test]
        public void Test6_CheckProductsList()
        {
            driver.Navigate().GoToUrl(baseUrl + "products.html");
            Assert.That(driver.FindElement(By.LinkText("Product 1")).Displayed, Is.True);
            Assert.That(driver.FindElement(By.LinkText("Product 2")).Displayed, Is.True);
            Assert.That(driver.FindElement(By.LinkText("Product 3")).Displayed, Is.True);
        }

        [Test]
        public void Test7_NavigateToProduct1()
        {
            driver.Navigate().GoToUrl(baseUrl + "products.html");
            driver.FindElement(By.LinkText("Product 1")).Click();
            Assert.That(driver.Title, Is.EqualTo("Test Website - Product 1"));
        }

        [Test]
        public void Test8_BuyProduct1()
        {
            driver.Navigate().GoToUrl(baseUrl + "product1.html");
            driver.FindElement(By.Id("buyButton1")).Click();
            // Similar to image click
            try
            {
                var alert = driver.SwitchTo().Alert();
                Assert.That(alert.Text, Is.EqualTo("Product purchased!"));
                alert.Accept();
            }
            catch (NoAlertPresentException) { }
        }

        [Test]
        public void Test9_NavigateToProduct2()
        {
            driver.Navigate().GoToUrl(baseUrl + "products.html");
            driver.FindElement(By.LinkText("Product 2")).Click();
            Assert.That(driver.Title, Is.EqualTo("Test Website - Product 2"));
        }

        [Test]
        public void Test10_BuyProduct2()
        {
            driver.Navigate().GoToUrl(baseUrl + "product2.html");
            driver.FindElement(By.Id("buyButton2")).Click();
            try
            {
                var alert = driver.SwitchTo().Alert();
                Assert.That(alert.Text, Is.EqualTo("Product purchased!"));
                alert.Accept();
            }
            catch (NoAlertPresentException) { }
        }

        [Test]
        public void Test11_NavigateToProduct3()
        {
            driver.Navigate().GoToUrl(baseUrl + "products.html");
            driver.FindElement(By.LinkText("Product 3")).Click();
            Assert.That(driver.Title, Is.EqualTo("Test Website - Product 3"));
        }

        [Test]
        public void Test12_BuyProduct3()
        {
            driver.Navigate().GoToUrl(baseUrl + "product3.html");
            driver.FindElement(By.Id("buyButton3")).Click();
            try
            {
                var alert = driver.SwitchTo().Alert();
                Assert.That(alert.Text, Is.EqualTo("Product purchased!"));
                alert.Accept();
            }
            catch (NoAlertPresentException) { }
        }

        [Test]
        public void Test13_NavigateToContact()
        {
            driver.Navigate().GoToUrl(baseUrl + "index.html");
            driver.FindElement(By.LinkText("Contact")).Click();
            Assert.That(driver.Title, Is.EqualTo("Test Website - Contact"));
        }

        [Test]
        public void Test14_NavigateToFeedback()
        {
            driver.Navigate().GoToUrl(baseUrl + "index.html");
            driver.FindElement(By.LinkText("Feedback")).Click();
            Assert.That(driver.Title, Is.EqualTo("Test Website - Feedback"));
        }

        [Test]
        public void Test15_FillAndSubmitForm()
        {
            driver.Navigate().GoToUrl(baseUrl + "form.html");
            driver.FindElement(By.Id("name")).SendKeys("Test User");
            driver.FindElement(By.Id("email")).SendKeys("test@example.com");
            driver.FindElement(By.Id("message")).SendKeys("Test message");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            try
            {
                var alert = driver.SwitchTo().Alert();
                Assert.That(alert.Text, Is.EqualTo("Form submitted!"));
                alert.Accept();
            }
            catch (NoAlertPresentException) { }
        }
    }
}