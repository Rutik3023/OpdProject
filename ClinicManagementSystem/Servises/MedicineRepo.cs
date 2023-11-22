using ClinicManagementSystem.Iservises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Servises
{
    public class MedicineRepo : IMedicine
    {
        HospitalDBEntities db = new HospitalDBEntities();

        public List<tblMedicine> GetAll()
        {
            List<tblMedicine> obj = db.tblMedicines.ToList();
            return obj;
        }

        public string Save(tblMedicine obj)
        {
            try
            {
                if (obj.Id==0)
                {
                    tblMedicine List = new tblMedicine();

                    List.Name = obj.Name;
                    List.MContent = obj.MContent;
                    List.Company = obj.Company;

                    db.tblMedicines.Add(List);
                    db.SaveChanges();

                    return "Saved Successfully";
                }
                else
                {
                    var List = db.tblMedicines.Find(obj);

                    List.Name = obj.Name;
                    List.MContent = obj.MContent;
                    List.Company = obj.Company;

                    db.tblMedicines.Attach(List);
                    db.Entry(List).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return "Updated Successfully";
                }
            }
            catch (Exception er)
            {

                return "Error" + er.Message;
            }
            
        }

        public tblMedicine FindById(int id)
        {
            var obj = db.tblMedicines.Find(id);

            return obj;
        }

        public bool Delete(int id)
        {
            var obj = db.tblMedicines.Find(id);

            if (obj!=null)
            {
                db.tblMedicines.Remove(obj);
                db.SaveChanges();

                return true;

            }
            return false;
        }

        public dynamic GetAllKey(string key)
        {
            dynamic List = db.tblMedicines.Select(s => new
            {
                s.Id,
                s.Name,
                s.MContent,
                s.Company
            }).Where(w => w.Name.Contains(key) || w.Company.Contains(key)).ToList();

            return List;
            
        }

        public dynamic GetAllPage(int pageno)
        {
            dynamic obj = db.tblMedicines.OrderByDescending(o => o.Id).Skip(8 * pageno).Take(8).ToList();

            return obj;
        }
    }
}