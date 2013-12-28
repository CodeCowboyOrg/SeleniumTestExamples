using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Selenium;


namespace SeleniumRemoteControlMsTest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class SeleniumMsTestLiveAccountLogin
    {

        private ISelenium selenium;
        private StringBuilder verificationErrors;

        public SeleniumMsTestLiveAccountLogin()
        {
            selenium = new DefaultSelenium("10.33.55.72", 4444, "*chrome", "https://login.live.com/");
            selenium.Start();
            verificationErrors = new StringBuilder();

        }

        [TestMethod]
        public void TestLiveLogin()
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

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
