using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class ShowroomDAL : IShowroomDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _showroomCommand;
        private SqlDataReader _showroomReader;
        int _success;

        public ShowroomDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<Showroom> GetShowroom()
        {
            _showroomCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.GetShowroom);
            _showroomReader = _showroomCommand.ExecuteReader();

            Showroom _showroom;
            List<Showroom> _showrooms = new List<Showroom>();

            while (_showroomReader.Read())
            {
                _showroom = new Showroom()
                {
                    Company = new DTO.Miscellaneous.Company
                    {
                        CompanyId = int.Parse(_showroomReader["CompanyId"].ToString()),
                    },
                    District = new DTO.Miscellaneous.District
                    {
                        DistrictId = int.Parse(_showroomReader["DistrictId"].ToString()),
                    },
                    Manager = _showroomReader["BranchManager"].ToString(),
                    Address = _showroomReader["AddressLine1"].ToString(),
                    PINCODE = int.Parse(_showroomReader["Pincode"].ToString()),
                    ShowroomId = int.Parse(_showroomReader["ShowroomId"].ToString()),
                    ShowroomName = _showroomReader["ShowroomName"].ToString(),
                    hasSales = bool.Parse(_showroomReader["hasSales"].ToString()),
                    hasService = bool.Parse(_showroomReader["hasService"].ToString()),
                    isOperational = bool.Parse(_showroomReader["isOperational"].ToString()),
                };

                _showrooms.Add(_showroom);
            }

            _showroomReader.Close();
            _connection.CloseConnection();

            return _showrooms;
        }

        public List<Showroom> GetShowroombyCompany(int companyId)
        {
            _showroomCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.GetShowroombyCompany);
            _showroomCommand.Parameters.AddWithValue("@companyId", companyId);
            _showroomReader = _showroomCommand.ExecuteReader();

            Showroom _showroom;
            List<Showroom> _showrooms = new List<Showroom>();

            while (_showroomReader.Read())
            {
                _showroom = new Showroom()
                {
                    Company = new DTO.Miscellaneous.Company
                    {
                        CompanyId = int.Parse(_showroomReader["CompanyId"].ToString()),
                    },
                    District = new DTO.Miscellaneous.District
                    {
                        DistrictId = int.Parse(_showroomReader["DistrictId"].ToString()),
                    },
                    Manager = _showroomReader["BranchManager"].ToString(),
                    Address = _showroomReader["AddressLine1"].ToString(),
                    PINCODE = int.Parse(_showroomReader["Pincode"].ToString()),
                    ShowroomId = int.Parse(_showroomReader["ShowroomId"].ToString()),
                    ShowroomName = _showroomReader["ShowroomName"].ToString(),
                    hasSales = bool.Parse(_showroomReader["hasSales"].ToString()),
                    hasService = bool.Parse(_showroomReader["hasService"].ToString()),
                    isOperational = bool.Parse(_showroomReader["isOperational"].ToString()),
                };

                _showrooms.Add(_showroom);
            }

            _showroomReader.Close();
            _connection.CloseConnection();

            return _showrooms;
        }

        public List<Showroom> GetShowroombyDistrict(int districtId)
        {
            _showroomCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.GetShowroombyDistrict);
            _showroomCommand.Parameters.AddWithValue("@districtId", districtId);
            _showroomReader = _showroomCommand.ExecuteReader();

            Showroom _showroom;
            List<Showroom> _showrooms = new List<Showroom>();

            while (_showroomReader.Read())
            {
                _showroom = new Showroom()
                {
                    Company = new DTO.Miscellaneous.Company
                    {
                        CompanyId = int.Parse(_showroomReader["CompanyId"].ToString()),
                    },
                    District = new DTO.Miscellaneous.District
                    {
                        DistrictId = int.Parse(_showroomReader["DistrictId"].ToString()),
                    },
                    Manager = _showroomReader["BranchManager"].ToString(),
                    Address = _showroomReader["AddressLine1"].ToString(),
                    PINCODE = int.Parse(_showroomReader["Pincode"].ToString()),
                    ShowroomId = int.Parse(_showroomReader["ShowroomId"].ToString()),
                    ShowroomName = _showroomReader["ShowroomName"].ToString(),
                    hasSales = bool.Parse(_showroomReader["hasSales"].ToString()),
                    hasService = bool.Parse(_showroomReader["hasService"].ToString()),
                    isOperational = bool.Parse(_showroomReader["isOperational"].ToString()),
                };

                _showrooms.Add(_showroom);
            }

            _showroomReader.Close();
            _connection.CloseConnection();

            return _showrooms;
        }

        public Showroom GetShowroombyId(int id)
        {
            _showroomCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.GetShowroombyId);
            _showroomCommand.Parameters.AddWithValue("@showroomId", id);
            _showroomReader = _showroomCommand.ExecuteReader();

            Showroom _showroom = new Showroom();

            while (_showroomReader.Read())
            {
                _showroom = new Showroom()
                {
                    Company = new DTO.Miscellaneous.Company
                    {
                        CompanyId = int.Parse(_showroomReader["CompanyId"].ToString()),
                    },
                    District = new DTO.Miscellaneous.District
                    {
                        DistrictId = int.Parse(_showroomReader["DistrictId"].ToString()),
                    },
                    Manager = _showroomReader["BranchManager"].ToString(),
                    Address = _showroomReader["AddressLine1"].ToString(),
                    PINCODE = int.Parse(_showroomReader["Pincode"].ToString()),
                    ShowroomName = _showroomReader["ShowroomName"].ToString(),
                    hasSales = bool.Parse(_showroomReader["hasSales"].ToString()),
                    hasService = bool.Parse(_showroomReader["hasService"].ToString()),
                    isOperational = bool.Parse(_showroomReader["isOperational"].ToString()),
                    ShowroomId = id,
                };
            }

            _showroomReader.Close();
            _connection.CloseConnection();

            return _showroom;

        }

        public bool InsertShowroom(Showroom showroom)
        {
            _showroomCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.InsertShowroom);
            _showroomCommand.Parameters.AddWithValue("@districtId", showroom.District.DistrictId);
            _showroomCommand.Parameters.AddWithValue("@companyId", showroom.Company.CompanyId);
            _showroomCommand.Parameters.AddWithValue("@showroomName", showroom.ShowroomName);
            _showroomCommand.Parameters.AddWithValue("@addressLine1", showroom.Address);
            _showroomCommand.Parameters.AddWithValue("@pincode", showroom.PINCODE);
            _showroomCommand.Parameters.AddWithValue("@branchManager", showroom.Manager);
            _showroomCommand.Parameters.AddWithValue("@hasSales", showroom.hasSales);
            _showroomCommand.Parameters.AddWithValue("@hasService", showroom.hasService);
            _showroomCommand.Parameters.AddWithValue("@isOperational", showroom.isOperational);
            _showroomCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _showroomCommand.ExecuteNonQuery();
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

        public bool DeleteShowroom(int id)
        {
            _showroomCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.DeleteShowroom);
            _showroomCommand.Parameters.AddWithValue("@showroomId", id);
            _showroomCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _showroomCommand.ExecuteNonQuery();
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

        public bool UpdateShowroom(Showroom showroom, int id)
        {
            _showroomCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.UpdateShowroom);
            _showroomCommand.Parameters.AddWithValue("@districtId", showroom.District.DistrictId);
            _showroomCommand.Parameters.AddWithValue("@showroomName", showroom.ShowroomName);
            _showroomCommand.Parameters.AddWithValue("@addressLine1", showroom.Address);
            _showroomCommand.Parameters.AddWithValue("@pincode", showroom.PINCODE);
            _showroomCommand.Parameters.AddWithValue("@branchManager", showroom.Manager);
            _showroomCommand.Parameters.AddWithValue("@hasSales", showroom.hasSales);
            _showroomCommand.Parameters.AddWithValue("@hasService", showroom.hasService);
            _showroomCommand.Parameters.AddWithValue("@isOperational", showroom.isOperational);
            _showroomCommand.Parameters.AddWithValue("@showroomId", id);
            _showroomCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _showroomCommand.ExecuteNonQuery();
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
