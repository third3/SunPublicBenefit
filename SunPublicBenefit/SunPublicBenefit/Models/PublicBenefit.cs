using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunPublicBenefit.Models
{
    public class PublicBenefit
    {
        [Key]
        public Guid BenefitID { get; set; }

        [DisplayName("公益名称")]
        [Required(ErrorMessage = "公益名称不能为空")]
        public string BenefitName { get; set; }

        [DisplayName("是否为线上公益")]
        public bool IsOnLine { get; set; }

        [DisplayName("项目申请时间")]
        public DateTime ApplyStartDate { get; set; }

        [DisplayName("公益地点")]
        public string Site { get; set; }

        [DisplayName("项目申请结束时间")]
        public DateTime ApplyAbortDate { get; set; }

        [DisplayName("项目参与的人数")]
        public int ApplyCount { get; set; }

        [DisplayName("项目简单说明")]
        public string ActivevityProFile { get; set; }

        [DisplayName("是否同意通过该项目的申请")]
        public int ConsentApply { get; set; }

        public virtual ICollection<PublicBenefitRecord> PublicBenefitRecord { get; set; } 
    }
}