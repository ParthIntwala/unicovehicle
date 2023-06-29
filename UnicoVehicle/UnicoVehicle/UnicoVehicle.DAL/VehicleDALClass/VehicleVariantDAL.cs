using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnicoVehicle.DAL
{
    public class VehicleVariantDAL : IVehicleVariantDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _variantCommand;
        private SqlDataReader _variantReader;
        int _success;

        public VehicleVariantDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public List<VehicleVariant> GetVehicleVariantbyCompany(int id)
        {
            _variantCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetVehicleVariantbyCompany);
            _variantCommand.Parameters.AddWithValue("@companyId", id);
            _variantReader = _variantCommand.ExecuteReader();

            VehicleVariant _variant;
            List<VehicleVariant> _variants = new List<VehicleVariant>();

            while (_variantReader.Read())
            {
                _variant = new VehicleVariant
                {
                    VehicleVariantId = int.Parse(_variantReader["VehicleVariantId"].ToString()),
                    VehicleVariantName = _variantReader["VehicleVariant"].ToString(),
                    Company = new DTO.Miscellaneous.Company
                    {
                        CompanyId = int.Parse(_variantReader["CompanyId"].ToString()),
                    }
                };

                _variants.Add(_variant);
            }

            _variantReader.Close();
            _connection.CloseConnection();

            return _variants;
        }

        public VehicleVariant GetVehicleVariantbyId(int id)
        {
            _variantCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetVehicleVariantbyId);
            _variantCommand.Parameters.AddWithValue("@vehicleVariantId", id);
            _variantReader = _variantCommand.ExecuteReader();

            VehicleVariant _variant = new VehicleVariant();

            while (_variantReader.Read())
            {
                _variant = new VehicleVariant
                {
                    VehicleVariantId = id,
                    VehicleVariantName = _variantReader["VehicleVariant"].ToString(),
                    Company = new DTO.Miscellaneous.Company
                    {
                        CompanyId = int.Parse(_variantReader["CompanyId"].ToString()),
                    }
                };
            }

            _variantReader.Close();
            _connection.CloseConnection();

            return _variant;

        }

        public bool InsertVehicleVariant(VehicleVariant variant)
        {
            _variantCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.InsertVehicleVariant);
            _variantCommand.Parameters.AddWithValue("@vehicleVariant", variant.VehicleVariantName);
            _variantCommand.Parameters.AddWithValue("@companyId", variant.Company.CompanyId);
            _variantCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _variantCommand.ExecuteNonQuery();
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

        public bool DeleteVehicleVariant(int id)
        {
            _variantCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.DeleteVehicleVariant);
            _variantCommand.Parameters.AddWithValue("@vehicleVariantId", id);
            _variantCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _variantCommand.ExecuteNonQuery();
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
