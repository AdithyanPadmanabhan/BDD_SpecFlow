
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V117.Page;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;


namespace BunnyCart.Utilities
{
    internal class CoreCodes
    {
       
       
        protected void TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot its = (ITakesScreenshot)driver;
            Screenshot ss = its.GetScreenshot();
            string currentDirectory = Directory.GetParent(@"../../../").FullName;

            string filePath = currentDirectory + "/Screenshot/ss_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".png";
            ss.SaveAsFile(filePath);

        }

        protected void LogTestResult(string testName, string result, string errorMessage = null)
        {
          
            
           Log.Information(result);
          //  test = extent.CreateTest(testName);
            if (errorMessage == null)
            {
                Log.Information(testName + "Passed");
              //  test.Pass(result);

            }
            else
            {
                Log.Error($"Test failed for{testName}.\n Exception: \n{errorMessage}");
               // test.Fail(result);
            }
        }

    }
}
