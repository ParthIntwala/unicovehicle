using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class ShowroomReviewDAL : IShowroomReviewDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _reviewCommand;
        private SqlDataReader _reviewReader;
        int _success;

        public ShowroomReviewDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<ShowroomReview> GetShowroomReviewbyUser(int id)
        {
            _reviewCommand = _utils.CommandGenerator(ResourceFiles.ReviewDALResources.GetShowroomReviewbyUser);
            _reviewCommand.Parameters.AddWithValue("@userId", id);
            _reviewReader = _reviewCommand.ExecuteReader();

            ShowroomReview _review;
            List<ShowroomReview> _reviews = new List<ShowroomReview>();

            while (_reviewReader.Read())
            {
                _review = new ShowroomReview()
                {
                    User = new DTO.Miscellaneous.User
                    {
                        UserId = id,
                    },
                    Showroom = new DTO.Miscellaneous.Showroom
                    {
                        ShowroomId = int.Parse(_reviewReader["ShowroomId"].ToString()),
                    },
                    Review = _reviewReader["ShowroomReview"].ToString(),
                    ShowroomReviewId = int.Parse(_reviewReader["ShowroomReviewId"].ToString()),
                };

                _reviews.Add(_review);
            }

            _reviewReader.Close();
            _connection.CloseConnection();

            return _reviews;
        }

        public List<ShowroomReview> GetShowroomReviewbyShowroom(int id)
        {
            _reviewCommand = _utils.CommandGenerator(ResourceFiles.ReviewDALResources.GetShowroomReviewbyUser);
            _reviewCommand.Parameters.AddWithValue("@showroomId", id);
            _reviewReader = _reviewCommand.ExecuteReader();

            ShowroomReview _review;
            List<ShowroomReview> _reviews = new List<ShowroomReview>();

            while (_reviewReader.Read())
            {
                _review = new ShowroomReview()
                {
                    User = new DTO.Miscellaneous.User
                    {
                        UserId = int.Parse(_reviewReader["UserId"].ToString()),
                    },
                    Showroom = new DTO.Miscellaneous.Showroom
                    {
                        ShowroomId = id,
                    },
                    Review = _reviewReader["ShowroomReview"].ToString(),
                    ShowroomReviewId = int.Parse(_reviewReader["ShowroomReviewId"].ToString()),
                };

                _reviews.Add(_review);
            }

            _reviewReader.Close();
            _connection.CloseConnection();

            return _reviews;
        }

        public ShowroomReview GetShowroomReviewbyId(int id)
        {
            _reviewCommand = _utils.CommandGenerator(ResourceFiles.ReviewDALResources.GetShowroomReviewbyId);
            _reviewCommand.Parameters.AddWithValue("@showroomReviewId", id);
            _reviewReader = _reviewCommand.ExecuteReader();

            ShowroomReview _review = new ShowroomReview();

            while (_reviewReader.Read())
            {
                _review = new ShowroomReview
                {
                    User = new DTO.Miscellaneous.User
                    {
                        UserId = int.Parse(_reviewReader["UserId"].ToString()),
                    },
                    Showroom = new DTO.Miscellaneous.Showroom
                    {
                        ShowroomId = int.Parse(_reviewReader["ShowroomId"].ToString()),
                    },
                    Review = _reviewReader["ShowroomReview"].ToString(),
                    ShowroomReviewId = id,
                };
            }

            _reviewReader.Close();
            _connection.CloseConnection();

            return _review;

        }

        public bool InsertShowroomReview(ShowroomReview showroomReview)
        {
            _reviewCommand = _utils.CommandGenerator(ResourceFiles.ReviewDALResources.InsertShowroomReview);
            _reviewCommand.Parameters.AddWithValue("@userId", showroomReview.User.UserId);
            _reviewCommand.Parameters.AddWithValue("@showroomId", showroomReview.Showroom.ShowroomId);
            _reviewCommand.Parameters.AddWithValue("@showroomReview", showroomReview.Review);
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

        public bool DeleteShowroomReview(int id)
        {
            _reviewCommand = _utils.CommandGenerator(ResourceFiles.ReviewDALResources.DeleteShowroomReview);
            _reviewCommand.Parameters.AddWithValue("@showroomReviewId", id);
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

        public bool UpdateShowroomReview(ShowroomReview showroomReview, int id)
        {
            _reviewCommand = _utils.CommandGenerator(ResourceFiles.ReviewDALResources.UpdateShowroomReview);
            _reviewCommand.Parameters.AddWithValue("@showroomReview", showroomReview.Review);
            _reviewCommand.Parameters.AddWithValue("@showroomReviewId", id);
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
