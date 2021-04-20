using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnicoVehicle.BLL;
using UnicoVehicle.DTO;

namespace UnicoVehicle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowroomReviewController : Controller
    {
        private readonly IShowroomReviewBLL _showroomReviewBll;
        bool _status;

        public ShowroomReviewController(IShowroomReviewBLL showroomReviewBLL)
        {
            _showroomReviewBll = showroomReviewBLL;
        }

        [HttpGet("{Id}")]
        public ShowroomReview GetShowroomReviewbyId(int id)
        {
            ShowroomReview _showroomReview = _showroomReviewBll.GetShowroomReviewbyId(id);
            return _showroomReview;
        }

        [HttpPost]
        public bool InsertShowroomReview([FromBody] ShowroomReview showroomReview)
        {
            _status = _showroomReviewBll.InsertShowroomReview(showroomReview);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteShowroomReview(int id)
        {
            _status = _showroomReviewBll.DeleteShowroomReview(id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateShowroomReview([FromBody] ShowroomReview showroomReview, int id)
        {
            _status = _showroomReviewBll.UpdateShowroomReview(showroomReview, id);
            return _status;
        }
    }
}
