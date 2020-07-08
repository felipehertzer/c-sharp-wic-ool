using Assessment1.Data.Models;
using Assessment1.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assessment1.Web.Controllers
{
    public class HomeController : Controller
    {
        IAccountantData dbAccountant;
        ITechnicianData dbTechnician;

        public HomeController()
        {
            dbAccountant = new InMemoryAccountantData();
            dbTechnician = new InMemoryTechnicianData();
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Accountant = dbAccountant.GetAll();
            ViewBag.Technician = dbTechnician.GetAll();
            ViewBag.TaxValue = 0;

            return View();
        }

        [HttpPost]
        public ActionResult OnPostIndex(int employeeId, double hours)
        {
            var accountants = dbAccountant.GetAll();
            var technicians = dbTechnician.GetAll();
            double taxValue = 0;
            Accountant selectedAccountants = accountants.First(item => item.EmployeeId == employeeId);
            Technician selectedTechnician = technicians.First(item => item.EmployeeId == employeeId);
            if (selectedAccountants.EmployeeName != "")
            {
                taxValue = selectedAccountants.CalculateWage(hours);
            } 
            else if (selectedTechnician.EmployeeName != "")
            {
                taxValue = selectedTechnician.CalculateWage(hours);
            }

            Console.WriteLine(taxValue);

            ViewBag.Technician = dbTechnician.GetAll();
            ViewBag.Accountant = accountants;
            ViewBag.TaxValue = taxValue;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}