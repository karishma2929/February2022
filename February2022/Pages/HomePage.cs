using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace February2022.Pages
{
    internal class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {

        // Click on Administrator tab
            IWebElement administration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administration.Click();

          //Click on Time and Material
            IWebElement timematerial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timematerial.Click();

        }
    }
}
