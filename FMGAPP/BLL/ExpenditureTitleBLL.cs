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
    public class ExpenditureTitleBLL : IBLL<ExpenditureTitleDTO, ExpenditureTitleDetailDTO>
    {
        ExpenditureTitleDAO dao = new ExpenditureTitleDAO();
        public bool Delete(ExpenditureTitleDetailDTO entity)
        {
            EXPENDITURE_TITLE title = new EXPENDITURE_TITLE();
            title.expenditureTitleID = entity.ExpenditureTitleID;
            return dao.Delete(title);
        }
        public bool DeletePermanently(ExpenditureTitleDetailDTO entity)
        {
            EXPENDITURE_TITLE title = new EXPENDITURE_TITLE();
            title.expenditureTitleID = entity.ExpenditureTitleID;
            return dao.DeletePermanently(title);
        }

        public bool GetBack(ExpenditureTitleDetailDTO entity)
        {
            return dao.GetBack(entity.ExpenditureTitleID);
        }

        public bool Insert(ExpenditureTitleDetailDTO entity)
        {
            EXPENDITURE_TITLE title = new EXPENDITURE_TITLE();
            title.expenditureTitle = entity.ExpenditureTitle;
            return dao.Insert(title);
        }

        public ExpenditureTitleDTO Select()
        {
            ExpenditureTitleDTO dto = new ExpenditureTitleDTO();
            dto.ExpenditureTitles = dao.Select();
            return dto;
        }

        public bool Update(ExpenditureTitleDetailDTO entity)
        {
            EXPENDITURE_TITLE title = new EXPENDITURE_TITLE();
            title.expenditureTitleID = entity.ExpenditureTitleID;
            title.expenditureTitle = entity.ExpenditureTitle;
            return dao.Update(title);
        }
    }
}
