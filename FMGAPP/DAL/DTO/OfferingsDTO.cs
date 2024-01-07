using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DTO
{
    public class OfferingsDTO
    {
        public List<OfferingsDetailDTO> Offerings { get; set; }
        public List<MonthDetailDTO> Months { get; set; }
    }
}
