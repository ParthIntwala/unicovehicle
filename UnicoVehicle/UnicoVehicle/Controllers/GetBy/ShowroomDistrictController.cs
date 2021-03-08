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
    public class ShowroomDistrictController : Controller
    {
        private readonly IShowroomBLL _showroomBll;

        public ShowroomDistrictController(IShowroomBLL showroomBll)
        {
            _showroomBll = showroomBll;
        }

        [HttpGet("{Id}")]
        public List<Showroom> GetShowroom(int Id)
        {
            List<Showroom> _showroom = _showroomBll.GetDistrict(Id);
            return _showroom;
        }
    }
}
