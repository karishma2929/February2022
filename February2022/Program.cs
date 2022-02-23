using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

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
        }
    }
}
