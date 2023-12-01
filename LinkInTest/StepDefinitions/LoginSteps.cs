using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace LinkInTest.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {

        public static IWebDriver? driver;
        private IWebElement? passwordInput;

        [BeforeFeature]
        public static void InitializeBrowser()

        {
            driver = new ChromeDriver();


        }

        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnThLoginPage()
        {

            driver.Url = "https://linkedin.com";


        }

        [AfterFeature]
        public static void Cleanup()
        {
            driver?.Quit();
        }
       
       

        [When(@"user will enter username '(.*)'")]
        public void WhenUserWillEnterUsername(string un)
        {
            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";


            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            emailInput?.SendKeys(un);

        }

        [When(@"user will enter password '(.*)'")]
        public void WhenUserWillEnterPassword(string pwd)
        {
            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

           passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));


           passwordInput.SendKeys(pwd);
            Console.WriteLine(passwordInput.GetAttribute("value"));


        }

        [When(@"user will click on login button")]
        public void WhenUserWillClickOnLoginButton()
        {
            IJavaScriptExecutor? js = (IJavaScriptExecutor?)driver;

            js?.ExecuteScript("arguments[0].scrollIntoView(true); ",
           driver?.FindElement(By.XPath("//button[@type='submit']")));
            Thread.Sleep(5000);

            js?.ExecuteScript("arguments[0].click(); ",
            driver?.FindElement(By.XPath("//button[@type='submit']")));
        }

        [Then(@"user will be redirected to Homepage")]
        public void ThenUserWillBeRedirectedToHomepage()
        {
            Assert.That(driver.Title.Contains("LinkedIn"));
        }

        [Then(@"Error message for password length should be thrown")]
        public void ThenErrorMessageForPasswordLengthShouldBeThrown()
        {
            IWebElement alertPara = driver.FindElement(By.XPath("//p[@for='session_password']"));

            string? alertText = alertPara.Text;

            Assert.That(alertText.Contains("6 characters"));
         
        }
        [When(@"user will click on show link  in the password textbox")]
        public void WhenUserWillClickOnShowLinkInThePasswordTextbox()
        {
            IWebElement showButton = driver.FindElement(By.XPath("//button[text()='Show']"));
            showButton.Click();
        }

        [Then(@"the password characters should be shown")]
        public void ThenThePasswordCharactersShouldBeShown()
        {

            Assert.That(passwordInput.GetAttribute("type").Equals("text"));
        }
        [When(@"user will click on hide link  in the password textbox")]
        public void WhenUserWillClickOnHideLinkInThePasswordTextbox()
        {
            IWebElement hideButton = driver.FindElement(By.XPath("//button[text()='Hide']"));
            hideButton.Click();
        }

       

        [Then(@"the password characters should not be shown")]
        public void ThenThePasswordCharactersShouldNotBeShown()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("password"));
        }

    }



}

