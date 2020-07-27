namespace Assessment1.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Technician
    {
        [Required(ErrorMessage = "Employee ID is required")]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "ACS number is required")]
        public string ACSnumber { get; set; }
        [Required(ErrorMessage = "Expire is required")]
        public Nullable<System.DateTime> Expire { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
