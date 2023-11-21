using ClinicManagementSystem.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class DoctorController : Controller
    {
        HospitalDBEntities db = new HospitalDBEntities();
        // GET: Doctor
        public ActionResult Index()
        {
            TempData["count"] = db.tblDoctors.Count();
            ViewBag.Role = CommonRepo.Role();
            ViewBag.Clinic = CommonRepo.Clinic();

            return View();
        }
    }
}