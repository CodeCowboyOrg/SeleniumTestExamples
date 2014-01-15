using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace SeleniumWebDriver
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class SeleniumWebDriverInvokeJavaScript
    {

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;


        public SeleniumWebDriverInvokeJavaScript()
        {
        }



        [TestInitialize()]
        public void MyTestInitialize()
        {
            baseURL = "http://jqueryui.com/";
            verificationErrors = new StringBuilder();
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }


        private void MoveJQuerySlider(IWebDriver driver, IWebElement widget, int x, int y)
        {            
            Actions actions = new Actions(driver);
            IAction action = actions.ClickAndHold(widget).MoveByOffset(x, y).Release().Build();
            action.Perform();
        }

        
        private void TestJQuerySlider(IWebDriver driver)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));
            IWebElement jquerySlider = driver.FindElement(By.XPath("//div[@id='slider']/a"));
            MoveJQuerySlider(driver, jquerySlider, 20, 0);
            Thread.Sleep(500);
            MoveJQuerySlider(driver, jquerySlider, 20, 0);
            Thread.Sleep(500);
            MoveJQuerySlider(driver, jquerySlider, 20, 0);
            Thread.Sleep(500);
            MoveJQuerySlider(driver, jquerySlider, 20, 0);
            Thread.Sleep(500);
            MoveJQuerySlider(driver, jquerySlider, 20, 0);
            Thread.Sleep(500);
            MoveJQuerySlider(driver, jquerySlider, -20, 0);
            Thread.Sleep(500);
            MoveJQuerySlider(driver, jquerySlider, -20, 0);
            Thread.Sleep(500);
            MoveJQuerySlider(driver, jquerySlider, -20, 0);
            Thread.Sleep(500);
            MoveJQuerySlider(driver, jquerySlider, -20, 0);
            Thread.Sleep(500);
            MoveJQuerySlider(driver, jquerySlider, -20, 0);

            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("$('#slider').slider('option','value', 100)");
            js.ExecuteScript("$('#slider').slider('option','value', 0)");
            js.ExecuteScript("$('#slider').slider('option','value', 80)");
            js.ExecuteScript("$('#slider').slider('option','value', 20)");
            js.ExecuteScript("$('#slider').slider('option','value', 60)");
            js.ExecuteScript("$('#slider').slider('option','value', 40)");
            Thread.Sleep(500);
            Int64 sliderValue = (Int64)js.ExecuteScript("return $('#slider').slider('option','value')");
            js.ExecuteScript("document.title = 'Slider Value Is " + sliderValue.ToString() + "';");
 
            driver.SwitchTo().DefaultContent();
            js.ExecuteScript("document.title = 'Slider Value Is " + sliderValue.ToString() + "';");


        }




        [TestMethod]
        public void FireFoxTestMethod()
        {
            try
            {
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl(baseURL + "/slider/");
                TestJQuerySlider(driver);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw ex;
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                    driver = null;
                }
            }
        }

        [TestMethod]
        public void ChromeTestMethod()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(baseURL + "/slider/");
                TestJQuerySlider(driver);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw ex;
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                    driver = null;
                }
            }
        }


        [TestMethod]
        public void InternetExplorerTestMethod()
        {
            try
            {
                driver = new InternetExplorerDriver();
                driver.Navigate().GoToUrl(baseURL + "/slider/");
                TestJQuerySlider(driver);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw ex;
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                    driver = null;
                }
            }
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
