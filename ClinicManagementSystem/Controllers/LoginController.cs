using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        HospitalDBEntities Db = new HospitalDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login obj)
        {
            
            var Doctor = Db.tblDoctors.Select(s => new { s.Id, s.Name, s.Password, s.UserName, s.Role }).Where(w => w.UserName == obj.LoginName && w.Password == obj.Password).FirstOrDefault();
            if (Doctor != null)
            {
                FormsAuthentication.SetAuthCookie(Doctor.Id.ToString(), false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "invalid User";
            }
            var Staff = Db.tblStaffs.Select(s => new { s.Id, s.Name, s.Password, s.UserName, s.Role }).Where(w => w.UserName == obj.LoginName && w.Password == obj.Password).FirstOrDefault();
            if (Staff != null)
            {
                FormsAuthentication.SetAuthCookie(Staff.Id.ToString(), false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "invalid User";
            }

            var Admin = Db.tblAdmins.Select(s => new { s.Id, s.Name, s.Password, s.Username, s.Role }).Where(w => w.Username == obj.LoginName && w.Password == obj.Password).FirstOrDefault();


            if (Admin != null)
            {
                FormsAuthentication.SetAuthCookie(Admin.Id.ToString(), false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "invalid User";
            }

            return View();
        }




        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }
    }
}
