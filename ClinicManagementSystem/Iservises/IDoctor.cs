using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Iservises
{
    public interface IDoctor
    {
        List<tblDoctor> GetAll();

        tblDoctor Findbyid(int id);



        string Save(tblDoctor obj);

        bool Delete(int id);

        dynamic GetAllkey(string key);


        dynamic GetAllPage(int pagno);

    }
}