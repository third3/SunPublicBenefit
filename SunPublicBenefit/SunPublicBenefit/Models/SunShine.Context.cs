﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SunPublicBenefit.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SunShineContainer : DbContext
    {
        public SunShineContainer()
            : base("name=SunShineContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User1> User1Set { get; set; }
        public virtual DbSet<Project> ProjectSet { get; set; }
        public virtual DbSet<ProjectRecord> ProjectRecordSet { get; set; }
        public virtual DbSet<Finance> FinanceSet { get; set; }
        public virtual DbSet<PublicBenefitRecord> PublicBenefitRecordSet { get; set; }
        public virtual DbSet<PublicBenefit> PublicBenefitSet { get; set; }
    }
}
