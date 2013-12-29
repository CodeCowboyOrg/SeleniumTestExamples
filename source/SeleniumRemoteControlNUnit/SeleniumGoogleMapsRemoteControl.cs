using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace SeleniumTests
{
    [TestFixture]
    public class SeleniumGoogleMapsRemoteControl
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            //selenium = new DefaultSelenium("localhost", 4444, "*chrome", "https://maps.google.com/");
            selenium = new DefaultSelenium("localhost", 5555, "*iexplore", "https://maps.google.com/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheSeleniumGoogleMapsRemoteControlTest()
        {
            selenium.Open("/");
            selenium.Type("id=gbqfq", "cleveland,oh");
            selenium.Click("id=gbqfb");
            selenium.Click("id=panelimg2");
            selenium.Click("css=div[title=\"Pan down\"]");
            selenium.Click("css=div.mv-primary-preview-lens");
            selenium.Click("css=div[title=\"Zoom In\"]");
            selenium.Click("css=div[title=\"Pan up\"]");
            selenium.Click("css=div[title=\"Pan up\"]");
            selenium.Click("css=div[title=\"Pan right\"]");
            selenium.Click("css=div[title=\"Pan right\"]");
            selenium.Click("css=div[title=\"Pan left\"]");
            selenium.Click("css=div[title=\"Zoom In\"]");
            selenium.Click("css=div[title=\"Zoom In\"]");
            selenium.Click("css=div.mv-primary-label");
            selenium.Click("css=div[title=\"Pan down\"]");
            selenium.Click("css=div[title=\"Pan down\"]");
            selenium.Click("css=div[title=\"Zoom In\"]");
            selenium.Click("css=div[title=\"Zoom In\"]");
            selenium.Click("css=div[title=\"Zoom In\"]");
            selenium.Click("css=div[title=\"Zoom In\"]");
            selenium.Click("css=div[title=\"Zoom In\"]");
        }
    }
}
