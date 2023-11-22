using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Iservises
{
    public interface IMedicine
    {
        List<tblMedicine> GetAll();

        string Save(tblMedicine obj);

        tblMedicine FindById(int id);

        bool Delete(int id);

        dynamic GetAllKey(string key);

        dynamic GetAllPage(int pageno);
    }
}