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
    
    public partial class Debtors_Transaction
    {
        public int Debtors_Transaction_Id { get; set; }
        public string AccountCode { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public Nullable<int> DocumentNo { get; set; }
        public decimal Gross_Transaction_Value { get; set; }
        public decimal Vat_Value { get; set; }
    
        public virtual DebtorsMaster DebtorsMaster { get; set; }
    }
}
