using System;
using UnicoVehicle.DAL;
using UnicoVehicle.DTO.Miscellaneous;

namespace UnicoVehicle.BLL
{
    public class MiscellaneousCallsBLL : IMiscellaneousCallsBLL
    {
        private readonly IMiscellaneousCallsDAL _miscellaneousCallsDAL;
        private readonly IVehicleNameBLL _vehicleNameBLL;
        private readonly IVehicleVariantBLL _vehicleVariantBLL;

        public MiscellaneousCallsBLL(IMiscellaneousCallsDAL miscellaneousCallsDAL,
                                    IVehicleVariantBLL vehicleVariantBLL,
                                    IVehicleNameBLL vehicleNameBLL)
        {
            _miscellaneousCallsDAL = miscellaneousCallsDAL;
            _vehicleNameBLL = vehicleNameBLL;
            _vehicleVariantBLL = vehicleVariantBLL;
        }

        public Showroom GetShowroombyId(int id)
        {
            Showroom showroom = _miscellaneousCallsDAL.GetShowroombyId(id);

            if (showroom.ShowroomId != 0)
            {
                showroom.Company = _miscellaneousCallsDAL.GetCompanybyId(showroom.Company.CompanyId);
                showroom.District = _miscellaneousCallsDAL.GetDistrictbyId(showroom.District.DistrictId);
            }

            return showroom;
        }

        public Vehicle GetVehiclebyId(int id)
        {
            Vehicle vehicle= _miscellaneousCallsDAL.GetVehiclebyId(id);

            if (vehicle.VehicleId != 0)
            {
                vehicle.VehicleName = _vehicleNameBLL.GetVehicleNamebyId(vehicle.VehicleName.VehicleNameId);
                vehicle.VehicleVariant = _vehicleVariantBLL.GetVehicleVariantbyId(vehicle.VehicleVariant.VehicleVariantId);
            }

            return vehicle;
        }
    }
}
