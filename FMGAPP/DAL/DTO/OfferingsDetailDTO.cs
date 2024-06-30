using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DTO
{
    public class OfferingsDetailDTO
    {
        public int OfferingID { get; set; }
        public decimal Offering { get; set; }
        public string OfferingWithCurrency { get; set; }
        public string Summary { get; set; }
        public int Day { get; set; }
        public int MonthID { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
        public DateTime OfferingDate { get; set; }
        public int OfferingStatusID { get; set; }
        public string OfferingStatus { get; set; }
        public decimal percentage { get; set; }
    }
}
