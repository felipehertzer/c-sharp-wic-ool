using Assessment1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Data.Services
{
    public interface IAccountantData
    {
        IEnumerable<Accountant> GetAll();
    }
}
