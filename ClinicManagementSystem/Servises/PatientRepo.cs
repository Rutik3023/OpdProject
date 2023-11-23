using ClinicManagementSystem.Iservises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Servises
{
    public class PatientRepo : IPatient
    {
        HospitalDBEntities db = new HospitalDBEntities();

        public List<tblPatient> GetAll()
        {
            List<tblPatient> obj = db.tblPatients.ToList();

            return obj;
        }

        public string Save(tblPatient obj)
        {
            try
            {
                if (obj.Id==0)
                {
                    tblPatient List = new tblPatient();

                    List.Name = obj.Name;
                    List.Emailid = obj.Emailid;
                    List.Mobileno = obj.Mobileno;
                    List.Address = obj.Address;
                    List.Adharno = obj.Adharno;
                    List.Createdon = DateTime.Now;
                    List.Createdby = 1;
                    List.bloodgroupid = obj.bloodgroupid;
                    List.Gender = obj.Gender;

                    db.tblPatients.Add(List);
                    db.SaveChanges();

                    return "Saved Successfully";

                }
                else
                {
                    var List = db.tblPatients.Find(obj.Id);

                    List.Name = obj.Name;
                    List.Emailid = obj.Emailid;
                    List.Mobileno = obj.Mobileno;
                    List.Address = obj.Address;
                    List.Adharno = obj.Adharno;
                    List.Createdon = DateTime.Now;
                    List.Createdby = 1;
                    List.bloodgroupid = obj.bloodgroupid;
                    List.Gender = obj.Gender;

                    db.tblPatients.Attach(List);
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

        public tblPatient FindById(int id)
        {
            var obj = db.tblPatients.Find(id);
            return obj;
        }

        public bool Delete(int id)
        {
            var obj = db.tblPatients.Find(id);

            if (obj!=null)
            {
                db.tblPatients.Remove(obj);
                db.SaveChanges();

                return true;
            }
            return false;
        }

        public dynamic GetAllKey(string key)
       {
            try
            {
                dynamic List = db.tblPatients.Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Emailid,
                    s.Mobileno,
                    s.Address,
                    s.Adharno,
                    s.Createdon,
                    s.Createdby,
                    s.bloodgroupid,
                    s.Gender

                }).Where(w => w.Name.Contains(key))
                   .ToList();

                return List;
            }
            catch (Exception er)
            {

                return null;
            }
            return null;
        }

        public dynamic GetAllPage(int pageno)
        {
            dynamic obj = db.tblPatients.Select(s => new
            {
                s.Id,
                s.Name,
                s.Emailid,
                s.Mobileno,
                s.Address,
                s.Adharno,
                s.Createdon,
                s.Createdby,
                 blood= s.tblBloodgroup.Name,
                s.Gender
            }).OrderByDescending(o => o.Id).Skip(8 * pageno).Take(8).ToList();

            return obj;
        }
    }
}