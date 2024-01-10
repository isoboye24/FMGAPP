using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DTO
{
    public class ImageDocumentDetailDTO
    {
        public int DocumentImageID { get; set; }
        public string ImagePath { get; set; }
        public string DocumentName { get; set; }
        public string Summary { get; set; }
        public int Day { get; set; }
        public int MonthID { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
    }
}
