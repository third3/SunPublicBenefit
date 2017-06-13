﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunPublicBenefit.Models
{
    public class User
    {
        [Key]
        public Guid RoleID { get; set; }

        [DisplayName("用户名")]
        [Required(ErrorMessage = "请输入用户名")]
        public string UserName { get; set; }

        [DisplayName("密码")]
        [Required(ErrorMessage = "请输入密码")]
        public string PassWord { get; set; }

        [DisplayName("权限")]
        public virtual Roles Role { get; set; }

        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<DonationRecord> DonationRecord { get; set; }
        public virtual ICollection<Finance> Finance { get; set; }
        public virtual ICollection<PublicBenefit> PublicBenefit { get; set; }
        public virtual ICollection<PublicBenefitRecord> PublicBenefitRecord { get; set; }
    }
}