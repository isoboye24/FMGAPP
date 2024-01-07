﻿using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DAO
{
    public class MonthDAO:FMGContext
    {
        public List<MonthDetailDTO> Select()
        {
			try
			{
				List<MonthDetailDTO> months = new List<MonthDetailDTO>();
				var list = db.MONTHs.ToList();
				foreach (var item in list)
				{
					MonthDetailDTO dto = new MonthDetailDTO();
					dto.MonthID = item.monthID;
					dto.MonthName = item.monthName;
					months.Add(dto);
                }
				return months;
            }
			catch (Exception ex)
			{
				throw ex;
			}
        }
    }
}
