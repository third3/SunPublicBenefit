using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SunPublicBenefit.Models
{
    public class ProjectApplication
    {
        [Key]
        public Guid ApplicationID { get; set; }

        [DisplayName("项目名称")]
        [Required(ErrorMessage = "请输入项目名称")]
        [MaxLength(8)]
        public string ProjectName { get; set; }

        [DisplayName("项目地点")]
        [Required(ErrorMessage = "请输入项目地点")]
        public string ProjectSite { get; set; }

        [DisplayName("电子邮箱")]
        [Required(ErrorMessage = "请输入电子邮箱")]
        public string Email { get; set; }

        [DisplayName("筹款目标金额")]
        [Required(ErrorMessage = "请输入筹款目标金额")]
        public int TargetFigure { get; set; }

        [DisplayName("项目主图")]
        [Required(ErrorMessage = "请上传项目主图")]
        public string ImportantImageAddress { get; set; }

        [DisplayName("项目简介")]
        [Required(ErrorMessage = "请填写项目简介")]
        public string ProjectBriefIntroduction { get; set; }

        [DisplayName("项目配图")]
        [Required(ErrorMessage = "请上传项目配图")]
        public string BasicImageAddress { get; set; }

        [DisplayName("项目介绍标题")]
        [Required(ErrorMessage = "请填写项目介绍标题")]
        public string ProjectIntroductionTitle { get; set; }

        [DisplayName("项目介绍")]
        [Required(ErrorMessage = "请填写项目介绍")]
        public string ProjectIntroduction { get; set; }

        [DisplayName("项目发起人")]
        public string UserName { get; set; }

        public virtual ICollection<Project> Project { get; set; }

    }
}