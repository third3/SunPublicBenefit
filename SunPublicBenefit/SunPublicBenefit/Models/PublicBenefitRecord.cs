using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunPublicBenefit.Models
{
    public class PublicBenefitRecord
    {
        [Key]
        public Guid BenefitRecordID { get; set; }

        public Users User { get; set; }
        public PublicBenefit PublicBenefit { get; set; }
    }
}