﻿using BDD_Automation.Context;
using System;
using TechTalk.SpecFlow;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow.Bindings;
using ExtensionMethods;
using Newtonsoft.Json.Schema;
using AventStack.ExtentReports.Utils;

namespace BDD_Automation.Hooks
{
    [Binding]
    public sealed class TestScenariosHooks
    {

        private readonly WebDriver webDriver;
        static Logging.Logger log = new Logging.Logger();
        public FeatureContext _featurecontext;
        public ScenarioContext _scenariocontext;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;
        public static AventStack.ExtentReports.ExtentReports Extent;
        private static readonly string _path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\netcoreapp3.0", "") + "Report\\";

        private static string _categories = Environment.GetEnvironmentVariable("Report");
        private static string IsReport => string.IsNullOrEmpty(Environment.GetEnvironmentVariable("Report")) ? "yes" : Environment.GetEnvironmentVariable("Report");


        public TestScenariosHooks(ScenarioContext scenarioContext, FeatureContext featureContext, WebDriver driver)
        {
            _scenariocontext = scenarioContext;
            _featurecontext = featureContext;
            webDriver = driver;
        }
        [BeforeTestRun]
        public static void ConfigureReport()
        {
            if (!IsReport.Equals("yes"))
            {
                return;
            }
            else
            {
                string path = string.IsNullOrEmpty(_categories) ? _path + "\\index.html" : _path + _categories + "\\index.html";
                var reporter = new ExtentHtmlReporter(path);
                Extent = new AventStack.ExtentReports.ExtentReports();
                Extent.AttachReporter(reporter);
            }
        }

        [BeforeFeature]
        public static void CreateFeature(FeatureContext featureContext)
        {
            _feature = Extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _scenario = _feature.CreateNode<Scenario>(_scenariocontext.ScenarioInfo.Title);
            log.Info("[SCENARIO] ---------------" + _featurecontext.FeatureInfo.Title + " - " + _scenariocontext.ScenarioInfo.Title + "---------------");
        }

        [AfterStep]
        public static void InsertReportingSteps()
        {
            switch (ScenarioStepContext.Current.StepInfo.StepDefinitionType)
            {
                case StepDefinitionType.Given:
                    _scenario.StepDefinitionGiven();
                    break;

                case StepDefinitionType.Then:
                    _scenario.StepDefinitionThen();
                    break;

                case StepDefinitionType.When:
                    _scenario.StepDefinitionWhen();
                    break;
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            log.Info("Done");
            webDriver._driver.Quit();
            webDriver._driver.Dispose();
        }

        [AfterTestRun]
        public static void FlushExtent()
        {
            Extent.Flush();
        }
    }
}
