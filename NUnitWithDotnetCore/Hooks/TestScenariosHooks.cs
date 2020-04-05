using BDD_Automation.Context;
using System;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BDD_Automation.Pages;
using BDD_Automation.Steps;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;


namespace BDD_Automation.Hooks
{
    [Binding]
    public sealed class TestScenariosHooks
    {
        
        private readonly WebDriver webDriver;
        Logging.Logger log = new Logging.Logger();
        public FeatureContext _featurecontext;
        public ScenarioContext _scenariocontext;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private static string path;
        public TestScenariosHooks(ScenarioContext scenarioContext, FeatureContext featureContext, WebDriver driver)
        {
            _scenariocontext = scenarioContext;
            _featurecontext = featureContext;
            webDriver = driver;
        }
        //public TestScenariosHooks(WebDriver driver)
        //{
        //}
        [BeforeTestRun]
        public static void InitializeReport()
        {
            //string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            //path = path1 + "Report\\ExtentReport\\index.html";
            //if (Directory.Exists(path))
            //{
            //    Directory.Delete(path, true);
            //    Directory.CreateDirectory(path);
            //    SetFolderPermission(path);
            //}

            //var htmlreport = new ExtentHtmlReporter(path);
            //htmlreport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //extent = new ExtentReports();
            //extent.AttachReporter(htmlreport);
        }
        public static void SetFolderPermission(string folderPath)
        {
        }


        //[AfterTestRun]
        //public static void TearDownReport()
        //{
        //    extent.Flush();
        //}

        [BeforeFeature]
        public static void BeforeFeature()
        {
            //featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }
        [AfterStep]
        public void InsertReportingSteps()
        {
            //var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            //PropertyInfo piInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            //MethodInfo getter = piInfo.GetGetMethod(nonPublic: true);
            //object TestResult = getter.Invoke(ScenarioContext.Current, null);

            //if (ScenarioContext.Current.TestError == null)
            //{
            //    if (stepType == "Given")
            //    {
            //        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString() + " : " + ScenarioStepContext.Current.StepInfo.Text);
            //    }
            //    else if (stepType == "When")
            //    {
            //        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString() + " : " + ScenarioStepContext.Current.StepInfo.Text);
            //    }
            //    else if (stepType == "Then")
            //    {
            //        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString() + " : " + ScenarioStepContext.Current.StepInfo.Text);
            //    }
            //    else if (stepType == "And")
            //    {
            //        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString() + " : " + ScenarioStepContext.Current.StepInfo.Text);
            //    }
            //}
            //else if (ScenarioContext.Current.TestError != null)
            //{
            //    if (stepType == "Given")
            //    {
            //        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString() + " : " + ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
            //    }
            //    else if (stepType == "When")
            //    {
            //        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString() + " : " + ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
            //    }
            //    else if (stepType == "Then")
            //    {
            //        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString() + " : " + ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            //    }

            //}
            //if (TestResult.ToString() == "StepDefinitionPending")
            //{
            //    if (stepType == "Given")
            //    {
            //        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            //    }
            //    else if (stepType == "When")
            //    {
            //        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            //    }
            //    else if (stepType == "Then")
            //    {
            //        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            //    }
            //}
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            log.Info("[SCENARIO] ---------------" + _featurecontext.FeatureInfo.Title + " - " + _scenariocontext.ScenarioInfo.Title + "---------------");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            log.Info("Done");
            webDriver._driver.Quit();
            webDriver._driver.Dispose();
        }
    }
}
