using ClinicManagementSystem.Iservises;
using ClinicManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Servises
{
    public class ClinicRepo : IClinic
    {
        HospitalDBEntities db = new HospitalDBEntities();
        public bool Delete(int id)
        {
            var obj = db.tblClinics.Find(id);

            if (obj != null)
            {
                db.tblClinics.Remove(obj);
                db.SaveChanges();
                return true;
            }

            return false;
        }


        public tblClinic Findbyid(int id)
        {
            tblClinic obj = db.tblClinics.Find(id);


            return obj;

        }

        public List<tblClinic> GetAll()
        {

            List<tblClinic> obj = db.tblClinics.ToList();



            return obj;

        }

    

        public dynamic GetAllkey(string key)
        {
            try
            {
                dynamic list = db.tblClinics
                    .Select(s => new {
                        s.Id,
                        s.Name,
                        s.Email,
                        s.RegNo,
                        s.Address,
                        s.CloseTime,
                        s.Photo,
                        s.CreatedOn,
                        s.OpenTime
                    }).
                        Where(w => w.Name.Contains(key)  || w.Email.Contains(key))
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
            dynamic obj = db.tblClinics.OrderByDescending(o => o.Id).Skip(8 * pagno).Take(8).ToList();
            return obj;
        }

        public string Save(tblClinic obj)
        {
            try
            {
                


                if (obj.Id==0)
                {
                    tblClinic list = new tblClinic();

                    list.Name = obj.Name;
                    list.Email = obj.Email;
                    list.Address = obj.Address;
                    list.RegNo = obj.RegNo;
                    list.OpenTime = obj.OpenTime;
                    list.CloseTime = obj.CloseTime;
                    list.CreatedOn = DateTime.Now;
                    list.CreatedBy = 1;
                    list.Mobile = obj.Mobile;


                    db.tblClinics.Add(list);
                    db.SaveChanges();
                    
                    return "Saved Sucsessfully";
                    
                    

                }
                else
                {
                   var list = db.tblClinics.Find(obj.Id);
                   
                    list.Name = obj.Name;
                    list.Email = obj.Email;
                    list.Address = obj.Address;
                    list.RegNo = obj.RegNo;
                    list.OpenTime = obj.OpenTime;
                    list.CloseTime = obj.CloseTime;
                    list.CreatedOn = DateTime.Now;
                    list.Mobile = obj.Mobile;
                    list.CreatedBy = 1;

                    db.tblClinics.Attach(list);
                    db.Entry(list).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return "Updated Sucsessfully";
                }
              
              
            }
            catch (Exception ER)
            {

              
                
                return "Error"+ ER.Message;

            }




        }
    }
}