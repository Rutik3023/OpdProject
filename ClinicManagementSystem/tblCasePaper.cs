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
    
    public partial class tblCasePaper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCasePaper()
        {
            this.tblAppointments = new HashSet<tblAppointment>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Pid { get; set; }
        public Nullable<System.DateTime> Createdon { get; set; }
        public Nullable<int> Createdby { get; set; }
        public string Height { get; set; }
        public string Wight { get; set; }
        public string BP { get; set; }
        public Nullable<double> CasePaperfee { get; set; }
        public string HealthIssue { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAppointment> tblAppointments { get; set; }
        public virtual tblPatient tblPatient { get; set; }
    }
}