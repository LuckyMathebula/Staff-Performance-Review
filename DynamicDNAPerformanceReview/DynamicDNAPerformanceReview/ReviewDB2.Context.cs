﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CMRSEntities2 : DbContext
    {
        public CMRSEntities2()
            : base("name=CMRSEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Management> Managements { get; set; }
        public virtual DbSet<ReviewTable> ReviewTables { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
    }
}
