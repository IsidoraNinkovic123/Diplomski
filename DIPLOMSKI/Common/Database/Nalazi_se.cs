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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Nalazi_se
    {
        [DataMember]
        public string Porudzbina_ID { get; set; }
        [DataMember]
        public string Stavka_menija_ID { get; set; }
        [DataMember]
        public int KOL { get; set; }

        
        public virtual Porudzbina Porudzbina { get; set; }
        
        public virtual Stavka_menija Stavka_menija { get; set; }
    }
}
