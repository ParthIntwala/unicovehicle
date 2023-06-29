using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IVehicleVariantBLL
    {
        public bool DeleteVehicleVariant(int id);
        public List<VehicleVariant> Get(int id);
        public VehicleVariant GetVehicleVariantbyId(int id);
        public bool InsertVehicleVariant(VehicleVariant variant);
    }
}