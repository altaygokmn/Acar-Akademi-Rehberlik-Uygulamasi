//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AcarAkademiRehberlik
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attendance
    {
        public int attendance_id { get; set; }
        public Nullable<int> student_id { get; set; }
        public Nullable<System.DateTime> attendance_date { get; set; }
        public string attendance_status { get; set; }
        public string attendance_details { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
