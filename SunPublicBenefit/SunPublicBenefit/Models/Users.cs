using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunPublicBenefit.Models
{
    public class Users
    {
        [Key]
        public Guid UserID { get; set; }

        [DisplayName("用户名")]
        [Required(ErrorMessage = "请输入用户名")]
        public string UserName { get; set; }

        [DisplayName("密码")]
        [Required(ErrorMessage = "请输入密码")]
        public string PassWord { get; set; }

        [DisplayName("真实姓名")]
        public string RealName { get; set; }

        [DisplayName("身份证号码")]
        public string Identity { get; set; }

        [DisplayName("用户的是否通过认证")]
        [Required(ErrorMessage = "用户是否通过认证")]
        public int IsStatus { get; set; }

        [DisplayName("权限")]
        public virtual Roles Role { get; set; }

        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<DonationRecord> DonationRecord { get; set; }
        public virtual ICollection<Finance> Finance { get; set; }
        public virtual ICollection<PublicBenefit> PublicBenefit { get; set; }
        public virtual ICollection<PublicBenefitRecord> PublicBenefitRecord { get; set; }
        public virtual ICollection<UnBeneficenceApprove> UnBeneficenceApprove { get; set; }
    }
}