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
    public class ShowroomReviewShowroomController : Controller
    {
        private readonly IShowroomReviewBLL _showroomReviewBll;

        public ShowroomReviewShowroomController(IShowroomReviewBLL showroomReviewBLL)
        {
            _showroomReviewBll = showroomReviewBLL;
        }

        [HttpGet("{Id}")]
        public List<ShowroomReview> GetShowroomReviewbyShowroom(int id)
        {
            List<ShowroomReview> _showroomReview = _showroomReviewBll.GetbyShowroom(id);
            return _showroomReview;
        }
    }
}

