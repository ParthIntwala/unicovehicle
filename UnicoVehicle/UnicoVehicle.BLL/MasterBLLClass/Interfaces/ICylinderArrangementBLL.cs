using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface ICylinderArrangementBLL
    {
        public bool DeleteCylinderArrangement(int id);
        public List<CylinderArrangement> Get();
        public CylinderArrangement GetCylinderArrangementbyId(int id);
        public bool InsertCylinderArrangement(string cylinderArrangement);
    }
}