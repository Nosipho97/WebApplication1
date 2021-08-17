using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Debtors.Models
{
    
    public class InvoiceModel
    {
        public int InvoiceNo { get; set; }

        [Display(Name = "Account Code")]
        public string AccountCode { get; set; }
        public List<SelectListItem> AccountCodeList { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Total Selling Amount (Excl Vat)")]
        public decimal TotalSellAmount_ExlVate { get; set; }

        [Display(Name = "VAT")]
        public decimal Vat { get; set; }

        [Display(Name = "Total Cost")]
        public decimal TotalCost { get; set; }
    }
    public class InvoiceDetailsModel
    {
        public int InvoiceDetailsId { get; set; }
        public int InvoiceNo { get; set; }

        [Display(Name = "Item Number")]
        public int ItemNo { get; set; }

        [Display(Name = "Stock Code")]
        public String StockCode { get; set; }
        //new changes 
        public string AccountCode { get; set; }
        public List<SelectListItem> AccountCodeList { get; set; }
        public List<SelectListItem> StockCodeListItem { get; set; }
        
        public MultiSelectList Stocks { get; set; }
        public List<string> StockCodeList { get; set; }
        public bool isActive { get; set; }
        //end

        [Display(Name = "Quantity Sold")]
        public int QtySold { get; set; }

        [Display(Name = "Unit Cost")]
        public int UnitCost { get; set; }

        [Display(Name = "Unit Sell")]
        public int UnitSell { get; set; }

        [Display(Name = "Discount")]
        public double Discount { get; set; }

        [Display(Name = "Total")]
        public decimal TotalCost { get; set; }

        
    }

}
