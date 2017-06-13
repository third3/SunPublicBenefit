using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunPublicBenefit.Models
{
    public class Finance
    {
        [Key]
        public Guid FinanceID { get; set; }

        [DisplayName("流动前的金额为:")]
        [Required(ErrorMessage = "流动前的金额不能为空")]
        public double PreMoney { get; set; }

        [DisplayName("是否为资金流入")]
        public bool IsIn { get; set; }

        [DisplayName("流动的金额为:")]
        [Required(ErrorMessage ="流动的金额不能为空")]
        public double MoneyL { get; set; }

        [DisplayName("流动后的金额为:")]
        [Required(ErrorMessage = "流动后的金额不能为空.")]
        public double OutMoney { get; set; }

        public User User { get; set; }
        public Project Project { get; set; }


    }
}