using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using UnicoVehicle.DTO;
using System.Collections.Generic;

namespace UnicoVehicle.DAL
{
    public class VehicleNameDAL : IVehicleNameDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _vehicleCommand;
        private SqlDataReader _vehicleReader;
        int _success;

        public VehicleNameDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<VehicleName> GetVehicleName(int id)
        {
            _vehicleCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetVehicleName);
            _vehicleCommand.Parameters.AddWithValue("@companyId", id);
            _vehicleReader = _vehicleCommand.ExecuteReader();

            List<VehicleName> _vehicles = new List<VehicleName>();
            VehicleName _vehicle;

            while (_vehicleReader.Read())
            {
                _vehicle = new VehicleName()
                {
                    VehicleNameId = int.Parse(_vehicleReader["VehicleNameId"].ToString()),
                    Name = _vehicleReader["VehicleName"].ToString(),
                    Company = new DTO.Miscellaneous.Company
                    {
                        CompanyId = int.Parse(_vehicleReader["CompanyId"].ToString()),
                    }
                };

                _vehicles.Add(_vehicle);
            }

            _vehicleReader.Close();
            _connection.CloseConnection();

            return _vehicles;

        }

        public VehicleName GetVehicleNamebyId(int id)
        {
            _vehicleCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetVehicleNamebyId);
            _vehicleCommand.Parameters.AddWithValue("@vehicleNameId", id);
            _vehicleReader = _vehicleCommand.ExecuteReader();

            VehicleName _vehicle = new VehicleName();

            while (_vehicleReader.Read())
            {
                _vehicle = new VehicleName()
                {
                    VehicleNameId = id,
                    Name = _vehicleReader["VehicleName"].ToString(),
                    Company = new DTO.Miscellaneous.Company
                    {
                        CompanyId = int.Parse(_vehicleReader["CompanyId"].ToString()),
                    }
                };
            }

            _vehicleReader.Close();
            _connection.CloseConnection();

            return _vehicle;
        }

        public bool DeleteVehicleName(int id)
        {
            _vehicleCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.DeleteVehicleName);
            _vehicleCommand.Parameters.AddWithValue("@vehicleNameId", id);
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

        public bool InsertVehicleName(VehicleName vehicle)
        {
            _vehicleCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.InsertVehicleName);
            _vehicleCommand.Parameters.AddWithValue("@vehicleName", vehicle.Name);
            _vehicleCommand.Parameters.AddWithValue("@companyId", vehicle.Company.CompanyId);
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

        public bool UpdateVehicleName(string vehicle, int id)
        {
            _vehicleCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.UpdateVehicleName);
            _vehicleCommand.Parameters.AddWithValue("@vehicleName", vehicle);
            _vehicleCommand.Parameters.AddWithValue("@vehicleNameId", id);
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
