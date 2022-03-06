using February2022.Pages;
using February2022.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace February2022.Test
{
    [TestFixture]
    [Parallelizable]
    internal class EM_TestCases:CommonDriver
    {
        [Test,Order (1),Description ("Check If user is able to create Employee record")]
        public void CreateEmTest()
        {
            //Home Page Object initialsation
            HomePage HomePageObj = new HomePage();
            HomePageObj.GoToEMPage(driver);

            //Employee page Create EM Object initialsation
            EmployeePage EMCreateObj = new EmployeePage();
            EMCreateObj.CreateEmployeePage(driver);

        }
        [Test,Order (2),Description("Check if user is able to Edit the employee record")]
        public void EditEmTest()
        {
            //Home Page Object initialsation
            HomePage HomePageObj = new HomePage();
            HomePageObj.GoToEMPage(driver);

            // Employee page Edit EM Object initialsation
            EmployeePage EMEditObj =new EmployeePage();
            EMEditObj.EditEmployee(driver);
        }
        [Test, Order(3), Description("Check if user is able to Delete the employee record")]
        public void DeleteEMTest()
        {
            //Home Page Object initialsation
            HomePage HomePageObj = new HomePage();
            HomePageObj.GoToEMPage(driver);

            // Employee page Delete Object initialsation
            EmployeePage EMDeleteObj =new EmployeePage();
            EMDeleteObj.DeleteEmployee(driver);
        }
    }
}
