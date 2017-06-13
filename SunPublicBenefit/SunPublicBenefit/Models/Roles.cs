using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunPublicBenefit.Models
{
    public class Roles
    {
       [Key]
      public Guid RoleID { get; set; }

       [DisplayName("姓名")]
       [Required(ErrorMessage = "请输入姓名")]
       public string Name { get; set; }

        [DisplayName("描述")]
        [Required(ErrorMessage = "请输入描述")]
        public string Description { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}