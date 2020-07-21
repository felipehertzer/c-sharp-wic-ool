using System;
using Assessment1.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assessment1.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWage()
        {
            decimal expected = Decimal.Parse("450");
            Employee employee = new Employee();
            employee.EmployeeID = 1;
            employee.RatePerHour = Decimal.Parse("45");

            decimal actual = employee.CalculateWage(10);
            decimal diff = 0.0001M;

            Assert.IsTrue(Math.Abs(expected - actual) < diff);
        }

        [TestMethod]
        public void TestTax()
        {
            decimal expected = Decimal.Parse("86.4");
            Employee employee = new Employee();
            employee.EmployeeID = 1;
            employee.RatePerHour = Decimal.Parse("45");

            decimal actual = employee.CalculateTax(10);
            decimal diff = 0.0001M;

            Assert.IsTrue(Math.Abs(expected - actual) < diff);
        }
    }
}
