using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests
{
    [TestFixture]
    public class BaseTests
    {
        private IWebDriver driver = null!;
        private WebDriverWait wait = null!;
        private const string BaseUrl = "https://the-internet.herokuapp.com";

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
            driver.Navigate().GoToUrl(BaseUrl + "/");
            Assert.That(driver.Title, Is.Not.Null);
        }

        [Test]
        public void Test2_NavigateToFormAuthentication()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("Form Authentication")).Click();
            
            var h2Element = driver.FindElement(By.CssSelector("h2"));
            Assert.That(h2Element.Text, Is.EqualTo("Login Page"));
        }

        [Test]
        public void Test3_FormAuthenticationLogin()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("Form Authentication")).Click();
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector(".fa")).Click();
        }

        [Test]
        public void Test4_LoginWithInvalidCredentials()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("Form Authentication")).Click();
            driver.FindElement(By.Id("username")).SendKeys("123");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.CssSelector(".fa")).Click();
            
            var flashMessage = driver.FindElement(By.Id("flash"));
            Assert.That(flashMessage.Displayed, Is.True);
        }

        [Test]
        public void Test5_CheckboxesTest()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("Checkboxes")).Click();
            
            var checkbox1 = driver.FindElement(By.CssSelector("input:nth-child(1)"));
            var checkbox2 = driver.FindElement(By.CssSelector("input:nth-child(3)"));
            
            checkbox1.Click();
            checkbox2.Click();
        }

        [Test]
        public void Test6_JavaScriptAlert()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("JavaScript Alerts")).Click();
            driver.FindElement(By.CssSelector("li:nth-child(1) > button")).Click();
            
            IAlert alert = driver.SwitchTo().Alert();
            Assert.That(alert.Text, Is.EqualTo("I am a JS Alert"));
            alert.Accept();
        }

        [Test]
        public void Test7_JavaScriptConfirmCancel()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("JavaScript Alerts")).Click();
            driver.FindElement(By.CssSelector("li:nth-child(2) > button")).Click();
            
            IAlert alert = driver.SwitchTo().Alert();
            Assert.That(alert.Text, Is.EqualTo("I am a JS Confirm"));
            alert.Dismiss();
            
            var result = driver.FindElement(By.Id("result"));
            Assert.That(result.Text, Is.EqualTo("You clicked: Cancel"));
        }

        [Test]
        public void Test8_BrokenImages()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("Broken Images")).Click();
            
            Assert.That(driver.FindElement(By.CssSelector("img:nth-child(2)")).Displayed, Is.True);
            Assert.That(driver.FindElement(By.CssSelector("img:nth-child(3)")).Displayed, Is.True);
            Assert.That(driver.FindElement(By.CssSelector("img:nth-child(4)")).Displayed, Is.True);
        }

        [Test]
        public void Test10_DynamicLoadingHiddenElement()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("Dynamic Loading")).Click();
            driver.FindElement(By.LinkText("Example 1: Element on page that is hidden")).Click();
            driver.FindElement(By.CssSelector("button")).Click();
            
            wait.Until(d => d.FindElement(By.CssSelector("h4:nth-child(1)")).Displayed);
            
            var h4Element = driver.FindElement(By.CssSelector("h4:nth-child(1)"));
            Assert.That(h4Element.Text, Is.EqualTo("Hello World!"));
        }

        [Test]
        public void Test11_InputsTest()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.Manage().Window.Size = new System.Drawing.Size(550, 692);
            driver.FindElement(By.LinkText("Inputs")).Click();
            
            var inputField = driver.FindElement(By.CssSelector("input"));
            inputField.Click();
            inputField.SendKeys("123");
            
            Assert.That(inputField.GetAttribute("value"), Is.EqualTo("123"));
        }

        [Test]
        public void Test12_DropdownTest()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.Manage().Window.Size = new System.Drawing.Size(550, 692);
            driver.FindElement(By.LinkText("Dropdown")).Click();
            
            var dropdown = new SelectElement(driver.FindElement(By.Id("dropdown")));
            dropdown.SelectByText("Option 2");
            
            Assert.That(dropdown.SelectedOption.GetAttribute("value"), Is.EqualTo("2"));
        }

        [Test]
        public void Test13_SortableDataTablesVerifyFirstRow()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("Sortable Data Tables")).Click();
            
            var firstCell = driver.FindElement(By.CssSelector("#table1 tr:nth-child(1) > td:nth-child(1)"));
            Assert.That(firstCell.Text, Is.EqualTo("Smith"));
        }

        [Test]
        public void Test14_SortableDataTablesSorting()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("Sortable Data Tables")).Click();
            driver.FindElement(By.CssSelector("#table1 .header:nth-child(1) > span")).Click();
            
            var firstCell = driver.FindElement(By.CssSelector("#table1 tr:nth-child(1) > td:nth-child(1)"));
            Assert.That(firstCell.Text, Is.EqualTo("Bach"));
        }

        [Test]
        public void Test15_FileUploadPageElements()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("File Upload")).Click();
            
            Assert.That(driver.FindElement(By.Id("file-upload")).Displayed, Is.True);
            Assert.That(driver.FindElement(By.Id("file-submit")).Displayed, Is.True);
        }

        [Test]
        public void Test16_AddRemoveElements()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("Add/Remove Elements")).Click();
            driver.FindElement(By.CssSelector("button")).Click();
            
            Assert.That(driver.FindElement(By.CssSelector(".added-manually")).Displayed, Is.True);
            
            driver.FindElement(By.CssSelector(".added-manually")).Click();
            
            Assert.That(driver.FindElements(By.CssSelector(".added-manually")).Count, Is.EqualTo(0));
        }

        [Test]
        public void Test17_FileUploadSubmitWithoutFile()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("File Upload")).Click();
            driver.FindElement(By.Id("file-submit")).Click();
        }

        [Test]
        public void Test18_HoverTest()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("Hovers")).Click();
            
            var actions = new Actions(driver);
            var figure1 = driver.FindElement(By.CssSelector(".figure:nth-child(3) > img"));
            actions.MoveToElement(figure1).Perform();
            
            var caption1 = driver.FindElement(By.CssSelector(".figure:nth-child(3) h5"));
            Assert.That(caption1.Text, Is.EqualTo("name: user1"));
            
            var figure2 = driver.FindElement(By.CssSelector(".figure:nth-child(4) > img"));
            actions.MoveToElement(figure2).Perform();
            
            var caption2 = driver.FindElement(By.CssSelector(".figure:nth-child(4) h5"));
            Assert.That(caption2.Text, Is.EqualTo("name: user2"));
        }

        [Test]
        public void Test19_DynamicControlsEnableInput()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("Dynamic Controls")).Click();
            driver.FindElement(By.CssSelector("#input-example > button")).Click();
            
            wait.Until(d => d.FindElement(By.CssSelector("#input-example > input")).Enabled);
        }

        [Test]
        public void Test20_StatusCodesNavigation()
        {
            driver.Navigate().GoToUrl(BaseUrl + "/");
            driver.FindElement(By.LinkText("Status Codes")).Click();
            driver.FindElement(By.LinkText("200")).Click();
            driver.FindElement(By.LinkText("here")).Click();
            
            var h3Element = driver.FindElement(By.CssSelector("h3"));
            Assert.That(h3Element.Text, Is.EqualTo("Status Codes"));
        }
    }
}
