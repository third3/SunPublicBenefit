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
    
    public partial class User1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User1()
        {
            this.PublicBenefitRecord = new HashSet<PublicBenefitRecord>();
            this.UserApprove = new HashSet<UserApprove>();
            this.DoNationRecord = new HashSet<DoNationRecord>();
        }
    
        public string ID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    
        public virtual Role Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PublicBenefitRecord> PublicBenefitRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserApprove> UserApprove { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoNationRecord> DoNationRecord { get; set; }
    }
}
