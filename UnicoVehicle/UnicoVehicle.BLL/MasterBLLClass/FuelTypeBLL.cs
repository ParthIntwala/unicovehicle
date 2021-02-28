using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class FuelTypeBLL : IFuelTypeBLL
    {
        private readonly IFuelTypeDAL _fuelTypeDAL;
        bool _status;

        public FuelTypeBLL(IFuelTypeDAL fuelTypeDAL)
        {
            _fuelTypeDAL = fuelTypeDAL;
        }

        public List<FuelType> Get()
        {
            List<FuelType> _fuelTypes = _fuelTypeDAL.GetFuelType();
            return _fuelTypes;
        }

        public FuelType GetFuelTypebyId(int id)
        {
            FuelType _fuelType = _fuelTypeDAL.GetFuelTypebyId(id);
            return _fuelType;
        }

        public bool InsertFuelType(string fuelType)
        {
            _status = _fuelTypeDAL.InsertFuelType(fuelType);
            return _status;
        }

        public bool DeleteFuelType(int id)
        {
            _status = _fuelTypeDAL.DeleteFuelType(id);
            return _status;
        }
    }
}
