using February2022.Pages;
using February2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace February2022
{
    [Binding]
    public class TMFeatureStepDefinitions :CommonDriver
    {
        //Initialting Page objects together:
        LoginPage LoginPageObj = new LoginPage();//___1 time for Login
        HomePage homePageObj = new HomePage(); // ___1 timefor Navigating TM page
        TMPage TMPageObj = new TMPage(); //____2 times for create TM and assertion.
         
        [Given(@"Successfully login to turn up portal\.")]
        public void GivenSuccessfullyLoginToTurnUpPortal_()
        {
         // Open chrome Browser _______ Inhertitence Login step
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            
            LoginPageObj.loginStep(driver);
        }

        [Given(@"Navigate to Time and Material tab\.")]
        public void GivenNavigateToTimeAndMaterialTab_()
        {
            
            homePageObj.GoToTMPage(driver);
        }

        [When(@"Create Time and Material record\.")]
        public void WhenCreateTimeAndMaterialRecord_()
        {
            TMPageObj.CreateTM(driver);
        }

        [Then(@"Time and Material record created successfully\.")]
        public void ThenTimeAndMaterialRecordCreatedSuccessfully_()
        {
            string newCode = TMPageObj.GetCode(driver);
            string TypeCode = TMPageObj.TypeCode(driver);
            string Description = TMPageObj.Description(driver);
            string Price= TMPageObj.Price(driver);

            Assert.That(newCode=="Test29Kash","Actual code and expected code do not match");
            Assert.That(TypeCode == "M", "Actual Typecode and expected Typecode do not match");
            Assert.That(Description == "Doing it for first time", "Actual description do not match");
            Assert.That(Price == "$170.00", "Actual code and expected code do not match");
        }

        [When(@"Edit '([^']*)','([^']*)','([^']*)' on existing Time and Material record")]
        public void WhenEditOnExistingTimeAndMaterialRecord(string p0, string p1, string p2)
        {
            TMPageObj.EditTM(driver,p0,p1,p2);
        }

        [Then(@"'([^']*)','([^']*)','([^']*)', should be seen in updated Time and Material record")]
        public void ThenShouldBeSeenInUpdatedTimeAndMaterialRecord(string p0, string p1, string p2)
        {
            string editedCode = TMPageObj.GetEditCode(driver);
            string editedDescription = TMPageObj.GetEditDescription(driver);
            string editedPrice= TMPageObj.GetEditPrice(driver);

            Assert.That(editedDescription == p0,"Actual description is different from Edited Description");
            Assert.That(editedCode == p1,"Actual code is different from edited code");
            Assert.That(editedPrice == p2,"Actual price is not equalto edited pricce");

        }
         


    }
}