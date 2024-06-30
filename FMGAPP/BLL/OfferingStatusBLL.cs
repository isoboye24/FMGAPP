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
    public class OfferingStatusBLL : IBLL<OfferingStatusDTO, OfferingStatusDetailDTO>
    {
        OfferingStatusDAO dao = new OfferingStatusDAO();
        public bool Delete(OfferingStatusDetailDTO entity)
        {
            OFFERING_STATUS offertingStatus = new OFFERING_STATUS();
            offertingStatus.offeringStatusID = entity.OfferingStatusID;
            return dao.Delete(offertingStatus);
        }

        public bool GetBack(OfferingStatusDetailDTO entity)
        {
            return dao.GetBack(entity.OfferingStatusID);
        }

        public bool DeletePermanently(OfferingStatusDetailDTO entity)
        {
            OFFERING_STATUS offeringStatus = new OFFERING_STATUS();
            offeringStatus.offeringStatusID = entity.OfferingStatusID;
            return dao.DeletePermanently(offeringStatus);
        }

        public bool Insert(OfferingStatusDetailDTO entity)
        {
            OFFERING_STATUS offstatus = new OFFERING_STATUS();
            offstatus.offeringStatus = entity.OfferingStatus;
            return dao.Insert(offstatus);
        }

        public OfferingStatusDTO Select()
        {
            OfferingStatusDTO dto = new OfferingStatusDTO();
            dto.OfferingStatuses = dao.Select();
            return dto;
        }

        public bool Update(OfferingStatusDetailDTO entity)
        {
            OFFERING_STATUS offstatus = new OFFERING_STATUS();
            offstatus.offeringStatusID = entity.OfferingStatusID;
            offstatus.offeringStatus = entity.OfferingStatus;
            return dao.Update(offstatus);
        }
    }
}
