﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class StaffController : Controller
    {
        HospitalDBEntities db = new HospitalDBEntities();
        // GET: Staff
        public ActionResult Index()
        {

            TempData["count"] = db.tblStaffs.Count();


            return View();
        }
    }
}