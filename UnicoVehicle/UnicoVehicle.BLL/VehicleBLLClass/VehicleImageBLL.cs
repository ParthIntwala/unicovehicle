using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class VehicleImageBLL : IVehicleImageBLL
    {
        private readonly IVehicleImagesDAL _vehicleImageDAL;
        private readonly IMiscellaneousCallsBLL _miscellaneousCallsBLL;
        bool _status;

        public VehicleImageBLL(IVehicleImagesDAL vehicleImagesDAL, IMiscellaneousCallsBLL miscellaneousCallsBLL)
        {
            _miscellaneousCallsBLL = miscellaneousCallsBLL;
            _vehicleImageDAL = vehicleImagesDAL;
        }

        public VehicleImages GetVehicleImagesbyId(int id)
        {
            VehicleImages image = _vehicleImageDAL.GetVehicleImagesbyId(id);

            if (image.VehicleImagesId != 0)
            {
                image.Vehicle = _miscellaneousCallsBLL.GetVehiclebyId(image.Vehicle.VehicleId);
            }

            return image;
        }

        public bool InsertVehicleImages(VehicleImages image, int id)
        {
            _status = _vehicleImageDAL.InsertVehicleImages(image, id);
            return _status;
        }

        public bool UpdateVehicleImages(VehicleImages image, int id)
        {
            _status = _vehicleImageDAL.UpdateVehicleImages(image, id);
            return _status;
        }
    }
}
