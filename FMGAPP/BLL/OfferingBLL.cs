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
    public class OfferingBLL : IBLL<OfferingsDTO, OfferingsDetailDTO>
    {
        MonthDAO monthDAO = new MonthDAO();
        OfferingDAO dao = new OfferingDAO();
        public bool Delete(OfferingsDetailDTO entity)
        {
            OFFERING offering = new OFFERING();
            offering.offeringID = entity.OfferingID;
            return dao.Delete(offering);
        }
        public bool DeletePermanently(OfferingsDetailDTO entity)
        {
            OFFERING offering = new OFFERING();
            offering.offeringID = entity.OfferingID;
            return dao.DeletePermanently(offering);
        }

        public bool GetBack(OfferingsDetailDTO entity)
        {
            return dao.GetBack(entity.OfferingID);
        }

        public bool Insert(OfferingsDetailDTO entity)
        {
            OFFERING offering = new OFFERING();
            offering.offerings = entity.Offering;
            offering.summary = entity.Summary;
            offering.day = entity.Day;
            offering.monthID = entity.MonthID;
            offering.year = entity.Year;
            return dao.Insert(offering);
        }

        public OfferingsDTO Select()
        {
            OfferingsDTO dto = new OfferingsDTO();
            dto.Offerings = dao.Select();
            dto.Months = monthDAO.Select();
            return dto;
        }

        public bool Update(OfferingsDetailDTO entity)
        {
            OFFERING offering = new OFFERING();
            offering.offeringID = entity.OfferingID;
            offering.offerings = entity.Offering;
            offering.summary = entity.Summary;
            offering.day = entity.Day;
            offering.monthID = entity.MonthID;
            offering.year = entity.Year;
            return dao.Update(offering);
        }
    }
}
