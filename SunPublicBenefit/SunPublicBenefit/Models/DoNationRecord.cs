using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunPublicBenefit.Models
{
    public class DonationRecord
    {
        [Key]
        public Guid ProjectID { get; set; }

        [DisplayName("捐款日期")]
        [Required(ErrorMessage = "请输入捐款日期")]
        public DateTime DonationDate { get; set; }

        [DisplayName("捐款金额")]
        [Required(ErrorMessage = "捐款金额不能为空")]
        public double DonationAmout { get; set; }
        public Users User { get; set; }
        public Project Project { get; set; }
    }
}