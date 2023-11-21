using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Iservises
{
    public interface ICasePaper
    {
        List<tblCasePaper> GetAll();

        string Save(tblCasePaper obj);

        tblCasePaper FindById(int id);

        bool Delete(int id);

        dynamic GetAllKey(string key);

        dynamic GetAllPage(int pageno);
    }
}