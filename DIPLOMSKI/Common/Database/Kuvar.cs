//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Database
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Kuvar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kuvar()
        {
            this.Jeloes = new HashSet<Jelo>();
        }

        [DataMember]
        public int MBR { get; set; }
        [DataMember]
        public string KNJIZ { get; set; }
        [DataMember]
        public bool POMOCNI { get; set; }

        [DataMember]
        public virtual Zaposleni Zaposleni { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<Jelo> Jeloes { get; set; }
    }
}
