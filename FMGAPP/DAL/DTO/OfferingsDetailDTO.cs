using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DTO
{
    public class OfferingsDetailDTO
    {
        public int OfferingsID { get; set; }
        public decimal Offerings { get; set; }
        public string Summary { get; set; }
        public int Day { get; set; }
        public int MonthID { get; set; }
        public int MonthName { get; set; }
        public int Year { get; set; }
    }
}
