using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface ICylinderArrangementDAL
    {
        public bool DeleteCylinderArrangement(int id);
        public List<CylinderArrangement> GetCylinderArrangement();
        public CylinderArrangement GetCylinderArrangementbyId(int id);
        public bool InsertCylinderArrangement(string fuelType);
    }
}