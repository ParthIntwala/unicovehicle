using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class VehicleNameBLL : IVehicleNameBLL
    {
        private readonly IVehicleNameDAL _vehicleNameDAL;
        private readonly IMiscellaneousCalls _miscellaneousCalls;
        bool _status;

        public VehicleNameBLL(IVehicleNameDAL vehicleNameDAL, IMiscellaneousCalls miscellaneousCalls)
        {
            _vehicleNameDAL = vehicleNameDAL;
            _miscellaneousCalls = miscellaneousCalls;
        }

        public List<VehicleName> Get(int id)
        {
            List<VehicleName> _vehicleName = _vehicleNameDAL.GetVehicleName(id);

            foreach (VehicleName vehicle in _vehicleName)
            {
                vehicle.Company = _miscellaneousCalls.GetCompanybyId(vehicle.Company.CompanyId);
            }

            return _vehicleName;
        }

        public VehicleName GetVehicleNamebyId(int id)
        {
            VehicleName _vehicle = _vehicleNameDAL.GetVehicleNamebyId(id);

            if (_vehicle.VehicleNameId != 0)
            {
                _vehicle.Company = _miscellaneousCalls.GetCompanybyId(_vehicle.Company.CompanyId);
            }

            return _vehicle;
        }

        public bool InsertVehicleName(VehicleName vehicleName)
        {
            _status = _vehicleNameDAL.InsertVehicleName(vehicleName);
            return _status;
        }

        public bool DeleteVehicleName(int id)
        {
            _status = _vehicleNameDAL.DeleteVehicleName(id);
            return _status;
        }

        public bool UpdateVehicleName(string vehicleName, int vehicleNameId)
        {
            _status = _vehicleNameDAL.UpdateVehicleName(vehicleName, vehicleNameId);
            return _status;
        }
    }
}
