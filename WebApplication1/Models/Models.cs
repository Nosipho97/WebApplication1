using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.Models
{
     public class DebtorsMasterModel
     {
        [Required]
        public string AccountCode { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        
        public Nullable<decimal> Balance { get; set; }
       
        public Nullable<decimal> SalesToYearD { get; set; }
       
        public Nullable<decimal> CostToYearD { get; set; }
     }
    public class DebtorsTransactionModel
    {
        public int AccountCode { get; set; }
        public DateTime TransactDate { get; set; }
        public String TransactType { get; set; }
        public String DocumentNo { get; set; }
        public int Gross { get; set; }
        public int Vat { get; set; }
    }
    
    public class InvoiceModel
    {
        public int InvoiceNo { get; set; }
        public int AccountCode { get; set; }
        public DateTime Date { get; set; }
        public double TotalSellAmount_ExlVat { get; set; }
        public double Vat { get; set; }
        public double TotalCost { get; set; }
    }
    public class InvoiceDetailsModel
    {
        public int InvoiceNo { get; set; }
        public int ItemNo { get; set; }
        public int StockCode { get; set; }
        public int QtySold { get; set; }
        public int UnitCost { get; set; }
        public int UnitSell { get; set; }
        public double Discount { get; set; }
        public double TotalCost { get; set; }
    }

}
