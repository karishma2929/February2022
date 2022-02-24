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
            codetab.SendKeys("KarishmaTestLast");

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

            if (lasttab.Text == "KarishmaTestLast")
            {
                Console.WriteLine("Materail record created successfully, test passed.");
            }
            else
            {
                Console.WriteLine("Test failed.");
            }


        }
    }
}
