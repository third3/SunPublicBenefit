using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SunPublicBenefit.Models
{
    public class SunPublicBenefitDBContextOne : DbContext
    {
        public SunPublicBenefitDBContextOne() : base("SunPublicBenefitDBContext")
        {

        }
        public DbSet<DonationRecord> DonationRecord { get; set; }
        public DbSet<Finance> Finance { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectRecord> ProjectRecord { get; set; }
        public DbSet<PublicBenefit> PublicBenefit { get; set; }
        public DbSet<PublicBenefitRecord> PublicBenefitRecord { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<UnBeneficenceApprove> UnBeneficenceApprove { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<ProjectApplication> ProjectApplication { get; set; }
    }
}