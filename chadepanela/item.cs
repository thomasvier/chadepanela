//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace chadepanela
{
    using System;
    using System.Collections.Generic;
    
    public partial class item
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public Nullable<int> idLista { get; set; }
        public string status { get; set; }
    
        public virtual lista lista { get; set; }
    }
}
