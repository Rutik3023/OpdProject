using ClinicManagementSystem.Iservises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Servises
{
    public class DoctorRepo : IDoctor
    {
        HospitalDBEntities db = new HospitalDBEntities();
        public bool Delete(int id)
        {
            var obj = db.tblDoctors.Find(id);

            if (obj != null)
            {
                db.tblDoctors.Remove(obj);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public tblDoctor Findbyid(int id)
        {
            tblDoctor obj = db.tblDoctors.Find(id);


            return obj;
        }

        public List<tblDoctor> GetAll()
        {
            List<tblDoctor> obj = db.tblDoctors.ToList();



            return obj;
        }

        public dynamic GetAllkey(string key)
        {
            try
            {
                dynamic list = db.tblDoctors
                    .Select(s => new
                    {
                        s.Id,
                        s.Name,
                        s.Email,
                        s.Mobile,
                        s.Address,
                        s.Qulification,
                        s.Specilization,
                        s.Gender,
                        Role = s.Role,
                        s.UserName,
                        s.Password,
                        s.Photo,
                        s.CreatedOn,
                        CreatedBy = s.CreatedBy
                    }).
                        Where(w => w.Name.Contains(key) || w.Email.Contains(key))
                    .ToList();


                return list;

            }
            catch (Exception er)
            {

                return null;
            }
            return null;
        }

        public dynamic GetAllPage(int pagno)
        {
            dynamic obj = db.tblDoctors.OrderByDescending(o => o.Id).Skip(8 * pagno).Take(8).ToList();
            return obj;
        }

        public string Save(tblDoctor obj)
        {
            try
            {
               
                if (obj.Id == 0)
                {
                    tblDoctor list = new tblDoctor();
                 
                
  
                list.ClinicId = obj.ClinicId;
                list.Name = obj.Name;
                list.Email = obj.Email;
                list.Address = obj.Address;
                list.Mobile = obj.Mobile;
                list.Qulification = obj.Qulification;
                list.Specilization = obj.Specilization;
                list.Gender = obj.Gender;
                list.Role = obj.Role;
                list.UserName = obj.UserName;
                list.Password = obj.Password;
                list.Photo = obj.Photo;
                list.CreatedOn = DateTime.Now;
                list.CreatedBy = 1;
               
                    db.tblDoctors.Add(list);
                    db.SaveChanges();

                    return "Saved Sucsessfully";

                }
                else
                {
                    var list = db.tblDoctors.Find(obj.Id);

                    list.ClinicId = obj.ClinicId;
                    list.Name = obj.Name;
                    list.Email = obj.Email;
                    list.Address = obj.Address;
                    list.Mobile = obj.Mobile;
                    list.Qulification = obj.Qulification;
                    list.Specilization = obj.Specilization;
                    list.Gender = obj.Gender;
                    list.Role = obj.Role;
                    list.UserName = obj.UserName;
                    list.Password = obj.Password;
                    list.Photo = obj.Photo;
                    list.CreatedOn = DateTime.Now;
                    list.CreatedBy = 1;

                    db.tblDoctors.Attach(list);
                    db.Entry(list).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return "Updated Sucsessfully";
                }
                
            }
            catch (Exception ER)
            {



                return "Error" + ER.Message;

            }







        }

    }
}
  
