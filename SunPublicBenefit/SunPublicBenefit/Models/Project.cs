using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunPublicBenefit.Models
{
    public class Project
    {
        [Key]
        public Guid ProjectID { get; set; }

        [DisplayName("项目名称")]
        [Required(ErrorMessage = "请输入项目名称")]
        public string ProjectName { get; set; }

        [DisplayName("项目创始人ID")]
        [Required(ErrorMessage = "项目创始人不能为空")]
        public int User_ID { get; set; }

        [DisplayName("项目开始时间")]
        public DateTime StartProjectTime { get; set; }

        [DisplayName("项目结束时间")]
        public DateTime EndProjectTime { get; set; }

        [DisplayName("目前项目已筹金额为:")]
        public Double Moneyed { get; set; }

        [DisplayName("项目状态")]
        public int Isstatus { get; set; }

        [DisplayName("项目参与人数")]
        public int UserNumber { get; set; }

        [DisplayName("用户")]
        public virtual User User { get; set; }

        [DisplayName("权限")]
        public virtual Roles Role { get; set; }

        public virtual ICollection<DonationRecord> DonationRecord { get; set; }

        public virtual ICollection<ProjectRecord> ProjectRecord { get; set; }
    }
}