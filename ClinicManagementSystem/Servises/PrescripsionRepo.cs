using ClinicManagementSystem.Api;
using ClinicManagementSystem.Iservises;
using ClinicManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public string Save(PrescriptionMaster obj)
        {
            try
            {
                //tblPrescriptionMaster p = new tblPrescriptionMaster();
                //p.Aid = obj.AId;
                //p.Disiese = obj.Disiese;
                //p.Symtam = obj.Symtams;
                //p.Naration = obj.Narration;
                //p.Createdon = DateTime.Now;

                //p.tblprescripationMedicineDetails = new List<tblprescripationMedicineDetail>();

                //foreach (var item in obj.ShopCart)
                //{
                //    tblprescripationMedicineDetail pd = new tblprescripationMedicineDetail();

                //    pd.prid = obj.Id;
                //    pd.medicineid = item.MedicineId;
                //    pd.Qty = item.QTY;
                //    pd.MDose = item.MDose;
                //    pd.AfDose = item.AfDose;
                //    pd.NDose = item.NDose;

                //    p.tblprescripationMedicineDetails.Add(pd);

                //}
                //db.tblPrescriptionMasters.Add(p);
                //db.SaveChanges();

                //return "Saved";

                object[] parameter = new object[7];

                SqlParameter Aid = new SqlParameter();
                Aid.ParameterName = "Aid";
                Aid.SqlDbType = SqlDbType.Int;
                Aid.Value = obj.AId;
                parameter[0] = Aid;

                SqlParameter naration = new SqlParameter();
                naration.ParameterName = "naration";
                naration.SqlDbType = SqlDbType.NVarChar;
                naration.Size = 8000;
                naration.Value = obj.Narration;
                parameter[1] = naration;

                SqlParameter Symtam = new SqlParameter();
                Symtam.ParameterName = "Symtam";
                Symtam.SqlDbType = SqlDbType.NVarChar;
                Symtam.Size = 8000;
                Symtam.Value = obj.Symtams;
                parameter[2] = Symtam;

                SqlParameter Disiese = new SqlParameter();
                Disiese.ParameterName = "Disiese";
                Disiese.SqlDbType = SqlDbType.NVarChar;
                Disiese.Size = 8000;
                Disiese.Value = obj.Disiese;
                parameter[3] = Disiese;

              
                SqlParameter Code = new SqlParameter();
                Code.ParameterName = "Code";
                Code.SqlDbType = SqlDbType.Int;
                Code.Direction = ParameterDirection.Output;
                parameter[4] = Code;

                SqlParameter Message = new SqlParameter();
                Message.ParameterName = "Message";
                Message.SqlDbType = SqlDbType.NVarChar;
                Message.Size = 8000;
                Message.Direction = ParameterDirection.Output;
                parameter[5] = Message;


                SqlParameter Pitems = new SqlParameter();
                Pitems.ParameterName = "poItems";
                Pitems.TypeName = "pitem";
                Pitems.SqlDbType = SqlDbType.Structured;
              
                Pitems.Value =CommonRepo.ToDataTable(obj.ShopCart.Select(s => new {s.MedicineId,s.QTY,s.NDose,s.MDose,s.AfDose }).ToList()); 

                parameter[6] = Pitems;


                db.Database.ExecuteSqlCommand("exec Saveprescripstion @Aid,@naration,@Symtam,@Disiese,@poItems,@Code out,@Message out", parameter);

                return  Message.Value.ToString();
            }
            catch (Exception er)
            {
                return er.Message.ToString();

            }

           
            
           
        }
    }
}