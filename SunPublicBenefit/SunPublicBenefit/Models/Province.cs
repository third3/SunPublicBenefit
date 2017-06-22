using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SunPublicBenefit.Models
{
    public class Province
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ProvinceName { get; set; }
        public virtual ICollection<City> City { get; set; }
    }
}