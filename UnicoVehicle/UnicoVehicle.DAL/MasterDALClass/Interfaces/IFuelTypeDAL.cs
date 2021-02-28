using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IFuelTypeDAL
    {
        public bool DeleteFuelType(int id);
        public List<FuelType> GetFuelType();
        public FuelType GetFuelTypebyId(int id);
        public bool InsertFuelType(string fuelType);
    }
}