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
    
    public partial class tblStaff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblStaff()
        {
            this.tblPatients = new HashSet<tblPatient>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Role { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
    
        public virtual tblDoctor tblDoctor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPatient> tblPatients { get; set; }
    }
}
