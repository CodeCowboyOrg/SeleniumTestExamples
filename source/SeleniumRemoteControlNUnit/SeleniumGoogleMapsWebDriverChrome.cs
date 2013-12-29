using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class SeleniumGoogleMapsWebDriverChrome
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            //driver = new FirefoxDriver();
            //driver = new InternetExplorerDriver();
            driver = new ChromeDriver();
            baseURL = "https://maps.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheSeleniumGoogleMapsWebDriverTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("gbqfq")).Clear();
            driver.FindElement(By.Id("gbqfq")).SendKeys("cleveland,oh");
            driver.FindElement(By.Id("gbqfb")).Click();
            driver.FindElement(By.Id("panelimg2")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Pan down\"]")).Click();
            driver.FindElement(By.CssSelector("div.mv-primary-preview-lens")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Zoom In\"]")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Pan up\"]")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Pan up\"]")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Pan right\"]")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Pan right\"]")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Pan left\"]")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Zoom In\"]")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Zoom In\"]")).Click();
            driver.FindElement(By.CssSelector("div.mv-primary-label")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Pan down\"]")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Pan down\"]")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Zoom In\"]")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Zoom In\"]")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Zoom In\"]")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Zoom In\"]")).Click();
            driver.FindElement(By.CssSelector("div[title=\"Zoom In\"]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
