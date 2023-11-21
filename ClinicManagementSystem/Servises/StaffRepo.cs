using ClinicManagementSystem.Iservises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Servises
{
    public class StaffRepo : IStaff
    {
        HospitalDBEntities db = new HospitalDBEntities();
        public bool Delete(int id)
        {
            var obj = db.tblStaffs.Find(id);

            if (obj != null)
            {
                db.tblStaffs.Remove(obj);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public tblStaff Findbyid(int id)
        {
            tblStaff obj = db.tblStaffs.Find(id);


            return obj;
        }

        public List<tblStaff> GetAll()
        {
            List<tblStaff> obj = db.tblStaffs.ToList();



            return obj;
        }

        public dynamic GetAllkey(string key)
        {
            try
            {
                dynamic list = db.tblStaffs
                    .Select(s => new {
                        s.Id,
                        s.Name,
                        s.Address,
                        s.Mobile,
                        s.Password,
                        s.UserName,
                        s.CreatedBy,
                        s.CreatedOn,
                        s.Role,
                        
                    }).
                        Where(w => w.Name.Contains(key) || w.Address.Contains(key))
                    .ToList();


                return list;

            }
            catch (Exception )
            {

                return null;
            }
        

        }

        public dynamic GetAllPage(int pagno)
        {
            dynamic obj = db.tblStaffs.OrderByDescending(o => o.Id).Skip(8 * pagno).Take(8).ToList();
            return obj;
        }

        public string Save(tblStaff obj)
        {
            try
            {
                tblStaff list = db.tblStaffs.Find(obj.Id);
                if (list == null)
                {
                    list = new tblStaff();

                }
                  list.Id = obj.Id;
                   list.Name = obj.Name;
                    list.Address = obj.Address;
                     list.Mobile = obj.Mobile;
                    list.Role = obj.Role;
                   list.UserName = obj.UserName;
                  list.Password = obj.Password;
                
                    list.CreatedOn = DateTime.Now;
                    list.CreatedBy = 1;
                if (obj.Id == 0)
                {
                    db.tblStaffs.Add(list);
                    db.SaveChanges();

                    return "Saved Sucsessfully";

                }
                else
                {



                    //list.Name = obj.Name;
                    //list.Email = obj.Email;
                    //list.Address = obj.Address;
                    //list.Mobile = obj.Mobile;
                    //list.Qulification = obj.Qulification;
                    //list.Specilization = obj.Specilization;
                    //list.Gender = obj.Gender;
                    //list.Role = obj.Role;
                    //list.UserName = obj.UserName;
                    //list.Password = obj.Password;
                    //list.Photo = obj.Photo;
                    //list.CreatedOn = DateTime.Now;
                    //list.CreatedBy = 1;

                    db.tblStaffs.Attach(list);
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