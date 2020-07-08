using Assessment1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Data.Services
{
    public class InMemoryTechnicianData : ITechnicianData
    {
        List<Technician> technicians;

        public InMemoryTechnicianData()
        {
            technicians = new List<Technician>
            {
                new Technician { EmployeeId = 1, EmployeeName = "John", RatePerHour = 39.0, AcsNumber = "123", ExpireDate = "27-08-2020" },
                new Technician { EmployeeId = 2, EmployeeName = "Robert", RatePerHour = 49.0, AcsNumber = "123", ExpireDate = "27-08-2020" },
                new Technician { EmployeeId = 3, EmployeeName = "James", RatePerHour = 59.0, AcsNumber = "123", ExpireDate = "27-08-2020" }
            };
        }
        
        public IEnumerable<Technician> GetAll()
        {
            return technicians.OrderBy(t => t.EmployeeId);
        }
    }
}
