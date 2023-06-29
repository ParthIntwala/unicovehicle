using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class VehicleVariantBLL : IVehicleVariantBLL
    {
        private readonly IVehicleVariantDAL _vehicleVariantDAL;
        private readonly IMiscellaneousCallsDAL _miscellaneousCallsDAL;
        bool _status;

        public VehicleVariantBLL(IVehicleVariantDAL vehicleVariantDAL, IMiscellaneousCallsDAL miscellaneousCallsDAL)
        {
            _vehicleVariantDAL = vehicleVariantDAL;
            _miscellaneousCallsDAL = miscellaneousCallsDAL;
        }

        public List<VehicleVariant> Get(int id)
        {
            List<VehicleVariant> _vehicleVariant = _vehicleVariantDAL.GetVehicleVariantbyCompany(id);

            foreach (VehicleVariant vehicleVariant in _vehicleVariant)
            {
                vehicleVariant.Company = _miscellaneousCallsDAL.GetCompanybyId(vehicleVariant.Company.CompanyId);
            }

            return _vehicleVariant;
        }

        public VehicleVariant GetVehicleVariantbyId(int id)
        {
            VehicleVariant _vehicleVariant = _vehicleVariantDAL.GetVehicleVariantbyId(id);

            if (_vehicleVariant.VehicleVariantId != 0)
            {
                _vehicleVariant.Company = _miscellaneousCallsDAL.GetCompanybyId(_vehicleVariant.Company.CompanyId);
            }

            return _vehicleVariant;
        }

        public bool InsertVehicleVariant(VehicleVariant variant)
        {
            _status = _vehicleVariantDAL.InsertVehicleVariant(variant);
            return _status;
        }

        public bool DeleteVehicleVariant(int id)
        {
            _status = _vehicleVariantDAL.DeleteVehicleVariant(id);
            return _status;
        }
    }
}
