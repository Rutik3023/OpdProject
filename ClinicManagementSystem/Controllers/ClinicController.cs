using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class ClinicController : Controller
    {
        HospitalDBEntities db = new HospitalDBEntities();
        // GET: Clinic
        public ActionResult Index()
        {
           TempData["count"] = db.tblClinics.Count();
            return View();
        }
    }
}