using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DTO
{
    public class FinancialReportDetailDTO
    {
        public int FinancialReportID { get; set; }
        public decimal TotalOfferings { get; set; }
        public string TotalOfferingsWithCurrency { get; set; }
        public decimal TotalExpenditures { get; set; }
        public string TotalExpendituresWithCurrency { get; set; }
        public decimal TotalBalance { get; set; }
        public string TotalBalanceWithCurrency { get; set; }
        public int MonthID { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
    }
}
