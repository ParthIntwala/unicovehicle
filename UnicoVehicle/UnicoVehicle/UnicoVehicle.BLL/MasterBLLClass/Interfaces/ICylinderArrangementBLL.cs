using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface ICylinderArrangementBLL
    {
        public bool DeleteCylinderArrangement(int id);
        public List<CylinderArrangement> Get();
        public bool InsertCylinderArrangement(string cylinderArrangement);
    }
}