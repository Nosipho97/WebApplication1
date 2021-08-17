using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace Debtors.Models
{
    public class DebtorsMasterModel
    {
        [Required]
        public string AccountCode { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }

        public decimal? Balance { get; set; }

        public decimal? SalesToYearD { get; set; }

        public decimal? CostToYearD { get; set; }
        public List<DebtorsMaster> DebtorsList { get; set; }
        public string ErrorMessage { get; internal set; }

        /// DebtorsTransactionModel

        public DateTime TransactDate { get; set; }
        public String TransactType { get; set; }
        public int DocumentNo { get; set; }
        public int Gross { get; set; }
        public int Vat { get; set; }
        public List<Debtors_Transaction> TransactionsList { get; set; }


    }
}
    
   