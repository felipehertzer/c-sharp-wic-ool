using Assessment1.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assessment1.Web.Controllers
{
    public class HomeController : Controller
    {
        private WicCompanyEntitiesDb db = new WicCompanyEntitiesDb();

        public HomeController()
        {
        }

        [HttpGet]
        public ActionResult Index(string search = null)
        {
            IEnumerable<Employee> employee = db.Employees.ToList();
          
            if (!string.IsNullOrEmpty(search))
            {
                employee = employee.Where(x => x.EmployeeName.Contains(search));
            }
            ViewBag.Search = search;

            return View(employee);
        }

        [HttpGet]
        public ActionResult Calculate()
        {
            ViewBag.TaxValue = String.Format("{0:C}", 0);
            ViewBag.Value = String.Format("{0:C}", 0);
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(int employeeId, decimal hours)
        {
            Employee employee = db.Employees.Find(employeeId);
            if (employee == null)
            {
                return HttpNotFound();
            }

            decimal value = employee.CalculateWage(hours);
            decimal taxValue = employee.CalculateTax(hours);
          
            ViewBag.EmployeeId = employeeId;
            ViewBag.Hours = hours;
            ViewBag.TaxValue = String.Format("{0:C}", taxValue);
            ViewBag.Value = String.Format("{0:C}", value);
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Message = "Create new Employee";

            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, decimal ratePerHour, string type, string memberNumber, string expiryDate)
        {

            ViewBag.Message = "Create new Employee";
            Employee employee = new Employee();
            employee.EmployeeName = name;
            employee.RatePerHour = ratePerHour;
            Employee test = db.Employees.Add(employee);
            db.SaveChanges();

            if (type.Equals("a"))
            {
                Accountant accountant = new Accountant();
                accountant.EmployeeID = test.EmployeeID;
                accountant.CPAnumber = memberNumber;

                db.Accountants.Add(accountant);

            } else
            {
                Technician technician = new Technician();
                technician.EmployeeID = test.EmployeeID;
                technician.ACSnumber = memberNumber;
                DateTime expire = DateTime.ParseExact(expiryDate + " 00:00:00,000", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
                technician.Expire = expire;

                db.Technicians.Add(technician);
            }
            
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Home/Edit/{id:int}")]
        public ActionResult Edit(int? id)
        {
            Data.Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            ViewBag.Message = "Edit Employee";
            ViewBag.Employee = employee;
            return View();
        }

        [HttpPost]
        [Route("Home/Edit/{id:int}")]
        public ActionResult Edit(int? id, string name, decimal ratePerHour, string type, string memberNumber, string expiryDate)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Employee employee = new Employee();
            employee.EmployeeID = (int) id;
            employee.EmployeeName = name;
            employee.RatePerHour = ratePerHour;
            if (type.Equals("a"))
            {
                Accountant accountant = new Accountant();
                accountant.EmployeeID = (int)id;
                accountant.CPAnumber = memberNumber;

                employee.Accountant = accountant;

            }
            else
            {
                Technician technician = new Technician();
                technician.EmployeeID = (int)id;
                technician.ACSnumber = memberNumber;
                DateTime expire = DateTime.ParseExact(expiryDate + " 00:00:00,000", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
                technician.Expire = expire;

                employee.Technician = technician;
            }

            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Home/Delete/{id:int}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}