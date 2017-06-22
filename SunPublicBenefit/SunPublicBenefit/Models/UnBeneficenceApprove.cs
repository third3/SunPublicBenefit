using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SunPublicBenefit.Models
{
    /// <summary>
    /// 非公益机构注册
    /// </summary>
    public class UnBeneficenceApprove
    {
        [Key]
        public Guid unBenID {get;set;}

        [DisplayName("登录名")]
        public Users userName { get; set; }

        [DisplayName("机构名称")]
        [Required(ErrorMessage = "机构名称不能为空")]
        public string FullName { get; set; }

        [DisplayName("机构电话")]
        public string telePhone { get; set; }

        [DisplayName("常驻地址")]
        public string residentAddress { get; set; }

        [DisplayName("机构登记性质")]
        public string nature { get; set; }
        [DisplayName("机构规模")]
        public string scale { get; set; }

        [DisplayName("成立日期")]
        public DateTime estaBlishDate { get; set; }

        [DisplayName("官方主页")]
        public string website { get; set; }

        [DisplayName("机构简介")]
        public string demo { get; set; }

        [DisplayName("验证码")]
        public string code { get; set; }
    }
}