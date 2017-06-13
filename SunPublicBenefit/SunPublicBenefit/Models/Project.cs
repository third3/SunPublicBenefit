//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SunPublicBenefit.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.DoNationRecord = new HashSet<DoNationRecord>();
            this.ProjectRecord = new HashSet<ProjectRecord>();
            this.Finance = new HashSet<Finance>();
        }
    
        public string ID { get; set; }
        public string ProjectName { get; set; }
        public System.DateTime StartProjectTime { get; set; }
        public System.DateTime EndProjectTime { get; set; }
        public decimal Moneyd { get; set; }
        public short Isstatus { get; set; }
        public int UserNumber { get; set; }
        public string Details { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoNationRecord> DoNationRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectRecord> ProjectRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Finance> Finance { get; set; }
    }
}
