using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Data.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public double RatePerHour { get; set; }

        public double CalculateWage(double hours)
        {
            return this.RatePerHour * hours;
        }

        public double CalculateTax(double hours)
        {
            return (this.CalculateWage(hours) * 19.20) / 100;
        }
    }
}
