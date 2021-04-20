using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class VehicleReviewDAL : IVehicleReviewDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _reviewCommand;
        private SqlDataReader _reviewReader;
        int _success;

        public VehicleReviewDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<VehicleReview> GetVehicleReviewbyUser(int id)
        {
            _reviewCommand = _utils.CommandGenerator(ResourceFiles.ReviewDALResources.GetVehicleReviewbyUser);
            _reviewReader = _reviewCommand.ExecuteReader();

            VehicleReview _review;
            List<VehicleReview> _reviews = new List<VehicleReview>();

            while (_reviewReader.Read())
            {
                _review = new VehicleReview()
                {
                    User = new User
                    {
                        UserId = id,
                    },
                    Vehicle = new DTO.Miscellaneous.Vehicle
                    {
                        VehicleId = int.Parse(_reviewReader["VehicleId"].ToString()),
                    },
                    Review = _reviewReader["VehicleReview"].ToString(),
                    VehicleReviewId = int.Parse(_reviewReader["VehicleReviewId"].ToString()),
                };

                _reviews.Add(_review);
            }

            _reviewReader.Close();
            _connection.CloseConnection();

            return _reviews;
        }

        public List<VehicleReview> GetVehicleReviewbyVehicle(int id)
        {
            _reviewCommand = _utils.CommandGenerator(ResourceFiles.ReviewDALResources.GetVehicleReviewbyVehicle);
            _reviewReader = _reviewCommand.ExecuteReader();

            VehicleReview _review;
            List<VehicleReview> _reviews = new List<VehicleReview>();

            while (_reviewReader.Read())
            {
                _review = new VehicleReview()
                {
                    User = new User
                    {
                        UserId = int.Parse(_reviewReader["UserId"].ToString()),
                    },
                    Vehicle = new DTO.Miscellaneous.Vehicle
                    {
                        VehicleId = id,
                    },
                    Review = _reviewReader["VehicleReview"].ToString(),
                    VehicleReviewId = int.Parse(_reviewReader["VehicleReviewId"].ToString()),
                };

                _reviews.Add(_review);
            }

            _reviewReader.Close();
            _connection.CloseConnection();

            return _reviews;
        }

        public VehicleReview GetVehicleReviewbyId(int id)
        {
            _reviewCommand = _utils.CommandGenerator(ResourceFiles.ReviewDALResources.GetVehicleReviewbyId);
            _reviewCommand.Parameters.AddWithValue("@vehicleReviewId", id);
            _reviewReader = _reviewCommand.ExecuteReader();

            VehicleReview _review = new VehicleReview();

            while (_reviewReader.Read())
            {
                _review = new VehicleReview
                {
                    User = new User
                    {
                        UserId = int.Parse(_reviewReader["UserId"].ToString()),
                    },
                    Vehicle = new DTO.Miscellaneous.Vehicle
                    {
                        VehicleId = int.Parse(_reviewReader["VehicleId"].ToString()),
                    },
                    Review = _reviewReader["VehicleReview"].ToString(),
                    VehicleReviewId = id,
                };
            }

            _reviewReader.Close();
            _connection.CloseConnection();

            return _review;

        }

        public bool InsertVehicleReview(VehicleReview vehicleReview)
        {
            _reviewCommand = _utils.CommandGenerator(ResourceFiles.ReviewDALResources.InsertVehicleReview);
            _reviewCommand.Parameters.AddWithValue("@userId", vehicleReview.User.UserId);
            _reviewCommand.Parameters.AddWithValue("@vehicleId", vehicleReview.Vehicle.VehicleId);
            _reviewCommand.Parameters.AddWithValue("@vehicleReview", vehicleReview.Review);
            _reviewCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _reviewCommand.ExecuteNonQuery();
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

        public bool DeleteVehicleReview(int id)
        {
            _reviewCommand = _utils.CommandGenerator(ResourceFiles.ReviewDALResources.DeleteVehicleReview);
            _reviewCommand.Parameters.AddWithValue("@vehicleReviewId", id);
            _reviewCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _reviewCommand.ExecuteNonQuery();
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

        public bool UpdateVehicleReview(VehicleReview vehicleReview, int id)
        {
            _reviewCommand = _utils.CommandGenerator(ResourceFiles.ReviewDALResources.UpdateVehicleReview);
            _reviewCommand.Parameters.AddWithValue("@vehicleReview", vehicleReview.Review);
            _reviewCommand.Parameters.AddWithValue("@vehicleReviewId", id);
            _reviewCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _reviewCommand.ExecuteNonQuery();
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
