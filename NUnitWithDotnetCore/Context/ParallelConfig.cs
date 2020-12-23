using BDD_Automation.Pages;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitWithDotnetCore.Context
{
    class ParallelConfig
    {
        public RemoteWebDriver Driver { get; set; }

        public BasePage CurrentPage { get; set; }
    }
}
