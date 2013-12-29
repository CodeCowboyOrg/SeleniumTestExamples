using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace SeleniumTests
{
    [TestFixture]
    public class SeleniumLiveAccountLogin
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "https://login.live.com/");
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
        public void TheSeleniumLiveAccountLoginTest()
        {
            selenium.Open("/login.srf?wa=wsignin1.0&rpsnv=12&ct=1388204572&rver=6.4.6456.0&wp=MBI&wreply=http:%2F%2Fmail.live.com%2Fdefault.aspx&lc=1033&id=64855&mkt=en-us&cbcxt=mai&snsc=1");
            selenium.WindowMaximize();
            selenium.Type("id=i0116", "SomeEmail@live.com");
            selenium.Type("id=i0118", "SomePassword");
            selenium.Click("id=idSIButton9");            
            selenium.WaitForPageToLoad("30000");
            Thread.Sleep(3000);
            selenium.Click("id=c_meun");
            Thread.Sleep(3000);
            selenium.Click("id=c_signout");
            selenium.WaitForPageToLoad("30000");
            Thread.Sleep(3000);

        }
    }
}
