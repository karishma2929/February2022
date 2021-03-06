using February2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace February2022.Pages
{
    internal class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            // Creating New TM 
            // Click on Create New tab
            IWebElement createnewtab = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createnewtab.Click();

            //*Click on Type code dropdown
            IWebElement typecodedropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            typecodedropdown.Click();

            //Wait in Galen code
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span", 2);

            //Selecting Material from the dropdown
            IWebElement materialdropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span"));
            materialdropdown.Click();

            //Entering code tab  1
            IWebElement codetab = driver.FindElement(By.Id("Code"));
            codetab.SendKeys("Test29Kash");

            //Entering Description tab  2
            IWebElement descriptiontab = driver.FindElement(By.Id("Description"));
            descriptiontab.SendKeys("Doing it for first time");

            // Identify the price textbox and input a price  3
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("15");

            // Click on Save Button 
            IWebElement savebutton = driver.FindElement(By.Id("SaveButton"));
            savebutton.Click();
            //Thread.Sleep(1000);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);

            //Click in on the last Page to Check the record
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(1000);
           }

      // Check if record create is present in the table and has expected value (Assertion for Spec Flow)

            public string GetCode(IWebDriver driver)
            {
                IWebElement ActualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                return ActualCode.Text;
            }
            public string TypeCode(IWebDriver driver)
            {
                IWebElement ActualTypecode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
                return ActualTypecode.Text;
            }
            public string Description(IWebDriver driver)
            {
                IWebElement ActualDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
                return ActualDescription.Text;
            }
            public string Price(IWebDriver driver)
            {
                IWebElement ActualPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
                return ActualPrice.Text;
            }

        
        
//________________________________________________________________________________________________________________
     // Test to Edit the created TM record.
        public void EditTM(IWebDriver driver,string description,string code,string price)
        {

            // Wait until Entire TM page is displayed
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);

            // Click to go on last Page.
            IWebElement GoToLastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            GoToLastPage.Click();

            // Find for Your Record in the last page- This step is included so we donnot edit other testers records

          IWebElement FindMyRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (FindMyRecord.Text == "Test29Kash")
            {
                // Click edit on the last created record.
                IWebElement Editbutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                Editbutton.Click();
            }

            else
            {
                Assert.Fail("Your Recrod was not visible as last, Hence record Not Edited");

            }

            // Edit codes// Selecting code feild and clearing  the text + adding new text
            IWebElement codefield = driver.FindElement(By.Id("Code"));
            codefield.Clear();
            codefield.SendKeys(code);

            // Edit description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys(description);   //________________________________********

            //Edit price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement priceTextboxE = driver.FindElement(By.Id("Price"));

            priceTag.Click();
            priceTextboxE.Clear();
            priceTag.Click();
            priceTextboxE.SendKeys(price);

            //Click on save button
            IWebElement Saveresult = driver.FindElement(By.Id("SaveButton"));
            Saveresult.Click();
            Thread.Sleep(3000);
           
            //Click on Last Page.
            IWebElement lastpagetabbutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            lastpagetabbutton.Click();
            Thread.Sleep(1000);
        }
        public string GetEditDescription(IWebDriver driver)
        {
            IWebElement createdDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return createdDescription.Text;

        }

        public string GetEditCode (IWebDriver driver)
        {
          IWebElement createdCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return createdCode.Text;
        }

        public string GetEditPrice(IWebDriver driver)
        {
         IWebElement createdPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return createdPrice.Text;
        }
//_________________________________________________________________________________________________________________

// Test to Delete the Edited record.
         public void DeleteTM(IWebDriver driver)

        {
          // Wait until Entire TM page is displayed
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);

            // Click to go on last Page.
            IWebElement GoToLastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            GoToLastPage.Click();

            // Find your Edited Record.
            IWebElement FindMyRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (FindMyRecord.Text == "EditKash")
            {
                // Click on Delete tab
                IWebElement deletetab = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deletetab.Click();
                Thread.Sleep(3000);

                // Handling the alert dialouge box
                driver.SwitchTo().Alert().Accept();
            }
            else
            {
                Assert.Fail("Record was not Visible");
            }

            driver.Navigate().Refresh();
            Thread.Sleep(1000);

            //Click on Last Page.
            IWebElement lastpagetabbutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            lastpagetabbutton.Click();
            Thread.Sleep(1000);

            // Check if last page tab has deleted record

            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            // Assertion
            Assert.That(editedCode.Text != "EditKash", "Code record hasn't been deleted.");
            Assert.That(editedDescription.Text != "Changing My Description", "Description record hasn't been deleted.");
            Assert.That(editedPrice.Text != "$170.00", "Price record hasn't been deleted.");



        }
    }
}