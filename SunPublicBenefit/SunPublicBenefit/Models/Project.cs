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
            this.User1 = new HashSet<User1>();
        }
    
        public string ID { get; set; }
        public string ProjectName { get; set; }
        public System.DateTime StartProjectTime { get; set; }
        public System.DateTime EndProjectTime { get; set; }
        public decimal Moneyd { get; set; }
        public short Isstatus { get; set; }
        public int UserNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User1> User1 { get; set; }
        public virtual ProjectRecord ProjectRecord { get; set; }
        public virtual Finance Finance { get; set; }
        public virtual DoNationRecord DoNationRecord { get; set; }
    }
}
