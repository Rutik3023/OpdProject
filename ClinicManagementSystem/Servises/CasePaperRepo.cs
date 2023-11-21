using ClinicManagementSystem.Iservises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Servises
{
    public class CasePaperRepo:ICasePaper
    {
        HospitalDBEntities db = new HospitalDBEntities();

        public List<tblCasePaper> GetAll()
        {
            List<tblCasePaper> obj = db.tblCasePapers.ToList();

            return obj;
        }

        

        public string Save(tblCasePaper obj)
        {
            try
            {
                if (obj.Id==0)
                {
                    tblCasePaper List = new tblCasePaper();

                    List.Pid = obj.Pid;
                    List.Createdon = DateTime.Now;
                    List.Createdby = 1;
                    List.Height = obj.Height;
                    List.Wight = obj.Wight;
                    List.BP = obj.BP;
                    List.CasePaperfee = obj.CasePaperfee;
                    List.HealthIssue = obj.HealthIssue;

                    db.tblCasePapers.Add(List);
                    db.SaveChanges();

                    return "Saved Successfully";
                }
                else
                {
                    var List = db.tblCasePapers.Find(obj.Id);

                    List.Pid = obj.Pid;
                    List.Createdon = DateTime.Now;
                    List.Createdby = 1;
                    List.Height = obj.Height;
                    List.Wight = obj.Wight;
                    List.BP = obj.BP;
                    List.CasePaperfee = obj.CasePaperfee;
                    List.HealthIssue = obj.HealthIssue;

                    db.tblCasePapers.Attach(List);
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

        public tblCasePaper FindById(int id)
        {
            tblCasePaper obj = db.tblCasePapers.Find(id);

            return obj;
        }

        public bool Delete(int id)
        {
            var obj = db.tblCasePapers.Find(id);

            if (obj!=null)
            {
                db.tblCasePapers.Remove(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public dynamic GetAllKey(string key)
        {
            try
            {
                dynamic List = db.tblCasePapers.Select(s => new
                {

                    s.Id,
                    s.Pid,
                    s.Createdon,
                    s.Createdby,
                    s.Height,
                    s.Wight,
                    s.BP,
                    s.CasePaperfee,
                    s.HealthIssue,

                }).Where(w => w.BP.Contains(key) || w.HealthIssue.Contains(key))
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
            dynamic obj = db.tblCasePapers.OrderByDescending(o => o.Id).Skip(8 * pageno).Take(8).ToList();
            return obj;
        }
    }
}