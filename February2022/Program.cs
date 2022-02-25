using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace February2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
     //My first Test Auomation
            // Open chrome Browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // launch Turn up portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            //identify user name text box and enter valid username
            IWebElement Textbox = driver.FindElement(By.Id("UserName"));
            Textbox.SendKeys("hari");

            //identity password text box and enter valid password
            IWebElement PasswordBox =driver.FindElement(By.Id("Password"));
            PasswordBox.SendKeys("123123");

            //click on login button 
            IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            LoginButton.Click();

            //check if user is logged in succesfully
            IWebElement hellohari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            if (hellohari.Text == "Hello hari!")
            {
                Console.WriteLine("Logged in succesfully Test is pass");
            }
            else
            {
                Console.WriteLine("Test fail");

            }
    //Validating Create New Time and Material

            // Click on Administrator tab
            IWebElement administration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administration.Click();

            //Click on Time and Material
            IWebElement timematerial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timematerial.Click();

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
            codetab.SendKeys("Test29");

            //Entering Description tab
            IWebElement descriptiontab =driver.FindElement(By.Id("Description"));
            descriptiontab.SendKeys("doing it for first time");

            // Identify the price textbox and input a price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("15");

            // Selecting Save Button 
            IWebElement savebutton =driver.FindElement(By.Id("SaveButton"));
            savebutton.Click();
            Thread.Sleep(1000);

            //Click in on the last Page to Check the record
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(1000);


            // Check if record create is present in the table and has expected value
            IWebElement lasttab = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (lasttab.Text == "Test29")
            {
                Console.WriteLine("Materail record created successfully, test passed.");
            }
            else
            {
                Console.WriteLine("Test failed.");
            }

  // Test to Edit the created record.

            // Click edit on the last created record.
            IWebElement Editbutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            Editbutton.Click();
            // Selecting code feild and clearing  the text + adding new text
            IWebElement codefield = driver.FindElement(By.Id("Code"));
            codefield.Clear();
            codefield.SendKeys("29Test3");

            //Click on save button
            IWebElement Saveresult = driver.FindElement(By.Id("SaveButton"));
            Saveresult.Click();
            Thread.Sleep(3000);

          //Going Back to Last Page.
            IWebElement lastpagetabbutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
           lastpagetabbutton.Click();

            // Check if last page tab elememt is same as edited data
            IWebElement lasttab2 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (lasttab2.Text == "29Test3")
            {
                Console.WriteLine("Test Pass-Record is Edited");
            }
            else
            { 
                Console.WriteLine("Test Fails");
            }
  // Test to delete the edited record
                      // Click on Delete tab
                      IWebElement deletetab = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                      deletetab.Click();
            Thread.Sleep(3000);
                      // Handling the alert dialouge box
                      driver.SwitchTo().Alert().Accept();
             Thread.Sleep(3000);
                     // Check if last page tab has deleted record
                      IWebElement lasttab3 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
           
                      if (lasttab3.Text != "29Test3")
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
