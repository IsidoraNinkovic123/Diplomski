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
    public partial class Dostava
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string ADR { get; set; }
        [DataMember]
        public int BR_STANA { get; set; }
        [DataMember]
        public int Dostavljac_MBR { get; set; }
    
        public virtual Dostavljac Dostavljac { get; set; }
        [DataMember]
        public virtual Porudzbina Porudzbina { get; set; }
    }
}
