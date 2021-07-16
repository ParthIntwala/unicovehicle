using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IAccessoryBrandBLL
    {
        public bool DeleteTransmissionType(int id);
        public List<AccessoryBrand> Get();
        public bool InsertTransmissionType(string accessoryBrand);
    }
}