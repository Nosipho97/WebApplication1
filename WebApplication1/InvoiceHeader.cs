//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoiceHeader
    {
        public int InvoiceNo { get; set; }
        public string AccountCode { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<decimal> TotalSellAmountExlVate { get; set; }
        public Nullable<decimal> Vat { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
    
        public virtual DebtorsMaster DebtorsMaster { get; set; }
    }
}