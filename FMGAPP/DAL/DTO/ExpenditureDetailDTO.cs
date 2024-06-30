using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DTO
{
    public class ExpenditureDetailDTO
    {
        public int ExpenditureID { get; set; }
        public decimal AmountSpent { get; set; }
        public string ExpenditureTitle { get; set; }
        public string Summary { get; set; }
        public int Day { get; set; }
        public int MonthID { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
        public int ExpenditureTitleID { get; set; }
        public DateTime ExpenditureDate { get; set; }
        public bool isExpenditureTitleDeleted { get; set; }
    }
}
