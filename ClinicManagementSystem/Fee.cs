//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicManagementSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fee
    {
        public double Id { get; set; }
        public Nullable<int> Prid { get; set; }
        public string Tritment { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> Pid { get; set; }
    
        public virtual tblPatient tblPatient { get; set; }
        public virtual tblPrescriptionMaster tblPrescriptionMaster { get; set; }
    }
}
