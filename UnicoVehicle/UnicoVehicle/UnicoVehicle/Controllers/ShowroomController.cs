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
    public class ShowroomController : Controller
    {
        private readonly IShowroomBLL _showroomBll;
        bool _status;

        public ShowroomController(IShowroomBLL showroomBll)
        {
            _showroomBll = showroomBll;
        }

        [HttpGet]
        public List<Showroom> GetShowroom()
        {
            List<Showroom> _showroom = _showroomBll.Get();
            return _showroom;
        }

        [HttpGet("{Id}")]
        public Showroom GetShowroombyId(int id)
        {
            Showroom _showroom = _showroomBll.GetShowroombyId(id);
            return _showroom;
        }

        [HttpPost]
        public bool InsertShowroom([FromBody] Showroom showroom)
        {
            _status = _showroomBll.InsertShowroom(showroom);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteShowroom(int id)
        {
            _status = _showroomBll.DeleteShowroom(id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateShowroom([FromBody] Showroom showroom, int id)
        {
            _status = _showroomBll.UpdateShowroom(showroom, id);
            return _status;
        }
    }
}
