using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests
{
    [SetUpFixture]
    public class GlobalTestSetup
    {
        public static IWebDriver Driver { get; private set; } = null!;
        public static WebDriverWait Wait { get; private set; } = null!;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            var headlessMode = false;
            var maximizeWindow = true;

            var options = new ChromeOptions();

            if (headlessMode)
            {
                options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");
            }

            if (maximizeWindow)
            {
                options.AddArgument("--start-maximized");
            }


            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddExcludedArgument("enable-automation");
            
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);
            
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--disable-infobars");

            Driver = new ChromeDriver(options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            System.Console.WriteLine("ChromeDriver успешно запущен!");
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {

            System.Threading.Thread.Sleep(2000);
            
            Driver?.Quit();
            System.Console.WriteLine("Все тесты завершены!");
        }
    }
}
