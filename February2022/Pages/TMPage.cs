using February2022.Utilities;
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

            //Click on Type code dropdown
            IWebElement typecodedropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            typecodedropdown.Click();

            //Selecting Material from the dropdown
            IWebElement materialdropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span"));
            materialdropdown.Click();

            //Entering code tab
            IWebElement codetab = driver.FindElement(By.Id("Code"));
            codetab.SendKeys("Test29Kash");

            //Entering Description tab
            IWebElement descriptiontab = driver.FindElement(By.Id("Description"));
            descriptiontab.SendKeys("doing it for first time");

            // Identify the price textbox and input a price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("15");

            // Click on Save Button 
            IWebElement savebutton = driver.FindElement(By.Id("SaveButton"));
            savebutton.Click();
               //Thread.Sleep(1000);
           Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span",2);

            //Click in on the last Page to Check the record
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
             Thread.Sleep(1000);
           // Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 1000);

            // Check if record create is present in the table and has expected value
            IWebElement lasttab = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (lasttab.Text == "Test29Kash")
            {
                Console.WriteLine("Materail record created successfully, test passed.");
            }
            else
            {
                Console.WriteLine("Test failed.");
            }

        }


 // Test to Edit the created TM record.
        public void EditTM(IWebDriver driver)
        {
            // Click edit on the last created record.
            IWebElement Editbutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            Editbutton.Click();
            // Selecting code feild and clearing  the text + adding new text
            IWebElement codefield = driver.FindElement(By.Id("Code"));
            codefield.Clear();
            codefield.SendKeys("kash");

            //Click on save button
            IWebElement Saveresult = driver.FindElement(By.Id("SaveButton"));
            Saveresult.Click();
            Thread.Sleep(3000);
      //Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 3000);

            //Going Back to Last Page.
            IWebElement lastpagetabbutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            lastpagetabbutton.Click();

            // Check if last page tab elememt is same as edited data
            IWebElement lasttab2 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (lasttab2.Text == "kash")
            {
                Console.WriteLine("Test Pass-Record is Edited");
            }
            else
            {
                Console.WriteLine("Test Fails");
            }
        }


// Test to delete the edited record
        public void DeleteTM(IWebDriver driver)

       {

         // Click on Delete tab
            IWebElement deletetab = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deletetab.Click();
            
         // Handling the alert dialouge box
              driver.SwitchTo().Alert().Accept();
              Thread.Sleep(3000);
         //Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]",3000);

         // Check if last page tab has deleted record
         IWebElement lasttab3 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

                if (lasttab3.Text != "kash")
                {
                    Console.WriteLine("Test pass- Entry deleted");

                }
                else
                {
                    Console.WriteLine("Test Fail");

                }
            
        }
    }
}