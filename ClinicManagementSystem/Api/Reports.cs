using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Api
{
    public class Reports
    {
        public int Code { get; set; }

        public dynamic Message { get; set; }
        public int pageno { get; set; }

        public int count { get; set; }

        public string Path { get; set; }
    }
}