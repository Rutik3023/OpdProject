using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class MedicinesController : Controller
    {
        HospitalDBEntities db = new HospitalDBEntities();
        // GET: Medicines
        public ActionResult Index()
        {
            TempData["count"] = db.tblMedicines.Count();
            return View();
        }
    }
}