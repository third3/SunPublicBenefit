using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SunPublicBenefit.Models
{
    public class City
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public int ProvinceID { get; set; }
        public virtual Province Province { get; set; }
    }
}