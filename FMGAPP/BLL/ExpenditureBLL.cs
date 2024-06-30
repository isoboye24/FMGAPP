using FMGAPP.DAL;
using FMGAPP.DAL.DAO;
using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.BLL
{
    public class ExpenditureBLL : IBLL<ExpenditureDTO, ExpenditureDetailDTO>
    {
        MonthDAO monthDAO = new MonthDAO();
        ExpenditureTitleDAO expTitleDAO = new ExpenditureTitleDAO();
        ExpenditureDAO dao = new ExpenditureDAO();
        public bool Delete(ExpenditureDetailDTO entity)
        {
            EXPENDITURE expenditure = new EXPENDITURE();
            expenditure.expenditureID = entity.ExpenditureID;
            return dao.Delete(expenditure);
        }
        public bool DeletePermanently(ExpenditureDetailDTO entity)
        {
            EXPENDITURE expenditure = new EXPENDITURE();
            expenditure.expenditureID = entity.ExpenditureID;
            return dao.DeletePermanently(expenditure);
        }

        public bool GetBack(ExpenditureDetailDTO entity)
        {
            return dao.GetBack(entity.ExpenditureTitleID);
        }

        public decimal TotalExpensesThisMonth(int month)
        {
            return dao.TotalExpensesThisMonth(month);
        }
        public decimal TotalExpensesThisYear(int year)
        {
            return dao.TotalExpensesThisYear(year);
        }

        public bool Insert(ExpenditureDetailDTO entity)
        {
            EXPENDITURE expenditure = new EXPENDITURE();
            expenditure.amountSpent = entity.AmountSpent;
            expenditure.summary = entity.Summary;
            expenditure.day = entity.Day;
            expenditure.monthID = entity.MonthID;
            expenditure.year = entity.Year;
            expenditure.expenditureDate = entity.ExpenditureDate;
            expenditure.expenditureTitleID = entity.ExpenditureTitleID;
            return dao.Insert(expenditure);
        }

        public ExpenditureDTO Select()
        {
            ExpenditureDTO dto = new ExpenditureDTO();
            dto.Months = monthDAO.Select();
            dto.ExpenditureTitles = expTitleDAO.Select();
            dto.Expenditures = dao.Select();
            return dto;
        }

        public bool Update(ExpenditureDetailDTO entity)
        {
            EXPENDITURE expenditure = new EXPENDITURE();
            expenditure.expenditureID = entity.ExpenditureID;
            expenditure.amountSpent = entity.AmountSpent;
            expenditure.summary = entity.Summary;
            expenditure.day = entity.Day;
            expenditure.monthID = entity.MonthID;
            expenditure.year = entity.Year;
            expenditure.expenditureDate = entity.ExpenditureDate;
            expenditure.expenditureTitleID = entity.ExpenditureTitleID;
            return dao.Update(expenditure);
        }
    }
}
