//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Base.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeDetail
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public int IdentityCard { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Nation { get; set; }
        public System.DateTime Birthday { get; set; }
        public string Certificate { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public int EducationID { get; set; }
        public int PositionID { get; set; }
        public byte[] Avatar { get; set; }
        public Nullable<int> Status { get; set; }
        public System.DateTime StartWorkingTime { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Education Education { get; set; }
        public virtual Position Position { get; set; }
    }
}
