//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NeinteenFlower.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrHeader()
        {
            this.TrDetails = new HashSet<TrDetail>();
        }
    
        public int TransactionId { get; set; }
        public int MemberId { get; set; }
        public int EmployeeId { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public int DiscountPercentage { get; set; }
    
        public virtual MsEmployee MsEmployee { get; set; }
        public virtual MsMember MsMember { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrDetail> TrDetails { get; set; }
    }
}