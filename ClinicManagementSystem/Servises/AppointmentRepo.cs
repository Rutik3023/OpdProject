using ClinicManagementSystem.Iservises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Servises
{
    public class AppointmentRepo : IAppointment
    {

        HospitalDBEntities db = new HospitalDBEntities();

        public List<tblAppointment> GetAll()
        {
            List<tblAppointment> obj = db.tblAppointments.ToList();

            return obj;

        }

        public string Save(tblAppointment obj)
        {
            try
            {
                if (obj.Id==0)
                {
                    tblAppointment List = new tblAppointment();

                    List.Cid = obj.Cid;
                    List.Date = obj.Date;
                    List.Stastus = obj.Stastus;
                    List.DrId = obj.DrId;

                    db.tblAppointments.Add(List);
                    db.SaveChanges();

                    return "Saved Successfully";

                }
                else
                {
                    var List = db.tblAppointments.Find(obj.Id);

                    List.Cid = obj.Cid;
                    List.Date = obj.Date;
                    List.Stastus = obj.Stastus;
                    List.DrId = obj.DrId;

                    db.tblAppointments.Attach(List);
                    db.Entry(List).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return "Updated Successfully";
                }
            }
            catch (Exception er)
            {
                return "Error"+er.Message;
            }
        }

        public tblAppointment FindById(int id)
        {
            var obj = db.tblAppointments.Find(id);

            return obj;
        }

        public bool Delete(int id)
        {
            var obj = db.tblAppointments.Find(id);

            if (obj!=null)
            {
                db.tblAppointments.Remove(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public dynamic GetAllKey(string key)
        {
            try
            {
                dynamic List = db.tblAppointments.Select(s => new 
                {
                    s.Id,
                    s.Cid,
                    s.Date,
                    s.Stastus,
                    s.DrId
                }).Where(w => w.Stastus.Contains(key)).ToList();

                return List;
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public dynamic GetAllPage(int pageno)
        {
            dynamic obj = db.tblAppointments.OrderByDescending(o => o.Id).Skip(8 * pageno).Take(8).ToList();

            return obj;
        }
    }
}