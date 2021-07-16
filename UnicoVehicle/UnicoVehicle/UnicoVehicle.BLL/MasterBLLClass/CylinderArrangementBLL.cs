using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class CylinderArrangementBLL : ICylinderArrangementBLL
    {
        private readonly ICylinderArrangementDAL _cylinderArrangementDAL;
        bool _status;

        public CylinderArrangementBLL(ICylinderArrangementDAL cylinderArrangementDAL)
        {
            _cylinderArrangementDAL = cylinderArrangementDAL;
        }

        public List<CylinderArrangement> Get()
        {
            List<CylinderArrangement> _cylinderArrangements = _cylinderArrangementDAL.GetCylinderArrangement();
            return _cylinderArrangements;
        }

        public bool InsertCylinderArrangement(string cylinderArrangement)
        {
            _status = _cylinderArrangementDAL.InsertCylinderArrangement(cylinderArrangement);
            return _status;
        }

        public bool DeleteCylinderArrangement(int id)
        {
            _status = _cylinderArrangementDAL.DeleteCylinderArrangement(id);
            return _status;
        }
    }
}
