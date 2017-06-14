using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunPublicBenefit.Models
{
    public class ProjectRecord
    {
        [Key]
        public Guid Record_ID { get; set; }
        public Project Project { get; set; }
    }
}