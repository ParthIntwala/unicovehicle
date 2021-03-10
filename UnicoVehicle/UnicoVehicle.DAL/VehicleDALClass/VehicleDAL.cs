using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class VehicleDAL : IVehicleDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _vehicleCommand;
        private SqlDataReader _vehicleReader;
        int _success;

        public VehicleDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<Vehicle> GetVehiclebyTransmissionType(int Id)
        {
            _vehicleCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetVehiclebyTransmission);
            _vehicleCommand.Parameters.AddWithValue("@transmissionTypeId", Id);
            _vehicleReader = _vehicleCommand.ExecuteReader();

            Vehicle _vehicle;
            List<Vehicle> _vehicles = new List<Vehicle>();

            while (_vehicleReader.Read())
            {
                _vehicle = new Vehicle()
                {
                    VehicleId = int.Parse(_vehicleReader["VehicleId"].ToString()),
                    VehicleName = new VehicleName
                    {
                        VehicleNameId = int.Parse(_vehicleReader["VehicleNameId"].ToString())
                    },
                    CylinderArrangement = new CylinderArrangement
                    {
                        CylinderArrangementId = int.Parse(_vehicleReader["CylinderArrangementId"].ToString())
                    },
                    TransmissionType = new TransmissionType
                    {
                        TransmissionTypeId = int.Parse(_vehicleReader["TransmissionTypeId"].ToString())
                    },
                    VehicleVariant = new VehicleVariant
                    {
                        VehicleVariantId = int.Parse(_vehicleReader["VehicleVariantId"].ToString())
                    },
                    VehicleType = new VehicleType
                    {
                        VehicleTypeId = int.Parse(_vehicleReader["VehicleTypeId"].ToString())
                    },
                    FuelType = new FuelType
                    {
                        FuelTypeId = int.Parse(_vehicleReader["FuelTypeId"].ToString())
                    },
                    Cylinder = int.Parse(_vehicleReader["NumberofCylinder"].ToString()),
                    Doors = int.Parse(_vehicleReader["NumberofDoors"].ToString()),
                    Passenger = int.Parse(_vehicleReader["NumberofPassenger"].ToString()),
                    EngineSize = int.Parse(_vehicleReader["EngineSize"].ToString()),
                    FuelTankSize = float.Parse(_vehicleReader["FuelTankSize"].ToString()),
                    HorsePower = float.Parse(_vehicleReader["HorsePower"].ToString()),
                    Torque = float.Parse(_vehicleReader["Torque"].ToString()),
                    Mileage = float.Parse(_vehicleReader["Mileage"].ToString()),
                    GrossWeight = float.Parse(_vehicleReader["GrossWeight"].ToString()),
                    GroundClearance = float.Parse(_vehicleReader["GroundClearance"].ToString()),
                    Height = float.Parse(_vehicleReader["Height"].ToString()),
                    Length = float.Parse(_vehicleReader["Length"].ToString()),
                    Width = float.Parse(_vehicleReader["Width"].ToString()),
                    KerbWeight = float.Parse(_vehicleReader["KerbWeight"].ToString()),
                    WheelBase = float.Parse(_vehicleReader["WheelBase"].ToString()),
                };

                _vehicles.Add(_vehicle);
            }

            _vehicleReader.Close();
            _connection.CloseConnection();

            return _vehicles;
        }

        public Vehicle GetVehiclebyId(int id)
        {

            _vehicleCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetVehiclebyId);
            _vehicleCommand.Parameters.AddWithValue("@vehicleId", id);
            _vehicleReader = _vehicleCommand.ExecuteReader();

            Vehicle _vehicle = new Vehicle();

            while (_vehicleReader.Read())
            {
                _vehicle = new Vehicle
                {
                    VehicleId = id,
                    VehicleName = new VehicleName
                    {
                        VehicleNameId = int.Parse(_vehicleReader["VehicleNameId"].ToString())
                    },
                    CylinderArrangement = new CylinderArrangement
                    {
                        CylinderArrangementId = int.Parse(_vehicleReader["CylinderArrangementId"].ToString())
                    },
                    TransmissionType = new TransmissionType
                    {
                        TransmissionTypeId = int.Parse(_vehicleReader["TransmissionTypeId"].ToString())
                    },
                    VehicleVariant = new VehicleVariant
                    {
                        VehicleVariantId = int.Parse(_vehicleReader["VehicleVariantId"].ToString())
                    },
                    VehicleType = new VehicleType
                    {
                        VehicleTypeId = int.Parse(_vehicleReader["VehicleTypeId"].ToString())
                    },
                    FuelType = new FuelType
                    {
                        FuelTypeId = int.Parse(_vehicleReader["FuelTypeId"].ToString())
                    },
                    Cylinder = int.Parse(_vehicleReader["NumberofCylinder"].ToString()),
                    Doors = int.Parse(_vehicleReader["NumberofDoors"].ToString()),
                    Passenger = int.Parse(_vehicleReader["NumberofPassenger"].ToString()),
                    EngineSize = int.Parse(_vehicleReader["EngineSize"].ToString()),
                    FuelTankSize = float.Parse(_vehicleReader["FuelTankSize"].ToString()),
                    HorsePower = float.Parse(_vehicleReader["HorsePower"].ToString()),
                    Torque = float.Parse(_vehicleReader["Torque"].ToString()),
                    Mileage = float.Parse(_vehicleReader["Mileage"].ToString()),
                    GrossWeight = float.Parse(_vehicleReader["GrossWeight"].ToString()),
                    GroundClearance = float.Parse(_vehicleReader["GroundClearance"].ToString()),
                    Height = float.Parse(_vehicleReader["Height"].ToString()),
                    Length = float.Parse(_vehicleReader["Length"].ToString()),
                    Width = float.Parse(_vehicleReader["Width"].ToString()),
                    KerbWeight = float.Parse(_vehicleReader["KerbWeight"].ToString()),
                    WheelBase = float.Parse(_vehicleReader["WheelBase"].ToString()),
                };
            }

            _vehicleReader.Close();
            _connection.CloseConnection();

            return _vehicle;
        }

        public bool InsertVehicle(Vehicle vehicle)
        {
            _vehicleCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.InsertVehicle);
            _vehicleCommand.Parameters.AddWithValue("@vehicleNameId", vehicle.VehicleName.VehicleNameId);
            _vehicleCommand.Parameters.AddWithValue("@vehicleVariantId", vehicle.VehicleVariant.VehicleVariantId);
            _vehicleCommand.Parameters.AddWithValue("@transmissionTypeId", vehicle.TransmissionType.TransmissionTypeId);
            _vehicleCommand.Parameters.AddWithValue("@fuelTypeId", vehicle.FuelType.FuelTypeId);
            _vehicleCommand.Parameters.AddWithValue("@vehicleTypeId", vehicle.VehicleType.VehicleTypeId);
            _vehicleCommand.Parameters.AddWithValue("@cylinderArrangementId", vehicle.CylinderArrangement.CylinderArrangementId);
            _vehicleCommand.Parameters.AddWithValue("@numberofDoors", vehicle.Doors);
            _vehicleCommand.Parameters.AddWithValue("@numberofPassanger", vehicle.Passenger);
            _vehicleCommand.Parameters.AddWithValue("@numberofCylinder", vehicle.Cylinder);
            _vehicleCommand.Parameters.AddWithValue("@engineSize", vehicle.EngineSize);
            _vehicleCommand.Parameters.AddWithValue("@horsePower", vehicle.HorsePower);
            _vehicleCommand.Parameters.AddWithValue("@torque", vehicle.Torque);
            _vehicleCommand.Parameters.AddWithValue("@mileage", vehicle.Mileage);
            _vehicleCommand.Parameters.AddWithValue("@height", vehicle.Height);
            _vehicleCommand.Parameters.AddWithValue("@width", vehicle.Width);
            _vehicleCommand.Parameters.AddWithValue("@length", vehicle.Length);
            _vehicleCommand.Parameters.AddWithValue("@groundClearance", vehicle.GroundClearance);
            _vehicleCommand.Parameters.AddWithValue("@wheelBase", vehicle.WheelBase);
            _vehicleCommand.Parameters.AddWithValue("@fuelTankSize", vehicle.FuelTankSize);
            _vehicleCommand.Parameters.AddWithValue("@kerbWeight", vehicle.KerbWeight);
            _vehicleCommand.Parameters.AddWithValue("@grossWeight", vehicle.GrossWeight);
            _vehicleCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _vehicleCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteVehicle(int id)
        {
            _vehicleCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.DeleteVehicle);
            _vehicleCommand.Parameters.AddWithValue("@vehicleId", id);
            _vehicleCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _vehicleCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateVehicle(Vehicle vehicle, int vehicleId)
        {
            _vehicleCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.UpdateVehicle);
            _vehicleCommand.Parameters.AddWithValue("@vehicleNameId", vehicle.VehicleName.VehicleNameId);
            _vehicleCommand.Parameters.AddWithValue("@vehicleVariantId", vehicle.VehicleVariant.VehicleVariantId);
            _vehicleCommand.Parameters.AddWithValue("@transmissionTypeId", vehicle.TransmissionType.TransmissionTypeId);
            _vehicleCommand.Parameters.AddWithValue("@fuelTypeId", vehicle.FuelType.FuelTypeId);
            _vehicleCommand.Parameters.AddWithValue("@vehicleTypeId", vehicle.VehicleType.VehicleTypeId);
            _vehicleCommand.Parameters.AddWithValue("@cylinderArrangementId", vehicle.CylinderArrangement.CylinderArrangementId);
            _vehicleCommand.Parameters.AddWithValue("@numberofDoors", vehicle.Doors);
            _vehicleCommand.Parameters.AddWithValue("@numberofPassanger", vehicle.Passenger);
            _vehicleCommand.Parameters.AddWithValue("@numberofCylinder", vehicle.Cylinder);
            _vehicleCommand.Parameters.AddWithValue("@engineSize", vehicle.EngineSize);
            _vehicleCommand.Parameters.AddWithValue("@horsePower", vehicle.HorsePower);
            _vehicleCommand.Parameters.AddWithValue("@torque", vehicle.Torque);
            _vehicleCommand.Parameters.AddWithValue("@mileage", vehicle.Mileage);
            _vehicleCommand.Parameters.AddWithValue("@height", vehicle.Height);
            _vehicleCommand.Parameters.AddWithValue("@width", vehicle.Width);
            _vehicleCommand.Parameters.AddWithValue("@length", vehicle.Length);
            _vehicleCommand.Parameters.AddWithValue("@groundClearance", vehicle.GroundClearance);
            _vehicleCommand.Parameters.AddWithValue("@wheelBase", vehicle.WheelBase);
            _vehicleCommand.Parameters.AddWithValue("@fuelTankSize", vehicle.FuelTankSize);
            _vehicleCommand.Parameters.AddWithValue("@kerbWeight", vehicle.KerbWeight);
            _vehicleCommand.Parameters.AddWithValue("@grossWeight", vehicle.GrossWeight);
            _vehicleCommand.Parameters.AddWithValue("@vehicleId", vehicleId);
            _vehicleCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _vehicleCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
