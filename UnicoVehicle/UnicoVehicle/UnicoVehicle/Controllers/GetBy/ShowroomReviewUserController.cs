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
    public class ShowroomReviewUserController : Controller
    {
        private readonly IShowroomReviewBLL _showroomReviewBll;

        public ShowroomReviewUserController(IShowroomReviewBLL showroomReviewBLL)
        {
            _showroomReviewBll = showroomReviewBLL;
        }

        [HttpGet("{Id}")]
        public List<ShowroomReview> GetShowroomReviewbyUser(int id)
        {
            List<ShowroomReview> _showroomReview = _showroomReviewBll.GetbyUser(id);
            return _showroomReview;
        }
    }
}
