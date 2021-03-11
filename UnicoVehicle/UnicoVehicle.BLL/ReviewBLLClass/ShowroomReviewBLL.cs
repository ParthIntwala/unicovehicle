using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;
using UnicoVehicle.BLL;

namespace UnicoVehicle.BLL
{
    public class ShowroomReviewBLL : IShowroomReviewBLL
    {
        private readonly IShowroomReviewDAL _showroomReviewDAL;
        private readonly IUserBLL _userBLL;
        private readonly IMiscellaneousCallsBLL _miscellaneousCallsBLL;
        bool _status;

        public ShowroomReviewBLL(IShowroomReviewDAL showroomReviewDAL, IUserBLL userBLL, IMiscellaneousCallsBLL miscellaneousCallsBLL)
        {
            _showroomReviewDAL = showroomReviewDAL;
            _userBLL = userBLL;
            _miscellaneousCallsBLL = miscellaneousCallsBLL;
        }

        public List<ShowroomReview> Get()
        {
            List<ShowroomReview> _showroomReview = _showroomReviewDAL.GetShowroomReview();

            foreach (ShowroomReview showroomReview in _showroomReview)
            {
                showroomReview.User = _userBLL.GetUserbyId(showroomReview.User.UserId);
                showroomReview.Showroom = _miscellaneousCallsBLL.GetShowroombyId(showroomReview.Showroom.ShowroomId);
            }

            return _showroomReview;
        }

        public ShowroomReview GetShowroomReviewbyId(int id)
        {
            ShowroomReview _showroomReview = _showroomReviewDAL.GetShowroomReviewbyId(id);

            if (_showroomReview.ShowroomReviewId != 0)
            {
                _showroomReview.User = _userBLL.GetUserbyId(_showroomReview.User.UserId);
                _showroomReview.Showroom = _miscellaneousCallsBLL.GetShowroombyId(_showroomReview.Showroom.ShowroomId);
            }

            return _showroomReview;
        }

        public bool InsertShowroomReview(ShowroomReview showroomReview)
        {
            _status = _showroomReviewDAL.InsertShowroomReview(showroomReview);
            return _status;
        }

        public bool DeleteShowroomReview(int id)
        {
            _status = _showroomReviewDAL.DeleteShowroomReview(id);
            return _status;
        }

        public bool UpdateShowroomReview(ShowroomReview showroomReview, int userId)
        {
            _status = _showroomReviewDAL.UpdateShowroomReview(showroomReview, userId);
            return _status;
        }
    }
}
