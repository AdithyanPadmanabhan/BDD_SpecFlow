using BunnyCart.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.DevTools;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace BunnyCart.StepDefinitions
{
    [Binding]
    internal class SearchSteps : CoreCodes
    {
        public static IWebDriver? driver;
       

        [BeforeFeature]
        public static void InitializeBrowser()

        {
            driver = new ChromeDriver();


        }


        [AfterFeature]
        public static void Cleanup()
        {
            driver?.Quit();
        }
        [BeforeFeature]
        public static void LogFileLocation()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/SearchFeature_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
        }

        [AfterScenario]
        public static void NavigateToHomePage()
        {
            driver?.Navigate().GoToUrl("https://www.bunnycart.com/");
        }

        [Given(@"User will be on the HomePage")]
        public void GivenUserWillBeOnTheHomePage()
        {
            driver.Url = "https://www.bunnycart.com/";
        }

        [When(@"User will type the '([^']*)' in the searchbox")]
        public void WhenUserWillTypeTheInTheSearchbox(string searchText)
        {
            IWebElement? searchinput = driver.FindElement(By.Id("search"));
            searchinput.SendKeys(searchText);
            searchinput.SendKeys(Keys.Enter);
        }

       

        [Then(@"search results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchText)
        {

          
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains(searchText));
                LogTestResult(" Search Test - Pass", "Search success");
            }
            catch (AssertionException ex)
            {
               
                LogTestResult("Search Test",
                  "Search Test failed", ex.Message);
            }


        }
    }
}
