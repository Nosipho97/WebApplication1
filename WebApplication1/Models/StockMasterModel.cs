using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock.Models
{
    public class StockModel
    {
        public String StockCode { get; set; }
        public String StockDescription { get; set; }
        public decimal Cost { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal TotalPurchase_ExlVat { get; set; }
        public decimal TotalSale_ExlVat { get; set; }
        public int QtyPurchase { get; set; }
        public int QtySold { get; set; }
        public int StockOnHand { get; set; }
    }
    public class StockTransactionModel
    {
        public int StockTransactionId { get; set; }
        public int StockCode { get; set; }
        public DateTime Date { get; set; }
        public String TransactionType { get; set; }
        public int DocumentNo { get; set; }
        public int Qty { get; set; }
        public int UnitCost { get; set; }
        public int UnitSell { get; set; }
    }
}