namespace Assessment1.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
    {
        [Required(ErrorMessage = "Employee ID is required")]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Employee Name is required")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Rate Per Hour is required")]
        public decimal RatePerHour { get; set; }

        public decimal CalculateWage(decimal hours)
        {
            return Decimal.Multiply(this.RatePerHour, hours);
        }

        public decimal CalculateTax(decimal hours)
        {
            return Decimal.Multiply(this.CalculateWage(hours), Decimal.Parse("19.20")) / 100;
        }

        public virtual Accountant Accountant { get; set; }
        public virtual Technician Technician { get; set; }
    }
}
