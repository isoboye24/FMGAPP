﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DTO
{
    public class ImageDocumentDTO
    {
        public List<ImageDocumentDetailDTO> ImageDocuments { get; set; }
        public List<MonthDetailDTO> Months { get; set; }
        public List<int> Years { get; set; }
    }
}
