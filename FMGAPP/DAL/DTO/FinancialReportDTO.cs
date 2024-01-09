using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DTO
{
    public class FinancialReportDTO
    {
        public List<MonthDetailDTO> Months { get; set; }
        public List<FinancialReportDetailDTO> FinancialReports { get; set; }
        public List<int> Years { get; set; }
    }
}
