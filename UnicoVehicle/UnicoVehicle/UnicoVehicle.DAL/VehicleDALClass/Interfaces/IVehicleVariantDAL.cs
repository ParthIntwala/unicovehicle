using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IVehicleVariantDAL
    {
        public bool DeleteVehicleVariant(int id);
        public List<VehicleVariant> GetVehicleVariantbyCompany(int id);
        public VehicleVariant GetVehicleVariantbyId(int id);
        public bool InsertVehicleVariant(VehicleVariant variant);
    }
}