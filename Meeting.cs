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
    
    public partial class Meeting
    {
        public int meeting_id { get; set; }
        public Nullable<int> teacher_id { get; set; }
        public Nullable<int> student_id { get; set; }
        public string meetingType { get; set; }
        public string performerName { get; set; }
        public Nullable<System.DateTime> meeting_date { get; set; }
        public string meetingSubject { get; set; }
        public string meetingExplanation { get; set; }
        public string meetingPlanning { get; set; }
        public string meetingNotes { get; set; }
    
        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }
    }
}
