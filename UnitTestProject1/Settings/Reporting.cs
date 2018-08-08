using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace UnitTestProject1.Settings
{
    public static class Reporting
    {
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;
        private static ExtentTest test;
        public static string strTest;

        public static void SetupReporting()
        {
            string projectPath = System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\";
            htmlReporter = new ExtentHtmlReporter(projectPath + "Reports\\ExecutionReport.html");

            htmlReporter.Configuration().Theme = Theme.Dark;

            htmlReporter.Configuration().DocumentTitle = "Automation Testing";

            htmlReporter.Configuration().ReportName = "Testing Report";

            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
        }

        public static void GenerateReport()
        {
            extent.Flush();
        }

        public static void TakeScreenshot(string strFileName)
        {
            string projectPath = System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\";

            string ssFilePath = projectPath + "Screenshot\\" + strFileName + ".png";
            Screenshot ss = ((ITakesScreenshot)PropertiesCollection.driver).GetScreenshot();
            ss.SaveAsFile(ssFilePath, OpenQA.Selenium.ScreenshotImageFormat.Png);

        }

        public static void AssertTrue(string expectedResult, string actualResult, string strTestName, string strCondition)
        {

            string projectPath = System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\";
            strTest = strTestName + "- " + strCondition;
            test = extent.CreateTest(strTest);

            try
            {
                Assert.IsTrue(Equals(expectedResult, actualResult));
                test.Pass("The value " + actualResult + " is as expected");
            }
            catch (AssertionException)
            {
                TakeScreenshot(strTest);
                test.Fail("details", MediaEntityBuilder.CreateScreenCaptureFromPath(projectPath + "Screenshot\\" + strTest + ".png").Build());
                Console.Out.Write(projectPath + "Screenshot\\" + strTest + ".png");
                throw;
            }

        }
    }
}
