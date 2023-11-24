using ClinicManagementSystem.Iservises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Servises
{
    public class PrescripsionRepo : Iprescripstion
    {
        HospitalDBEntities db = new HospitalDBEntities();
        public dynamic lodAppoymentid(int id)
        {

            dynamic obj = db.tblAppointments.OrderByDescending(s => s.Id).Select(s => new { s.Id, s.Cid }).Where(w => w.Cid == id).FirstOrDefault();
            return obj;
        }

        public dynamic lodCasid(int id)
        {

            dynamic obj = db.tblCasePapers.OrderByDescending(s => s.Id).Select(s => new { s.Id, s.Pid }).Where(w => w.Pid == id).FirstOrDefault();
            return obj;
        }
    }
}