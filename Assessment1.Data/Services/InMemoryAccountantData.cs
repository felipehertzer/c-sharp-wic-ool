using Assessment1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Data.Services
{
    public class InMemoryAccountantData : IAccountantData
    {
        List<Accountant> accountants;

        public InMemoryAccountantData()
        {
            accountants = new List<Accountant>
            {
                new Accountant { EmployeeId = 4, EmployeeName = "John", RatePerHour = 39.0, CpaNumber = "123456" },
                new Accountant { EmployeeId = 5, EmployeeName = "Robert", RatePerHour = 49.0, CpaNumber = "123456" },
                new Accountant { EmployeeId = 6, EmployeeName = "James", RatePerHour = 59.0, CpaNumber = "123456" }
            };
        }

        public IEnumerable<Accountant> GetAll()
        {
            return accountants.OrderBy(t => t.EmployeeId);
        }
    }
}
