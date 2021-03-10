using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class VehicleVariantBLL : IVehicleVariantBLL
    {
        private readonly IVehicleVariantDAL _vehicleVariantDAL;
        private readonly IMiscellaneousCalls _miscellaneousCalls;
        bool _status;

        public VehicleVariantBLL(IVehicleVariantDAL vehicleVariantDAL, IMiscellaneousCalls miscellaneousCalls)
        {
            _vehicleVariantDAL = vehicleVariantDAL;
            _miscellaneousCalls = miscellaneousCalls;
        }

        public List<VehicleVariant> Get(int id)
        {
            List<VehicleVariant> _vehicleVariant = _vehicleVariantDAL.GetVehicleVariantbyCompany(id);

            foreach (VehicleVariant vehicleVariant in _vehicleVariant)
            {
                vehicleVariant.Company = _miscellaneousCalls.GetCompanybyId(vehicleVariant.Company.CompanyId);
            }

            return _vehicleVariant;
        }

        public VehicleVariant GetVehicleVariantbyId(int id)
        {
            VehicleVariant _vehicleVariant = _vehicleVariantDAL.GetVehicleVariantbyId(id);

            if (_vehicleVariant.VehicleVariantId != 0)
            {
                _vehicleVariant.Company = _miscellaneousCalls.GetCompanybyId(_vehicleVariant.Company.CompanyId);
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
