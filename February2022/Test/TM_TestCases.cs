using February2022.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace February2022
{
    internal class TM_TestCases
    {
        static void Main(string[] args)
        {
     //My first Test Auomation
            // Open chrome Browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

      //Login page object initialzation and definition
            LoginPage LoginPageObj = new LoginPage();
            LoginPageObj.loginStep(driver);

     // Home page object intialzation and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

      // TM page object intialzation and definition
           TMPage TMPageObj = new TMPage();
            TMPageObj.CreateTM(driver);

     // Edit TM
          TMPage EditPageObj = new TMPage();
          EditPageObj.EditTM(driver);

     // Delete TM
      // TMPage DeletePageObj=new TMPage();
      // DeletePageObj.DeleteTM(driver);

        }
    }
}
