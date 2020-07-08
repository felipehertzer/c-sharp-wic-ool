using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Data.Models
{
    public class Technician : Employee
    {
        public string AcsNumber { get; set; }
        public string ExpireDate { get; set; }
    }
}
