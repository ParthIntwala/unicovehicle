using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IFuelTypeBLL
    {
        public bool DeleteFuelType(int id);
        public List<FuelType> Get();
        public FuelType GetFuelTypebyId(int id);
        public bool InsertFuelType(string fuelType);
    }
}