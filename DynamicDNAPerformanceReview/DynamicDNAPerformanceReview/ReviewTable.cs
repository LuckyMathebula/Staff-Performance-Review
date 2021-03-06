//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DynamicDNAPerformanceReview
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReviewTable
    {
        public int ReviewID { get; set; }
        public Nullable<int> fkManagementID { get; set; }
        public Nullable<int> fkEmployeeId { get; set; }
        public string RoleOnProject { get; set; }
        public string ProjectEngagement { get; set; }
        public string LineManager { get; set; }
        public Nullable<System.DateTime> DateOfReview { get; set; }
        public string PeriodOfReview { get; set; }
        public string proPeer { get; set; }
        public string ProManagement { get; set; }
        public string proAgreed { get; set; }
        public string ExPeer { get; set; }
        public string ExMan { get; set; }
        public string ExAgreed { get; set; }
        public string JudPeer { get; set; }
        public string JudMan { get; set; }
        public string JudAgreed { get; set; }
        public string IntPeer { get; set; }
        public string IntMan { get; set; }
        public string IntAgreed { get; set; }
        public string JobPeer { get; set; }
        public string JobMan { get; set; }
        public string JobAgreed { get; set; }
        public string PassPeer { get; set; }
        public string PassMan { get; set; }
        public string PassAgreed { get; set; }
        public string TeaPeer { get; set; }
        public string TeaMan { get; set; }
        public string TeaAgreed { get; set; }
        public string GroPeer { get; set; }
        public string GroMan { get; set; }
        public string GroAgreed { get; set; }
        public string OverallAverage { get; set; }
        public string GeneralComments { get; set; }
        public string prComments { get; set; }
        public string ExComments { get; set; }
        public string JuComments { get; set; }
        public string intComments { get; set; }
        public string JobComments { get; set; }
        public string PassComments { get; set; }
        public string TeaComments { get; set; }
        public string GroComments { get; set; }
        public string CareerPlans { get; set; }
        public string ObjectivesNextPeriod { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string OverallAVGman { get; set; }
        public string OverallAVGAgreed { get; set; }
        public string GrandAverage { get; set; }
    
        public virtual Management Management { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
