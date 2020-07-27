namespace Assessment1.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Accountant
    {
        [Required(ErrorMessage = "Employee ID is required")]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "CPA number is required")]
        public string CPAnumber { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
