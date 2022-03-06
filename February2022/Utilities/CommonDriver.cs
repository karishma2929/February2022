using February2022.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace February2022.Utilities
{
    internal class CommonDriver
    {
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void LoginFunction()
        {
            // Open chrome Browser   __________________ Inhertitence Login step
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //Login page object initialzation and definition_________________
            LoginPage LoginPageObj = new LoginPage();
            LoginPageObj.loginStep(driver);

            // Home page object intialzation and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }

        [OneTimeTearDown]
        public void CloseTestRun()
        {
                driver.Quit();
        }
        
    }
}
