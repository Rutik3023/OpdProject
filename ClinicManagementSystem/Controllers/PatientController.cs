using ClinicManagementSystem.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class PatientController : Controller
    { HospitalDBEntities db = new HospitalDBEntities();
       
        // GET: Patient
        public ActionResult Index()
        {
            ViewBag.blood = CommonRepo.Blood();
            TempData["count"] = db.tblPatients.Count();
            return View();
        }
    }
}