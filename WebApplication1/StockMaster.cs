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
    
    public partial class StockMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StockMaster()
        {
            this.InvoiceDetails = new HashSet<InvoiceDetail>();
            this.Stock_Transaction = new HashSet<Stock_Transaction>();
        }
    
        public string StockCode { get; set; }
        public string StockDescription { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> Selling_Price { get; set; }
        public decimal TotalPurchase_excl_Vat { get; set; }
        public Nullable<decimal> TotalSales_excl_Vat { get; set; }
        public Nullable<int> QTY_Purchased { get; set; }
        public Nullable<int> QTY_Sold { get; set; }
        public Nullable<int> StockOnHand { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock_Transaction> Stock_Transaction { get; set; }
    }
}