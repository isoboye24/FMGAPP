﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DTO
{
    public class ExpenditureDTO
    {
        public List<ExpenditureDetailDTO> Expenditures { get; set; }
        public List<ExpenditureTitleDetailDTO> ExpenditureTitles { get; set; }
        public List<MonthDetailDTO> Months { get; set; }
    }
}
