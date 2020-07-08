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
            ViewBag.TaxValue = String.Format("{0:C}", 0);
            ViewBag.Value = String.Format("{0:C}", 0);

            return View();
        }

        [HttpPost]
        public ActionResult Index(int employeeId, double hours)
        {
            var accountants = dbAccountant.GetAll();
            var technicians = dbTechnician.GetAll();
            double taxValue = 0;
            double value = 0;
            Accountant selectedAccountants = accountants.Where(i => i.EmployeeId == employeeId).FirstOrDefault();
            Technician selectedTechnician = technicians.Where(i => i.EmployeeId == employeeId).FirstOrDefault();
            if (selectedAccountants != null)
            {
                value = selectedAccountants.CalculateWage(hours);
                taxValue = selectedAccountants.CalculateTax(hours);
            } 
            else if (selectedTechnician != null)
            {
                value = selectedTechnician.CalculateWage(hours);
                taxValue = selectedTechnician.CalculateTax(hours);
            }

            ViewBag.Technician = dbTechnician.GetAll();
            ViewBag.Accountant = accountants;
            ViewBag.EmployeeId = employeeId;
            ViewBag.Hours = hours;
            ViewBag.TaxValue = String.Format("{0:C}", taxValue);
            ViewBag.Value = String.Format("{0:C}", value);
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