using February2022.Pages;
using February2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace February2022
{
    [TestFixture]
    [Parallelizable]
    internal class TM_TestCases : CommonDriver
    {
    
     [Test,  Order(1), Description("Check if user is able to create a material record with valid data")]
        public void CreateTM_Test()
        {
          // Home page object intialzation and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

          // TM page object intialzation and definition
            TMPage TMPageObj = new TMPage();
            TMPageObj.CreateTM(driver);
        }
    [Test, Order(2),Description("Check If user is able to Edit record")]
        public void EditTM_Test()
        {
            // Home page object intialzation and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
            // Edit TM
            TMPage EditPageObj = new TMPage();
            EditPageObj.EditTM(driver,"dummy");
        }
     [Test, Order(3), Description("Check If user is able to Delete record")]
        public void DeleteTM()
        {
        // Home page object intialzation and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
          
         //Delete TM
            TMPage DeletePageObj = new TMPage();
            DeletePageObj.DeleteTM(driver);
        }
     
    }
   
}
